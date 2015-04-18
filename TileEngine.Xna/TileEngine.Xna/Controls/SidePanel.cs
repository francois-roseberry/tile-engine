using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using TileEngine.UI.Controls;

namespace TileEngine.Controls
{
    class SidePanel
    {
        private readonly Rectangle bounds;

        private readonly Minimap minimap;
        private readonly MapSizeLabel label;

        public SidePanel(Rectangle bounds, IMapProvider provider)
        {
            this.bounds = bounds;
            this.minimap = new Minimap(new Rectangle(10, 10, 200, 200));
            this.label = new MapSizeLabel(new Point(30, 240), provider);
        }

        public void Draw(UIRenderer renderer)
        {
            renderer.DrawPanel(bounds);
            minimap.Draw(bounds.X, bounds.Y, renderer);
            label.Draw(bounds.X, bounds.Y, renderer);
        }
    }
}
