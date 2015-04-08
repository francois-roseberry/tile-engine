using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TileEngine
{
    public class Size
    {
        private readonly int width;
        private readonly int height;

        public int Width { get { return width; } }
        public int Height { get { return height; } }

        public Size(int width, int height)
        {
            Preconditions.CheckArgument(width > 0, "Width must be > 0");
            Preconditions.CheckArgument(height > 0, "Height must be > 0");

            this.width = width;
            this.height = height;
        }
    }
}
