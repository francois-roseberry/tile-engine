using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace TileEngine.Controls
{
    class MapSizeLabel
    {
        private readonly Point position;
        private readonly IMapProvider provider;

        public MapSizeLabel(Point position, IMapProvider provider)
        {
            this.position = position;
            this.provider = provider;
        }

        public void Draw(int parentX, int parentY, UIRenderer renderer)
        {
            String text = String.Format("Map size : {0} x {1}", provider.Map.Rows, provider.Map.Columns);
            renderer.DrawText(text, new Vector2(parentX + position.X, parentY + position.Y));
        }
    }
}
