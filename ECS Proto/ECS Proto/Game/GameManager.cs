using ECS_Proto.Core;
using ECS_Proto.Game.Input;
using ECS_Proto.Game.Map;
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
        MapManager mapManager;
        PlayerManager playerManager;
        InputManager inputManager;
        GUIManager guiManager;

        public override void Start()
        {
            mapManager = new Map.MapManager();
            guiManager = new Game.GUIManager();
            inputManager = new Input.InputManager();
            playerManager = new Player.PlayerManager();
        }

        public override void Update(float delta)
        {
            playerManager.Update(delta);
        }
    }
}
