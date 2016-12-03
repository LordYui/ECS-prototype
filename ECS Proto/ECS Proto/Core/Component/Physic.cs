using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECS_Proto.Core.Component
{
    class Physic : IComponent
    {
        public bool PassThrough = true;
        public Func<BaseObject, bool> OnEnter;

        public bool isPassThrough(BaseObject b = null)
        {
            if (OnEnter != null)
            {
                if (b == null)
                    return PassThrough;
                return OnEnter(b);
            }
            else
                return PassThrough;
        }
    }
}
