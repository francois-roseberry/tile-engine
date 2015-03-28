using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace TileEngine
{
    class Viewport
    {
        private readonly IDrawable drawable;

        public Viewport(IDrawable drawable)
        {
            this.drawable = drawable;
        }

        public void Draw(Camera camera, SpriteBatch spriteBatch)
        {
            drawable.Draw(camera, spriteBatch);
        }
    }
}
