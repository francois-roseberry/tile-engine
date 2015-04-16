using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TileEngine.Controls
{
    class SidePanel
    {
        private readonly Rectangle bounds;
        private readonly Texture2D background;

        private readonly Minimap minimap;

        public SidePanel(Rectangle bounds, GraphicsDevice device)
        {
            this.bounds = bounds;
            this.minimap = new Minimap(new Rectangle(10, 10, 200, 200), device);
            background = new Texture2D(device, 1, 1);
            background.SetData(new Color[] { Color.White });
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(background, bounds, Color.DarkBlue);
            spriteBatch.Draw(background, new Rectangle(bounds.X + 1, bounds.Y + 1, bounds.Width - 2, bounds.Height - 2), Color.LightBlue);
            minimap.Draw(bounds.X, bounds.Y, spriteBatch);
            spriteBatch.End();
        }
    }
}
