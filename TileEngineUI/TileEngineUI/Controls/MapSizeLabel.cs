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
        private readonly SpriteFont font;
        private readonly IMapProvider provider;

        public MapSizeLabel(Point position, ContentManager content, IMapProvider provider)
        {
            this.position = position;
            this.provider = provider;
            font = content.Load<SpriteFont>(@"debug");
        }

        public void Draw(int parentX, int parentY, SpriteBatch batch)
        {
            String text = String.Format("Map size : {0} x {1}", provider.Map.Rows, provider.Map.Columns);
            batch.DrawString(font, text, new Vector2(parentX + position.X, parentY + position.Y), Color.Black);
        }
    }
}
