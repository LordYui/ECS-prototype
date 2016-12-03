using ECS_Proto.Core;
using ECS_Proto.Core.Component;
using ECS_Proto.Core.Injector;
using ECS_Proto.Game.Input;
using ECS_Proto.Game.Map;
using OpenTK;
using OpenTK.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECS_Proto.Game.Player
{
    class PlayerManager : BaseObject
    {
        PlayerObject Player;
        PlayerInput playerInput;
        MapManager mapManager;
        public override void Start()
        {
            Player = new PlayerObject();
            plyT = Player.GetComponent<Transform>();
            this.Inject();
        }

        void OnInject(MapManager map)
        {
            mapManager = map;
            playerInput = new Game.Player.PlayerInput(this);
        }

        Transform plyT;
        public void MovePlayer(Vector2 targetPos)
        {
            if (mapManager.IsPassThrough(plyT.Position + targetPos, Player))
                plyT.Position += targetPos;
        }

        public override void Update(float delta)
        {
        }
    }
}
