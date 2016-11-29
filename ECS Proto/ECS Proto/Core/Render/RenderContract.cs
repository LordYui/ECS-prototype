using ECS_Proto.Core.Component;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECS_Proto.Core.Render
{
    struct RenderContract
    {
        public Transform Transform { get; private set; }
        public RenderComp Render { get; private set; }

        public RenderContract(Transform t, RenderComp r)
        {
            Transform = t;
            Render = r;
        }
    }
}
