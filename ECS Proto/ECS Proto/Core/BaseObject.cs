using ECS_Proto.Core.Component;
using ECS_Proto.Core.Injector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECS_Proto.Core
{
    abstract class BaseObject
    {
        List<IComponent> compList;
        GameObjectManager goManager;

        public virtual void Start() { }
        public virtual void Update(float delta) { }
        public BaseObject()
        {
            compList = new List<IComponent>();
            this.Inject(true);
        }

        void OnInject(GameObjectManager go)
        {
            goManager = go;
            goManager.RegisterGameObject(this);
        }

        public T AddComponent<T>() where T : IComponent
        {
            IComponent retComp = Activator.CreateInstance<T>();
            compList.Add(retComp);
            retComp.baseObject = this;
            retComp.Start();
            return (T)retComp;
        }

        public IComponent AddComponent(Type t)
        {
            IComponent retComp = Activator.CreateInstance(t) as IComponent;
            compList.Add(retComp);
            retComp.baseObject = this;
            retComp.Start();
            return retComp;
        }

        public void RequireComponent(params Type[] t)
        {

        }

        public T RequireComponent<T>() where T : IComponent
        {
            T comp = GetComponent<T>();
            if (comp == null)
                return AddComponent<T>();
            return comp;
        }

        public bool HasComponent<T>()
        {
            foreach (IComponent c in compList)
            {
                if (c.GetType() == typeof(T))
                    return true;
            }
            return false;
        }

        public T GetComponent<T>() where T : IComponent
        {
            foreach(IComponent c in compList)
            {
                if (c.GetType() == typeof(T))
                    return (T)c;
            }
            return null;
        }
    }

    static class BaseObjectE
    {
        static GameObjectManager goManager;
        public static void SetManager(GameObjectManager goM)
        {
            goManager = goM;
        }

        public static BaseObject[] GetByComponent<T>(this BaseObject b)
        {
            List<BaseObject> retBo = new List<Core.BaseObject>();
            foreach(BaseObject bO in goManager.GetGameObjects())
            {
                if (bO.HasComponent<T>())
                    retBo.Add(bO);
            }
            return retBo.ToArray();
        }
    }
}
