using ECS_Proto.Core;
using ECS_Proto.Core.Component;
using ECS_Proto.Core.Injector;
using ECS_Proto.Core.Render;

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
            transform.Position = new OpenTK.Vector2(80, 28);
            this.Inject();
        }
        
        float timer = 0;
        public override void Update(float delta)
        {
            
        }
    }
}
