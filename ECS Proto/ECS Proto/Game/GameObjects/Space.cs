using ECS_Proto.Core;
using ECS_Proto.Core.Render;
using OpenTK.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECS_Proto.Game.GameObjects
{
    class Space : BaseObject
    {
        public override void Start()
        {
            this.AddComponentsFromArchetype("Floor");
            RenderComp rC = GetComponent<RenderComp>();
            rC.Char = '~';
            rC.Foreground = Color4.DarkGray;
        }
    }
}
