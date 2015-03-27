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
        private const int TILE_WIDTH = 64;
        private const int TILE_HEIGHT = 64;
        private const int TILE_STEP_Y = 16;
        private const int ODD_ROW_X_OFFSET = 32;

        private Texture2D tileset;

        public void LoadContent(ContentManager content)
        {
            tileset = content.Load<Texture2D>(@"Tilesets\base-64x64");
        }

        public void DrawTile(SpriteBatch spriteBatch, Tile coords)
        {
            bool evenRow = coords.Y % 2 == 0;
            int x = coords.X * TILE_WIDTH + (evenRow ? 0 : ODD_ROW_X_OFFSET);
            int y = coords.Y * TILE_STEP_Y;

            spriteBatch.Draw(
                tileset,
                new Rectangle(x, y, TILE_WIDTH, TILE_HEIGHT),
                new Rectangle(0, 0, TILE_WIDTH, TILE_HEIGHT),
                Color.White);                        
        }
    }
}
