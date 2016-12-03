using ECS_Proto.Core;
using ECS_Proto.Core.Component;
using ECS_Proto.Core.Injector;
using ECS_Proto.Game.Input;
using ECS_Proto.Game.Map;
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
        MapManager mapManager;
        public override void Start()
        {
            Player = new PlayerObject();
            this.Inject();
        }

        void OnInject(InputManager input, MapManager map)
        {
            input.RegisterInput(this, 255);
            plyT = Player.GetComponent<Transform>();

            mapManager = map;
        }

        Transform plyT;
        void OnKeyDown(Key k)
        {
            switch (k)
            {
                case Key.D:
                    plyT.Position += new OpenTK.Vector2(1, 0);
                    break;
                case Key.S:
                    plyT.Position += new OpenTK.Vector2(0, 1);
                    break;
                case Key.Q:
                    plyT.Position += new OpenTK.Vector2(-1, 0);
                    break;
                case Key.Z:
                    plyT.Position += new OpenTK.Vector2(0, -1);
                    break;
            }
        }

        public override void Update(float delta)
        {
        }
    }
}
