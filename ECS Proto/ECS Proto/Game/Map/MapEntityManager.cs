using ECS_Proto.Core;
using ECS_Proto.Core.Component;
using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECS_Proto.Game.Map
{
    class MapEntityManager
    {
        List<BaseObject> mapEntities;
        public MapEntityManager()
        {
            GameObjectManager.OnNewEntity += GameObjectManager_OnNewEntity;
            mapEntities = new List<Core.BaseObject>();
        }

        public BaseObject[] getEntitiesAtPosition(Vector2 v)
        {
            return mapEntities.Where(mE => mE.GetComponent<Transform>().Position == v).ToArray();
        }

        public T[] getEntitiesOfT<T>()
        {
            return mapEntities.Where(e => e is T).Cast<T>().ToArray();
        }

        private void GameObjectManager_OnNewEntity(BaseObject[] b)
        {
            mapEntities.Clear();
            mapEntities.AddRange(b);
        }
    }
}
