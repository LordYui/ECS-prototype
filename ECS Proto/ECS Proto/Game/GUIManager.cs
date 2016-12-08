using ECS_Proto.Core;
using ECS_Proto.Core.Injector;
using ECS_Proto.Game.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECS_Proto.Game
{
    class GUIManager : BaseObject
    {
        public bool isFocused = false;
        public override void Start()
        {
            DepInjector.RegisterInjectable(this);
        }

        public void Init(InputManager mngr)
        {
            mngr.RegisterInput(this);
        }
    }
}
