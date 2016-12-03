using ECS_Proto.Core;
using ECS_Proto.Core.Component;
using ECS_Proto.Core.Injector;
using ECS_Proto.Game.Input;
using OpenTK;
using OpenTK.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECS_Proto.Game.Player
{
    class PlayerInput : BaseObject
    {
        PlayerManager playerManager;
        public PlayerInput(PlayerManager mngr)
        {
            playerManager = mngr;
            this.Inject();
        }

        void OnInject(InputManager inMngr)
        {
            inMngr.RegisterInput(this, 255);
        }

        void OnKeyDown(Key k)
        {
            Vector2 targetPos = Vector2.Zero;
            switch (k)
            {
                case Key.D:
                    targetPos = new Vector2(1, 0);
                    break;
                case Key.S:
                    targetPos = new Vector2(0, 1);
                    break;
                case Key.Q:
                case Key.A:
                    targetPos = new Vector2(-1, 0);
                    break;
                case Key.Z:
                case Key.W:
                    targetPos = new Vector2(0, -1);
                    break;
                default:
                    return;
            }

            playerManager.MovePlayer(targetPos);
        }
    }
}
