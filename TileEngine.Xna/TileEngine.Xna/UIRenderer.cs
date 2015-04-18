using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using TileEngine.UI;

namespace TileEngine
{
    class UIRenderer : IUIRenderer
    {
        private readonly Texture2D blankTexture;
        private readonly SpriteFont font;
        private readonly SpriteBatch batch;

        public UIRenderer(GraphicsDevice device, ContentManager content, SpriteBatch batch)
        {
            blankTexture = new Texture2D(device, 1, 1);
            blankTexture.SetData(new Color[] { Color.White });
            font = content.Load<SpriteFont>(@"debug");
            this.batch = batch;
        }

        public void DrawText(String text, Vector2 position)
        {
            batch.DrawString(font, text, position, Color.Black);
        }

        public void DrawPanel(Rectangle bounds)
        {
            batch.Draw(blankTexture, bounds, Color.DarkBlue);
            batch.Draw(blankTexture, new Rectangle(bounds.X + 1, bounds.Y + 1, bounds.Width - 2, bounds.Height - 2), Color.LightBlue);
        }

        public void FillRectangle(Rectangle rectangle, Color color)
        {
            batch.Draw(blankTexture, rectangle, Color.Black);
        }
    }
}
