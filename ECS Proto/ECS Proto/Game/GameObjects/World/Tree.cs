using ECS_Proto.Core;
using ECS_Proto.Core.Component;
using ECS_Proto.Core.Render;
using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECS_Proto.Game.GameObjects.World
{
    class Tree : BaseObject
    {
        public override void Start()
        {
            this.AddComponentsFromArchetype("WorldObject");
            RenderComp r = this.GetComponent<RenderComp>();
            r.Char = (char)6;
            GetComponent<Transform>().Position = new Vector2(0, 5);
        }
    }
}
