using ECS_Proto.Core;
using ECS_Proto.Core.Component;
using ECS_Proto.Core.Render;
using ECS_Proto.Game.Components;
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
            AddArchetype("Wall", BuildArchetypeHierarchy(new string[] { "WorldObject" }, typeof(Unmovable)));
            AddArchetype("Floor", BuildArchetypeHierarchy(new string[] { "WorldObject" }, typeof(Unmovable), typeof(Container)));
        }

        private static void AddArchetype(string n, params Type[] t)
        {
            compArchDict.Add(n, t);
        }

        private static Type[] BuildArchetypeHierarchy(string[] parents, params Type[] t)
        {
            List<Type> retTy = new List<Type>();
            foreach(string p in parents)
            {
                retTy.AddRange(GetArchetypeComponent(p));
            }
            foreach(Type ty in t)
            {
                retTy.Add(ty);
            }
            return retTy.ToArray();
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
