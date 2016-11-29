using ECS_Proto.Game.GameObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ECS_Proto.Core.Injector
{
    static class DepInjector
    {
        static List<object> injectableObjects = new List<object>();
        public static void RegisterInjectable(object o)
        {
            if(!injectableObjects.Contains(o))
                injectableObjects.Add(o);
        }

        public static void Inject(this BaseObject g, bool baseType = false)
        {
            Type t = g.GetType();
            if (baseType)
                t = t.BaseType;
            MethodInfo injMI = t.GetMethod("OnInject", BindingFlags.NonPublic | BindingFlags.Instance);
            if (injMI == null)
                return;
            List<object> toInj = new List<object>();
            foreach(ParameterInfo paramInf in injMI.GetParameters())
            {
                Type injT = paramInf.ParameterType;
                foreach (object o in injectableObjects)
                {
                    if (o.GetType() == injT)
                        toInj.Add(o);
                }
            }
            injMI.Invoke(g, toInj.ToArray());
        }
    }
}
