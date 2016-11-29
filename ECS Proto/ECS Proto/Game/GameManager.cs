using ECS_Proto.Core;
using ECS_Proto.Game.Input;
using ECS_Proto.Game.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECS_Proto.Game
{
    class GameManager : BaseObject
    {
        PlayerManager playerManager;
        InputManager inputManager;
        public override void Start()
        {
            playerManager = new Player.PlayerManager();
            inputManager = new Input.InputManager();
        }

        public override void Update(float delta)
        {
            playerManager.Update();
        }
    }
}
