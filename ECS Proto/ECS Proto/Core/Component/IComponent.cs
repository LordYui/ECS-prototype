using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECS_Proto.Core.Component
{
    abstract class IComponent
    {
        public virtual void Start() { }
        public virtual void Update() { }
    }
}
