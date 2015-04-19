using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TileEngine.UI.Controls
{
    public class Minimap
    {
        private readonly Rectangle bounds;

        public Minimap(Rectangle bounds)
        {
            this.bounds = bounds;
        }

        public void Draw(int parentX, int parentY, IUIRenderer renderer)
        {
            renderer.FillRectangle(new Rectangle(bounds.X + parentX, bounds.Y + parentY, bounds.Width, bounds.Height), Color.Black);
        }
    }
}
