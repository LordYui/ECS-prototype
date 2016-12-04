using ECS_Proto.Core;
using ECS_Proto.Core.Component;
using ECS_Proto.Core.Render;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECS_Proto.Game.Components
{
    class Container : IComponent
    {
        public List<BaseObject> Content;
        public override void Start()
        {
            Content = new List<BaseObject>();
        }

        public void AddObject(BaseObject e)
        {
            Content.Add(e);
            if (e.HasComponent<RenderComp>())
                e.GetComponent<RenderComp>().Enabled = false;
        }
    }
}
