using ECS_Proto.Core.Component;
using ECS_Proto.Core.Injector;
using ECS_Proto.Core.Render;
using ECS_Proto.Game.Components;
using ECS_Proto.Game.GameObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECS_Proto.Core
{
    class GameObjectManager
    {
        List<BaseObject> goList = new List<BaseObject>();

        public GameObjectManager()
        {
            DepInjector.RegisterInjectable(this);
        }

        public static event OnNewEntityHandler OnNewEntity;
        public delegate void OnNewEntityHandler(BaseObject[] b);

        List<BaseObject> entityBuffer = new List<BaseObject>();

        void ClearEntityBuffer()
        {
            entityBuffer.Clear();
        }

        public RenderContract[] GetRenderers()
        {
            List<RenderContract> retCtrc = new List<RenderContract>();
            Boolean updateEntBuf = false;
            foreach (BaseObject b in goList)
            {
                RenderComp r = b.GetComponent<RenderComp>();
                Transform t = b.GetComponent<Transform>();
                if (r != null)
                {
                    retCtrc.Add(new RenderContract(t, r));
                    if (!entityBuffer.Contains(b))
                    {
                        if (!b.HasComponent<WorldTile>())
                            entityBuffer.Add(b);
                        if (!updateEntBuf)
                            updateEntBuf = true;
                    }
                }
            }
            if (updateEntBuf)
                if (OnNewEntity != null)
                    OnNewEntity.Invoke(entityBuffer.ToArray());

            return retCtrc.ToArray();
        }

        public BaseObject[] GetGameObjects()
        {
            return goList.ToArray();
        }

        public void RegisterGameObject(BaseObject g)
        {
            goList.Add(g);
            g.Start();
        }

        int timerClear = 0;
        public void Update(float delta)
        {
            foreach (BaseObject g in goList)
            {
                g.Update(delta);
            }
            if(timerClear < 5 * 60)
            {
                timerClear++;
            }
            else
            {
                ClearEntityBuffer();
                timerClear = 0;
            }
        }
    }
}
