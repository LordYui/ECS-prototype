using ECS_Proto.Core;
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

        public BaseObject GetMapAtPos(Vector2 v)
        {
            if (v.X > map.GetLength(0) || v.Y > map.GetLength(1) || v.X < 0 || v.Y < 0)
                throw new ArgumentOutOfRangeException();
            return map[(int)v.X, (int)v.Y];
        }

        public Tile GetTileAtPos(Vector2 v)
        {
            if (v.X > map.GetLength(0) || v.Y > map.GetLength(1) || v.X < 0 || v.Y < 0)
                throw new ArgumentOutOfRangeException();
            BaseObject bTile = map[(int)v.X, (int)v.Y];
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
