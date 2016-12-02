using ECS_Proto.Core;
using ECS_Proto.Core.Injector;
using ECS_Proto.Core.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ECS_Proto.Game.Input
{
    class InputManager : BaseObject
    {
        InputBridge inputBridge;
        FocusManager focusManager;
        public override void Start()
        {
            DepInjector.RegisterInjectable(this);
            this.Inject();
        }

        void OnInject(InputBridge inpb)
        {
            inputBridge = inpb;
            inputBridge.OnKeyDown += InputBridge_OnKeyDown;
            inputBridge.OnKeyPressed += InputBridge_OnKeyPressed;
            focusManager = new Input.FocusManager();
        }

        public void RegisterInput(BaseObject caller, int priority = 0)
        {
            Type t = caller.GetType();
            MethodInfo[] mInf = GetCallBacks(caller);
            if(mInf.Length > 0)
                focusManager.RegisterFocus(new Input.InputFocusStruct(caller, priority, mInf));
        }

        private MethodInfo[] GetCallBacks(BaseObject b)
        {
            List<MethodInfo> retArr = new List<MethodInfo>();
            Type t = b.GetType();
            MethodInfo onKeyDownCB = t.GetMethod("OnKeyDown", BindingFlags.NonPublic | BindingFlags.Instance);
            if (onKeyDownCB != null)
                retArr.Add(onKeyDownCB);
            return retArr.ToArray();
        }

        private void InputBridge_OnKeyPressed(OpenTK.KeyPressEventArgs e)
        {
            
        }

        private void InputBridge_OnKeyDown(OpenTK.Input.KeyboardKeyEventArgs e)
        {
            focusManager.ForwardInput(e.Key);
        }
    }
}
