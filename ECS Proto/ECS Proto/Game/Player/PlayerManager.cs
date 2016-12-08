using ECS_Proto.Core;
using ECS_Proto.Core.Component;
using ECS_Proto.Core.Injector;
using ECS_Proto.Core.Render;
using ECS_Proto.Game.Map;
using OpenTK;

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

        void OnInject(MapManager map, RenderManager render)
        {
            mapManager = map;
            playerInput = new PlayerInput(this);
            render.SetPlayerTransform(Player.GetComponent<Transform>());
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
