using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace TileEngine
{
    public interface IMapRenderer
    {
        void LoadContent(ContentManager content);
        void DrawTile(SpriteBatch spriteBatch, int x, int y);
    }
}
