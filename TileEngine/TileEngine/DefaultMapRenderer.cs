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
        private const int BASE_OFFSET_X = -TILE_WIDTH / 2;
        private const int BASE_OFFSET_Y = -3 * TILE_HEIGHT / 4;
        private const int TILE_WIDTH = 64;
        private const int TILE_HEIGHT = 64;
        private const int TILE_STEP_Y = 16;
        private const int ODD_ROW_X_OFFSET = 32;

        private Texture2D tileset;
        private SpriteFont debugFont;

        public bool DrawDebugInfo { get; set; }

        public void LoadContent(ContentManager content)
        {
            tileset = content.Load<Texture2D>(@"Tilesets\base-64x64");
            debugFont = content.Load<SpriteFont>(@"debug");
        }

        public void DrawTile(SpriteBatch spriteBatch, Camera camera, Tile coords)
        {
            bool evenRow = coords.Y % 2 == 0;
            int x = BASE_OFFSET_X + camera.X + coords.X * TILE_WIDTH + (evenRow ? 0 : ODD_ROW_X_OFFSET);
            int y = BASE_OFFSET_Y + camera.Y + coords.Y * TILE_STEP_Y;

            spriteBatch.Draw(
                tileset,
                new Rectangle(x, y, TILE_WIDTH, TILE_HEIGHT),
                new Rectangle(0, 0, TILE_WIDTH, TILE_HEIGHT),
                Color.White);

            if (DrawDebugInfo)
            {
                DrawCoords(spriteBatch, coords, x, y);
            }
        }

        private void DrawCoords(SpriteBatch spriteBatch, Tile coords, int x, int y)
        {
            string message = String.Format("({0},{1})", coords.X, coords.Y);
            Vector2 position = new Vector2(x + 20, y + 40);
            spriteBatch.DrawString(debugFont, message, position, Color.White);
        }
    }
}
