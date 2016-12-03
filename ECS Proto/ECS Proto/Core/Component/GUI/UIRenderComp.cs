using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECS_Proto.Core.Component.GUI
{
    class UIRenderComp : IComponent
    {
        public virtual string[] Write()
        {
            return new string[] { };
        }
    }
}
