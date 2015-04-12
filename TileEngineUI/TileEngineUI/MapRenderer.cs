using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace TileEngine
{
    class MapRenderer : IScrollable
    {
        private const int TILE_WIDTH = 64;
        private const int TILE_HEIGHT = 64;
        private const int BASE_OFFSET_X = -1 * TILE_WIDTH / 2;
        private const int BASE_OFFSET_Y = -3 * TILE_HEIGHT / 4;
        private const int TILE_STEP_Y = 16;
        private const int ODD_ROW_X_OFFSET = 32;

        private readonly Map map;

        private readonly Texture2D tileset;
        private readonly Texture2D highlight;
        private readonly SpriteFont debugFont;

        public MapRenderer(Map map, ContentManager content)
        {
            Preconditions.CheckNotNull(map, "MapRenderer needs a map");
            Preconditions.CheckNotNull(content, "MapRenderer needs a ContentManager");

            this.map = map;

            tileset = content.Load<Texture2D>(@"Tilesets\base-64x64");
            highlight = content.Load<Texture2D>(@"highlight");
            debugFont = content.Load<SpriteFont>(@"debug");
        }

        public int Width
        { get { return (Map.NB_TILES_PER_ROW - 1) * TILE_WIDTH; /* -1 because first and last tiles are only half-drawn */ } }

        public int Height
        {
            get
            {
                int height = (int)(Map.NB_TILES_PER_COLUMN / 2) * TILE_HEIGHT / 2;
                if (Map.NB_TILES_PER_COLUMN % 2 == 0)
                {
                    height -= TILE_HEIGHT / 4;
                }

                return height;
            } 
        }

        public bool DrawDebugInfo { get; set; }

        public RenderTarget2D Render(SpriteBatch spriteBatch, Camera camera, Size viewportSize, Point hoveredTileCoordinates)
        {
            Preconditions.CheckNotNull(spriteBatch, "MapRenderer needs a spriteBatch to draw map");
            Preconditions.CheckNotNull(camera, "MapRenderer needs a camera to render map");
            Preconditions.CheckNotNull(viewportSize, "MapRenderer needs a viewport to render map");

            RenderTarget2D target = new RenderTarget2D(spriteBatch.GraphicsDevice,
                viewportSize.Width/camera.Zoom,
                viewportSize.Height/camera.Zoom);

            spriteBatch.GraphicsDevice.SetRenderTarget(target);
            spriteBatch.Begin();

            Rectangle viewport = new Rectangle(0, 0, viewportSize.Width, viewportSize.Height);

            foreach (Tile tile in map.Tiles)
            {               
                bool highlighted = hoveredTileCoordinates != null && (tile.X == hoveredTileCoordinates.X && tile.Y == hoveredTileCoordinates.Y);
                DrawTile(spriteBatch, camera, viewport, tile, highlighted);
            }

            spriteBatch.End();
            spriteBatch.GraphicsDevice.SetRenderTarget(null);

            return target;
        }

        private void DrawTile(SpriteBatch spriteBatch, Camera camera, Rectangle viewport, Tile tile, bool highlighted)
        {
            bool evenRow = tile.Y % 2 == 0;
            int x = BASE_OFFSET_X - camera.X + tile.X * TILE_WIDTH + (evenRow ? 0 : ODD_ROW_X_OFFSET);
            int y = BASE_OFFSET_Y - camera.Y + tile.Y * TILE_STEP_Y;

            Rectangle destination = new Rectangle(x, y, TILE_WIDTH, TILE_HEIGHT);

            if (!viewport.Intersects(destination))
            {
                return;
            }

            spriteBatch.Draw(
                tileset,
                destination,
                new Rectangle(0, 0, TILE_WIDTH, TILE_HEIGHT),
                Color.White);

            if (highlighted)
            {
                spriteBatch.Draw(
                    highlight,
                    new Rectangle(x, y + TILE_HEIGHT/2, TILE_WIDTH, TILE_HEIGHT / 2),
                    new Rectangle(0, 0, TILE_WIDTH, TILE_HEIGHT / 2),
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
