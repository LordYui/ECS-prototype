using ECS_Proto.Core;
using ECS_Proto.Core.Component;
using ECS_Proto.Core.Render;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECS_Proto.Game
{
    static class CompArchetype
    {
        static Dictionary<string, Type[]> compArchDict = new Dictionary<string, Type[]>();
        static CompArchetype()
        {
            AddArchetype("Entity", typeof(RenderComp), typeof(Transform));
            AddArchetype("Player", GetArchetypeComponent("Entity"));
            AddArchetype("WorldObject", GetArchetypeComponent("Entity"));
        }

        public static void AddArchetype(string n, params Type[] t)
        {
            compArchDict.Add(n, t);
        }

        public static Type[] GetArchetypeComponent(string n)
        {
            Type[] r;
            if (compArchDict.TryGetValue(n, out r))
            {
                return r;
            }
            return null;
        }

        public static IComponent[] AddComponentsFromArchetype(this BaseObject bO, string n)
        {
            Type[] compT = GetArchetypeComponent(n);
            List<IComponent> retC = new List<IComponent>();
            if (compT == null)
                throw new ArgumentException("Invalid archetype name");

            foreach (Type t in compT)
            {
                retC.Add(bO.AddComponent(t));
            }

            return retC.ToArray();
        }
    }
}
