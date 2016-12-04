using ECS_Proto.Core;
using ECS_Proto.Core.Component;
using ECS_Proto.Core.Injector;
using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECS_Proto.Game.Map
{
    class MapManager : BaseObject
    {
        MapLoader mapLoader;
        MapEntityManager mapEntManager;
        BaseObject[,] map;
        public override void Start()
        {
            mapLoader = new Map.MapLoader();
            map = mapLoader.LoadAndParseMap();
            mapEntManager = new Map.MapEntityManager();
            DepInjector.RegisterInjectable(this);
        }

        public bool IsPassThrough(Vector2 v, BaseObject caller = null)
        {
            Tile t = GetTileAtPos(v);
            if (!t.mapTile.GetComponent<Physic>().isPassThrough(caller))
                return false;
            foreach (BaseObject b in t.entitiesOnTile)
                if (!b.GetComponent<Physic>().isPassThrough(caller))
                    return false;
            return true;
        }

        public BaseObject GetObjectAtPos(Vector2 v)
        {
            foreach(BaseObject b in map)
            {
                if(b.GetComponent<Transform>()?.Position == v)
                {
                    return b;
                }
            }
            return null;
        }

        public Tile GetTileAtPos(Vector2 v)
        {
            if (v.X > map.GetLength(0) || v.Y > map.GetLength(1) || v.X < 0 || v.Y < 0)
                throw new ArgumentOutOfRangeException();
            BaseObject bTile = GetObjectAtPos(v);
            BaseObject[] eTile = mapEntManager.getEntitiesAtPosition(v);
            return new Tile(bTile, eTile);
        }
    }

    struct Tile
    {
        public BaseObject mapTile;
        public BaseObject[] entitiesOnTile;

        public Tile(BaseObject mT, BaseObject[] mE)
        {
            mapTile = mT;
            entitiesOnTile = mE;
        }
    }
}