using ECS_Proto.Core.Component;
using ECS_Proto.Core.Injector;
using ECS_Proto.Core.Render;
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

        public RenderContract[] GetRenderers()
        {
            List<RenderContract> retCtrc = new List<RenderContract>();
            foreach (BaseObject b in goList)
            {
                RenderComp r = b.GetComponent<RenderComp>();
                Transform t = b.GetComponent<Transform>();
                if (r != null)
                    retCtrc.Add(new RenderContract(t, r));
            }

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

        public void Update()
        {
            foreach (BaseObject g in goList)
            {
                g.Update();
            }
        }
    }
}
