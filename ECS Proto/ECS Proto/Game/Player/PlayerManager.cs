using ECS_Proto.Core;
using ECS_Proto.Game.GameObjects.World;
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
        Tree debugTree;
        public override void Start()
        {
            Player = new PlayerObject();
            debugTree = new Tree();
        }

        public override void Update()
        {
            base.Update();
        }
    }
}
