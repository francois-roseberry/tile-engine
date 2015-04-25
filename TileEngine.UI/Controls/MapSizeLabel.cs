using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using TileEngine.UI;
using TileEngine.Core;

namespace TileEngine.UI.Controls
{
    public class MapSizeLabel : IControl
    {
        private readonly Point position;
        private readonly IMapSizeProvider provider;

        public MapSizeLabel(Point position, IMapSizeProvider provider)
        {
            this.position = position;
            this.provider = provider;
        }

        public void Draw(IUIRenderer renderer)
        {
            String text = String.Format("Map size : {0} x {1}", provider.Rows, provider.Columns);
            renderer.DrawText(text, position);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override bool Equals(Object obj)
        {
            MapSizeLabel other = obj as MapSizeLabel;
            if (other == null)
                return false;
            else
                return position.Equals(other.position);
        }
    }
}
