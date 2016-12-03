using ECS_Proto.Core.Injector;
using ECS_Proto.Core.Render;
using ECS_Proto.Game.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECS_Proto.Core.GUI
{
    class UIManager : BaseObject
    {
        List<BaseObject> uiList;
        public UIManager()
        {
            DepInjector.RegisterInjectable(this);
            uiList = new List<BaseObject>();

            this.Inject();
        }

        public UIRenderStruct[] GetRenderers()
        {
            List<UIRenderStruct> rC = new List<UIRenderStruct>();
            foreach(BaseObject b in uiList)
            {
                //rC.Add(b.Write());
            }
            return rC.ToArray();
        }

        public void RegisterUIComp(BaseObject b)
        {

        }

        void OnInject(InputManager inMngr)
        {
            inMngr.RegisterInput(this);
        }
    }
}
