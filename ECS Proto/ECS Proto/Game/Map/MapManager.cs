using ECS_Proto.Core;
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
        BaseObject[,] map;
        public override void Start()
        {
            mapLoader = new Map.MapLoader();
            map = mapLoader.LoadAndParseMap();
        }
    }
}
