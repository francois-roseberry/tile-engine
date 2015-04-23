using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TileEngine.UI.Controls
{
    public class Minimap : IControl
    {
        private readonly Rectangle bounds;

        public Minimap(Rectangle bounds)
        {
            this.bounds = bounds;
        }

        public void Draw(IUIRenderer renderer)
        {
            renderer.FillRectangle(bounds, Color.Black);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override bool Equals(Object obj)
        {
            Minimap other = obj as Minimap;
            if (other == null)
                return false;
            else
                return bounds.Equals(other.bounds);
        }
    }
}
