using ECS_Proto.Core.Component;
using ECS_Proto.Core.GUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECS_Proto.Game.UI
{
    class MainMenu : IMenu
    {
        public override void Start()
        {
            GetComponent<GUIRender>().Render = "lolxdmdr GUI";
        }
    }
}
