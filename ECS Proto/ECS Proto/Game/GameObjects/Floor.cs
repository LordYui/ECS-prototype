﻿using ECS_Proto.Core;
using ECS_Proto.Core.Render;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECS_Proto.Game.GameObjects
{
    class Floor : BaseObject
    {
        public override void Start()
        {
            this.AddComponentsFromArchetype("Floor");
            GetComponent<RenderComp>().Char = '.';
        }
    }
}
