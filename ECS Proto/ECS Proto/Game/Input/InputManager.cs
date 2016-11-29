using ECS_Proto.Core;
using ECS_Proto.Core.Injector;
using ECS_Proto.Core.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECS_Proto.Game.Input
{
    class InputManager : BaseObject
    {
        InputBridge inputBridge;

        public override void Start()
        {
            this.Inject();
        }

        void OnInject(InputBridge inpb)
        {
            inputBridge = inpb;
            inputBridge.OnKeyDown += InputBridge_OnKeyDown;
            inputBridge.OnKeyPressed += InputBridge_OnKeyPressed;
        }

        private void InputBridge_OnKeyPressed(OpenTK.KeyPressEventArgs e)
        {
            
        }

        private void InputBridge_OnKeyDown(OpenTK.Input.KeyboardKeyEventArgs e)
        {
            if(e.Key == OpenTK.Input.Key.D)
            {

            }
        }
    }
}
