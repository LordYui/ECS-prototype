﻿using ECS_Proto.Core.Component;
using ECS_Proto.Game.GameObjects.Living;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECS_Proto.Game.Components.Living
{
    class Human : IComponent
    {
        public override void Start()
        {
            Internals cC = baseObject.RequireComponent<Internals>();
        }
    }
}
