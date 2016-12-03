using ECS_Proto.Core.Component;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECS_Proto.Game.Components
{
    class Metadata : IComponent
    {
        public string Name;
        public string Description;

        public void Inspect()
        {
            Console.WriteLine("Name: " + Name);
            Console.WriteLine("Desc:" + Description);
        }
    }
}
