using ECS_Proto.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ECS_Proto.Game.Input
{
    struct InputFocusStruct
    {
        public int Priority;
        public BaseObject Sender;
        public MethodInfo[] methodCallbacks;
        
        public InputFocusStruct(BaseObject bo, int p, params MethodInfo[] m)
        {
            Sender = bo;
            Priority = p;
            methodCallbacks = m;
        }
    }
}
