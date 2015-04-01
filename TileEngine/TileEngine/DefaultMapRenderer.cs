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
        private const int BASE_OFFSET_X = -1 * Map.TILE_WIDTH / 2;
        private const int BASE_OFFSET_Y = -3 * Map.TILE_HEIGHT / 4;
        private const int TILE_STEP_Y = 16;
        private const int ODD_ROW_X_OFFSET = 32;

        private Texture2D tileset;
        private Texture2D highlight;
        private SpriteFont debugFont;

        public bool DrawDebugInfo { get; set; }

        public void LoadContent(ContentManager content)
        {
            tileset = content.Load<Texture2D>(@"Tilesets\base-64x64");
            highlight = content.Load<Texture2D>(@"highlight");
            debugFont = content.Load<SpriteFont>(@"debug");
        }

        public void DrawTile(SpriteBatch spriteBatch, Camera camera, Tile tile, bool highlighted)
        {
            bool evenRow = tile.Y % 2 == 0;
            int x = BASE_OFFSET_X - camera.X + tile.X * Map.TILE_WIDTH + (evenRow ? 0 : ODD_ROW_X_OFFSET);
            int y = BASE_OFFSET_Y - camera.Y + tile.Y * TILE_STEP_Y;

            spriteBatch.Draw(
                tileset,
                new Rectangle(x, y, Map.TILE_WIDTH, Map.TILE_HEIGHT),
                new Rectangle(0, 0, Map.TILE_WIDTH, Map.TILE_HEIGHT),
                Color.White);

            if (highlighted)
            {
                spriteBatch.Draw(
                    highlight,
                    new Vector2(x, y),
                    new Rectangle(0, 0, Map.TILE_WIDTH, Map.TILE_HEIGHT / 2),
                    Color.White * 0.3f);
            }

            if (DrawDebugInfo)
            {
                DrawCoords(spriteBatch, tile, x, y);
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
