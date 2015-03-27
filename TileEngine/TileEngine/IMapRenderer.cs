using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace TileEngine
{
    public interface IMapRenderer
    {
        void LoadContent(ContentManager content);
        void DrawTile(SpriteBatch spriteBatch, Tile coords);
    }
}
