using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace TileEngine
{
    class MapRenderer
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

        public RenderTarget2D DrawTileMap(SpriteBatch spriteBatch, Camera camera, Size viewportSize, Map map, Point hoveredTileCoordinates)
        {
            Preconditions.CheckNotNull(spriteBatch, "MapRenderer needs a spriteBatch to draw map");
            Preconditions.CheckNotNull(camera, "MapRenderer needs a camera to render map");
            Preconditions.CheckNotNull(map, "MapRenderer needs a map to render it");

            RenderTarget2D target = new RenderTarget2D(spriteBatch.GraphicsDevice,
                viewportSize.Width/camera.Zoom,
                viewportSize.Height/camera.Zoom);

            spriteBatch.GraphicsDevice.SetRenderTarget(target);
            spriteBatch.Begin();

            Rectangle viewport = new Rectangle(0, 0, viewportSize.Width, viewportSize.Height);

            foreach (Tile tile in map.Tiles)
            {               
                bool highlighted = (tile.X == hoveredTileCoordinates.X && tile.Y == hoveredTileCoordinates.Y);
                DrawTile(spriteBatch, camera, viewport, tile, highlighted);
            }

            spriteBatch.End();
            spriteBatch.GraphicsDevice.SetRenderTarget(null);

            return target;
        }

        private void DrawTile(SpriteBatch spriteBatch, Camera camera, Rectangle viewport, Tile tile, bool highlighted)
        {
            bool evenRow = tile.Y % 2 == 0;
            int x = BASE_OFFSET_X - camera.X + tile.X * Map.TILE_WIDTH + (evenRow ? 0 : ODD_ROW_X_OFFSET);
            int y = BASE_OFFSET_Y - camera.Y + tile.Y * TILE_STEP_Y;

            Rectangle destination = new Rectangle(x, y, Map.TILE_WIDTH, Map.TILE_HEIGHT);

            if (!viewport.Intersects(destination))
            {
                return;
            }

            spriteBatch.Draw(
                tileset,
                destination,
                new Rectangle(0, 0, Map.TILE_WIDTH, Map.TILE_HEIGHT),
                Color.White);

            if (highlighted)
            {
                spriteBatch.Draw(
                    highlight,
                    new Rectangle(x, y, Map.TILE_WIDTH, Map.TILE_HEIGHT / 2),
                    new Rectangle(0, 0, Map.TILE_WIDTH, Map.TILE_HEIGHT / 2),
                    Color.White * 0.3f);
            }

            if (DrawDebugInfo)
            {
                DrawCoords(spriteBatch, camera, tile, x, y);
            }
        }

        private void DrawCoords(SpriteBatch spriteBatch, Camera camera, Tile coords, int x, int y)
        {
            string message = String.Format("({0},{1})", coords.X, coords.Y);
            int textX = 20;
            int textY = 40;
            Vector2 position = new Vector2(x + textX, y + textY);
            spriteBatch.DrawString(debugFont, message, position, Color.White, 0, new Vector2(0, 0), 1, SpriteEffects.None, 1);
        }
    }
}
