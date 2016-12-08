using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SunshineConsole;
using ECS_Proto.Core.Component;
using OpenTK.Graphics;
using ECS_Proto.Core.GUI;
using ECS_Proto.Core.Injector;

namespace ECS_Proto.Core.Render
{
    class RenderManager
    {
        GameObjectManager goManager;
        UIManager uiManager;
        Transform playerTransform;
        public ConsoleWindow consoleWindow;
        public RenderManager(GameObjectManager goM)
        {
            goManager = goM;
            consoleWindow = new ConsoleWindow(40, 60, "Test");
            DepInjector.RegisterInjectable(this);
        }

        public void SetUIManager(UIManager manager)
        {
            uiManager = manager;
        }

        public void SetPlayerTransform(Transform ply)
        {
            playerTransform = ply;
        }

        public void Update()
        {
            if (playerTransform == null) // No camera yet
                return;
            RenderContract[] renderBuf = goManager.GetRenderers();
            UIRenderStruct uiRender = uiManager.GetRenderer();
            
            ClearWindow();
            // Draw game
            foreach(RenderContract rC in renderBuf)
            {
                Transform t = rC.Transform;
                RenderComp r = rC.Render;

                int finalX = (int)t.Position.X - (int)playerTransform.Position.X + (60 / 2);
                int finalY = (int)t.Position.Y - (int)playerTransform.Position.Y + (26 / 2);

                if (finalY < 26 && finalX < 60)
                    consoleWindow.Write(finalY, finalX, r.Char, r.Foreground, r.Background);
            }

            // Draw UI on top
            consoleWindow.Write((int)uiRender.Pos.Y, (int)uiRender.Pos.X, uiRender.Text, Color4.White);

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