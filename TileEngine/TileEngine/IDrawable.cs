using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;

namespace TileEngine
{
    interface IDrawable
    {
        void Draw(Camera camera, SpriteBatch spriteBatch);
    }
}
