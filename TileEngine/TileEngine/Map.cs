using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace TileEngine
{
    public class Map : IScrollable
    {      
        public const int TILE_WIDTH = 64;
        public const int TILE_HEIGHT = 64;

        private const int NB_TILES_WIDTH = 20;
        private const int NB_TILES_HEIGHT = 50;

        private List<Tile> tiles = new List<Tile>();
        private readonly IMapRenderer renderer;    

        public Map(IMapRenderer renderer)
        {
            this.renderer = renderer;

            for (int x = 0; x < NB_TILES_WIDTH; x++)
            {
                for (int y = 0; y < NB_TILES_HEIGHT; y++)
                {
                    tiles.Add(new Tile(x, y, TileType.Grass));
                }
            }
        }

        public int Width { get { return (NB_TILES_WIDTH - 1) * TILE_WIDTH; } }

        public int Height { get { return (NB_TILES_HEIGHT - 1) * TILE_HEIGHT/4; } }

        public IMapRenderer Renderer { get { return renderer; } }

        public void LoadContent(ContentManager content)
        {
            renderer.LoadContent(content);
        }

        public void Draw(Camera camera, SpriteBatch spriteBatch)
        {
            foreach (Tile tile in tiles)
            {
                renderer.DrawTile(spriteBatch, camera, tile);             
            }
        }
    }
}
