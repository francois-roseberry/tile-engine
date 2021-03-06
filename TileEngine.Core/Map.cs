﻿using System.Collections.Generic;

namespace TileEngine.Core
{
    public class Map
    {
        public const int NB_TILES_PER_ROW = 60;
        public const int NB_TILES_PER_COLUMN = 60;

        private List<Tile> tiles = new List<Tile>();

        public Map()
        {
            for (int x = 0; x < NB_TILES_PER_ROW; x++)
            {
                for (int y = 0; y < NB_TILES_PER_COLUMN; y++)
                {
                    tiles.Add(new Tile(x, y, TileType.Grass));
                }
            }
        }

        public virtual int Rows { get { return NB_TILES_PER_COLUMN; } }

        public virtual int Columns { get { return NB_TILES_PER_ROW; } }

        public List<Tile> Tiles { get { return tiles; } }
    }
}
