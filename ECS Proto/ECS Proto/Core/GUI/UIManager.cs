using ECS_Proto.Core.Component;
using ECS_Proto.Core.Injector;
using ECS_Proto.Core.Render;
using ECS_Proto.Game.Input;
using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECS_Proto.Core.GUI
{
    class UIManager : BaseObject
    {
        List<IMenu> uiList;
        public UIManager()
        {
            DepInjector.RegisterInjectable(this);
            uiList = new List<IMenu>();

            this.Inject();
        }

        public UIRenderStruct GetRenderer()
        {
            foreach(IMenu b in uiList)
            {
                if (b.Open)
                {
                    return new GUI.UIRenderStruct(b.GetComponent<GUIRender>().Render, b.GetComponent<Transform>().Position);
                }
            }
            return new GUI.UIRenderStruct("", Vector2.Zero);
        }

        public void RegisterUIComp(BaseObject b)
        {
            if(b is IMenu)
                uiList.Add((IMenu)b);
        }

        void OnInject(InputManager inMngr)
        {
            inMngr.RegisterInput(this);
        }
    }
}
