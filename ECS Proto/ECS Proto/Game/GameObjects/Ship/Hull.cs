using ECS_Proto.Core;
using ECS_Proto.Core.Component;
using ECS_Proto.Core.Render;
using ECS_Proto.Game.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECS_Proto.Game.GameObjects.Ship
{
    class Hull : BaseObject
    {
        public override void Start()
        {
            this.AddComponentsFromArchetype("Wall");
            Metadata mC = this.GetComponent<Metadata>();
            mC.Name = "Ship hull";
            mC.Description = "Thick metal plates, just inbetween space and you.";
            Physic pC = this.GetComponent<Physic>();
            pC.PassThrough = true;
            RenderComp rC = this.GetComponent<RenderComp>();
            rC.Char = '#';
        }
    }
}
