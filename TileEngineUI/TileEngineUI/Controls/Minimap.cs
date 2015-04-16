using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TileEngine.Controls
{
    class Minimap
    {
        private readonly Rectangle bounds;
        private readonly Texture2D background;

        public Minimap(Rectangle bounds, GraphicsDevice device)
        {
            this.bounds = bounds;
            background = new Texture2D(device, 1, 1);
            background.SetData(new Color[] { Color.White });
        }

        public void Draw(int parentX, int parentY, SpriteBatch batch)
        {
            batch.Draw(background, new Rectangle(bounds.X + parentX, bounds.Y + parentY, bounds.Width, bounds.Height), Color.Black);
        }
    }
}
