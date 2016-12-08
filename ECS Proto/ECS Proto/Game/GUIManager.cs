using ECS_Proto.Core;
using ECS_Proto.Core.Injector;
using ECS_Proto.Game.Input;
using ECS_Proto.Game.UI;
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
        MainMenu mainMenu;
        public override void Start()
        {
            DepInjector.RegisterInjectable(this);
            mainMenu = new UI.MainMenu();
        }

        public void Init(InputManager mngr)
        {
            mngr.RegisterInput(this);
        }
    }
}
