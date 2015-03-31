using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TileEngine
{
    public class Tile
    {
        private readonly int x;
        private readonly int y;
        private readonly TileType type;

        public Tile(int x, int y, TileType type)
        {
            this.x = x;
            this.y = y;
            this.type = type;
        }

        public int X { get { return x; } }
        public int Y { get { return y; } }
        public TileType Type { get { return type; } }
    }
}
