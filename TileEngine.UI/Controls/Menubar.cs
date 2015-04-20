using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace TileEngine.UI.Controls
{
    public class Menubar
    {
        private readonly Rectangle bounds;

        public Menubar(Rectangle bounds)
        {
            this.bounds = bounds;
        }

        public void Draw(IUIRenderer renderer)
        {
            renderer.DrawPanel(bounds);
        }
    }
}
