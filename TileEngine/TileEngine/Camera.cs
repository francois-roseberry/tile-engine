using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TileEngine
{
    public class Camera
    {
        private readonly int x;
        private readonly int y;

        public static Camera Default()
        {
            return new Camera(0, 0);
        }

        private Camera(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public Camera Move(int dx, int dy)
        {
            return new Camera(x + dx, y + dy);
        }

        public int X { get { return x; } }
        public int Y { get { return y; } }
    }
}
