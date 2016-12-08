using ECS_Proto.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using ECS_Proto.Game.GameObjects;
using OpenTK;
using ECS_Proto.Core.Component;
using ECS_Proto.Game.GameObjects.Ship;

namespace ECS_Proto.Game.Map
{
    class MapLoader
    {
        string Path = "map.txt";
        public BaseObject[,] LoadAndParseMap()
        {
            string[] mapLines = File.ReadAllLines(Path);
            BaseObject[,] retBo = new BaseObject[mapLines[0].Length, mapLines.Length];
            for (int y = 0; y < mapLines.Length; y++)
            {
                string line = mapLines[y];
                for (int x = 0; x < line.Length; x++)
                {
                    char c = line[x];
                    retBo[x, y] = GetTile(c, new Vector2(x, y));
                }
            }

            return retBo;
        }

        private BaseObject GetTile(char c, Vector2 pos)
        {
            BaseObject retBo = null;

            switch (c)
            {
                case '.':
                    retBo = new Floor();
                    break;
                case '#':
                    retBo = new Hull();
                    break;
                case '~':
                    retBo = new Space();
                    break;
                default:
                    return null;
            }
            retBo.GetComponent<Transform>().Position = pos;
            return retBo;
        }
    }
}