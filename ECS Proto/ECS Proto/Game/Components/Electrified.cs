using ECS_Proto.Core.Component;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECS_Proto.Game.Components
{
    class Electrified : IComponent
    {
        float containedPower;
        float neededPower;

        float powerInput;
        float powerOutput;

        public float powerDistMult = 1;

        public Func<float, float> OnPowerIn;
    }
}
