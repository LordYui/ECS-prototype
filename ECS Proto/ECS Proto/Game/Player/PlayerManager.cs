﻿using ECS_Proto.Core;
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
        public override void Start()
        {
            Player = new PlayerObject();
        }

        public override void Update(float delta)
        {
        }
    }
}
