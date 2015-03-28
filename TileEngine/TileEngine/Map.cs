using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace TileEngine
{
    public class Map : IDrawable
    {
        private List<Tile> tiles = new List<Tile>();
        private readonly IMapRenderer renderer;    

        public Map(IMapRenderer renderer)
        {
            this.renderer = renderer;

            for (int x = 0; x < 10; x++)
            {
                for (int y = 0; y < 10; y++)
                {
                    tiles.Add(new Tile(x, y));
                }
            }
        }

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
