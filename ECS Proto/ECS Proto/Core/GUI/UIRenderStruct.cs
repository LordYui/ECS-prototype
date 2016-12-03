using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECS_Proto.Core.GUI
{
    struct UIRenderStruct
    {
        public string Text;
        public Vector2 Pos;

        public UIRenderStruct(string t, Vector2 p)
        {
            Text = t;
            Pos = p;
        }
    }
}
