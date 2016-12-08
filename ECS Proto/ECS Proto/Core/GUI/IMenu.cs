using ECS_Proto.Core.Component;
using ECS_Proto.Core.Injector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECS_Proto.Core.GUI
{
    abstract class IMenu : BaseObject
    {
        public bool Open;

        public IMenu()
        {
            this.AddComponent<GUIRender>();
            this.Inject(true);
        }

        void OnInject(UIManager uiMngr)
        {
            uiMngr.RegisterUIComp(this);
        }
    }
}
