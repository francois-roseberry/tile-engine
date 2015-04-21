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
        private readonly SpriteBatch batch;
        private readonly Point translation;
        private readonly Texture2D blankTexture;
        private readonly SpriteFont font;

        public static UIRenderer Create(GraphicsDevice device, ContentManager content, SpriteBatch batch)
        {
            Texture2D blankTexture = new Texture2D(device, 1, 1);
            blankTexture.SetData(new Color[] { Color.White });
            SpriteFont font = content.Load<SpriteFont>(@"debug");

            return new UIRenderer(batch, Point.Zero, blankTexture, font);
        }

        private UIRenderer(SpriteBatch batch, Point translation, Texture2D blankTexture, SpriteFont font)
        {
            this.batch = batch;
            this.translation = translation;
            this.blankTexture = blankTexture;
            this.font = font;
        }

        public IUIRenderer Translate(Point translation)
        {
            Point newTranslation = new Point(translation.X + this.translation.X, translation.Y + this.translation.Y);
            return new UIRenderer(batch, newTranslation, blankTexture, font);
        }

        public void DrawText(String text, Point position)
        {
            batch.DrawString(font, text, new Vector2(position.X + translation.X, position.Y + translation.Y), Color.Black);
        }

        public void DrawPanel(Rectangle bounds)
        {
            batch.Draw(blankTexture, bounds, Color.DarkBlue);
            batch.Draw(blankTexture, new Rectangle(translation.X + bounds.X + 1, translation.Y + bounds.Y + 1, bounds.Width - 2, bounds.Height - 2), Color.LightBlue);
        }

        public void FillRectangle(Rectangle bounds, Color color)
        {
            batch.Draw(blankTexture, new Rectangle(translation.X + bounds.X, translation.Y + bounds.Y, bounds.Width, bounds.Height), Color.Black);
        }
    }
}
