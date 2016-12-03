using ECS_Proto.Core;
using ECS_Proto.Core.Component;
using ECS_Proto.Core.Injector;
using ECS_Proto.Core.Render;
using ECS_Proto.Game.Input;
using OpenTK.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECS_Proto.Game.Player
{
    class PlayerObject : BaseObject
    {
        Transform transform;
        public override void Start()
        {
            IComponent[] comps = this.AddComponentsFromArchetype("Player");
            RenderComp r = this.GetComponent<RenderComp>();
            r.Char = '@';
            transform = GetComponent<Transform>();
            this.Inject();
        }

        float timer = 0;
        public override void Update(float delta)
        {
            
        }
    }
}
