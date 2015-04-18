using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TileEngine.Controls
{
    class Minimap
    {
        private readonly Rectangle bounds;

        public Minimap(Rectangle bounds)
        {
            this.bounds = bounds;
        }

        public void Draw(int parentX, int parentY, UIRenderer renderer)
        {
            renderer.FillRectangle(new Rectangle(bounds.X + parentX, bounds.Y + parentY, bounds.Width, bounds.Height), Color.Black);
        }
    }
}
