using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SunshineConsole;
using ECS_Proto.Core.Component;
using OpenTK.Graphics;

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
            ClearWindow();
            foreach(RenderContract rC in renderBuf)
            {
                Transform t = rC.Transform;
                RenderComp r = rC.Render;
                consoleWindow.Write((int)t.Position.Y, (int)t.Position.X, r.Char, r.Foreground, r.Background);
            }
            consoleWindow.WindowUpdate();
        }

        void ClearWindow()
        {
            for(int x = 0; x < consoleWindow.Cols; x++)
            {
                for (int y = 0; y < consoleWindow.Rows; y++)
                {
                    consoleWindow.Write(y, x, ' ', Color4.Black);
                }
            }
        }
    }
}
