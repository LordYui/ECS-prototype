using ECS_Proto.Core.Render;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECS_Proto.Core.Component.GUI
{
    class Label : UIRenderComp
    {
        public string Text;
        public override void Start()
        {

        }

        public override string[] Write()
        {
            return new string[] { Text };
        } 
    }
}
