using ECS_Proto.Core.Injector;
using ECS_Proto.Core.Render;
using OpenTK;
using OpenTK.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECS_Proto.Core.Input
{
    class InputBridge
    {
        public event OnKeyDownHandler OnKeyDown;
        public delegate void OnKeyDownHandler(KeyboardKeyEventArgs e);

        public event OnKeyPressedHandler OnKeyPressed;
        public delegate void OnKeyPressedHandler(KeyPressEventArgs e);

        RenderManager renderManager;
        public InputBridge(RenderManager rM)
        {
            renderManager = rM;
            DepInjector.RegisterInjectable(this);
            renderManager.consoleWindow.KeyDown += ConsoleWindow_KeyDown;
            renderManager.consoleWindow.KeyUp += ConsoleWindow_KeyUp;
            renderManager.consoleWindow.KeyPress += ConsoleWindow_KeyPress;
        }

        private void ConsoleWindow_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (OnKeyPressed != null)
                OnKeyPressed.Invoke(e);
        }

        private List<Key> pressedKeys = new List<Key>();

        private void ConsoleWindow_KeyUp(object sender, KeyboardKeyEventArgs e)
        {
            if (pressedKeys.Contains(e.Key))
                pressedKeys.Remove(e.Key);
        }

        private void ConsoleWindow_KeyDown(object sender, KeyboardKeyEventArgs e)
        {
            if (OnKeyDown != null)
                OnKeyDown.Invoke(e);
            if(!pressedKeys.Contains(e.Key))
                pressedKeys.Add(e.Key);
        }
    }
}
