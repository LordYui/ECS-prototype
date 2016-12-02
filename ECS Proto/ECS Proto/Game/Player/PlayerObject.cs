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

        void OnInject(InputManager input)
        {
            input.RegisterInput(this, 255);
        }

        void OnKeyDown(Key k)
        {
            switch (k)
            {
                case Key.D:
                    transform.Position += new OpenTK.Vector2(1, 0);
                    break;
                case Key.S:
                    transform.Position += new OpenTK.Vector2(0, 1);
                    break;
                case Key.Q:
                    transform.Position += new OpenTK.Vector2(-1, 0);
                    break;
                case Key.Z:
                    transform.Position += new OpenTK.Vector2(0, -1);
                    break;
            }
        }

        float timer = 0;
        public override void Update(float delta)
        {
            
        }
    }
}
