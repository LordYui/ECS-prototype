using ECS_Proto.Core;
using ECS_Proto.Game.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECS_Proto.Game.GameObjects
{
    class Wire : BaseObject
    {
        public override void Start()
        {
            this.AddComponentsFromArchetype("Entity");
            Electrified e = this.AddComponent<Electrified>();
            e.powerDistMult = 0.95f;
            e.OnPowerIn = pIn => pIn * e.powerDistMult;
        }
    }
}
