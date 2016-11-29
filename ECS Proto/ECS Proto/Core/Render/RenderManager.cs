using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SunshineConsole;
using ECS_Proto.Core.Component;

namespace ECS_Proto.Core.Render
{
    class RenderManager
    {
        GameObjectManager goManager;
        public ConsoleWindow consoleWindow;
        public RenderManager(GameObjectManager goM)
        {
            goManager = goM;
            consoleWindow = new ConsoleWindow(40, 60, "Test");
        }

        public void Update()
        {
            RenderContract[] renderBuf = goManager.GetRenderers();
            foreach(RenderContract rC in renderBuf)
            {
                Transform t = rC.Transform;
                RenderComp r = rC.Render;
                consoleWindow.Write((int)t.Position.X, (int)t.Position.Y, r.Char, r.Foreground, r.Background);
            }
            consoleWindow.WindowUpdate();
        }
    }
}
