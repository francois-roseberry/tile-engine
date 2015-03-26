using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace TileEngine
{
    class DefaultMapRenderer : IMapRenderer
    {
        private Texture2D tileset;

        public void LoadContent(ContentManager content)
        {
            tileset = content.Load<Texture2D>(@"Tilesets\base-64x64");
        }

        public void DrawTile(SpriteBatch spriteBatch, int x, int y)
        {
             spriteBatch.Draw(
                tileset,
                new Rectangle(x, y, 64, 64),
                new Rectangle(0, 0, 64, 64),
                Color.White);                        
        }
    }
}
