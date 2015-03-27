using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace TileEngine
{
    public class Map
    {
        private readonly IMapRenderer renderer;    

        public Map(IMapRenderer renderer)
        {
            this.renderer = renderer;
        }

        public void LoadContent(ContentManager content)
        {
            renderer.LoadContent(content);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            for (int x = 0; x < 10; x++)
            {
                for (int y = 0; y < 10; y++)
                {
                    renderer.DrawTile(spriteBatch, new Point(x, y));
                }
            }
        }
    }
}
