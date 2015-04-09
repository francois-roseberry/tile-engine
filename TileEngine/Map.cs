﻿using System.Collections.Generic;

namespace TileEngine
{
    public class Map : IScrollable
    {      
        public const int TILE_WIDTH = 64;
        public const int TILE_HEIGHT = 64;

        public const int NB_TILES_PER_ROW = 20;
        public const int NB_TILES_PER_COLUMN = 50;

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

        public int Width { get { return (NB_TILES_PER_ROW - 1) * TILE_WIDTH; } }

        public int Height { get { return (NB_TILES_PER_COLUMN - 1) * TILE_HEIGHT/4; } }

        public List<Tile> Tiles { get { return tiles; } }
    }
}
