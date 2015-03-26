using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;


namespace TileEngine
{
    /// <summary>
    /// This is a game component that implements IUpdateable.
    /// </summary>
    public class UI : Microsoft.Xna.Framework.DrawableGameComponent
    {
        private SpriteBatch spriteBatch;
        private Texture2D tileset;
        private Texture2D cursor;
        private Vector2 mousePosition;

        public UI(Game game)
            : base(game)
        {
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            tileset = Game.Content.Load<Texture2D>(@"Tilesets\base-64x64");
            cursor = Game.Content.Load<Texture2D>(@"cursor");
        }

        /// <summary>
        /// Allows the game component to update itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        public override void Update(GameTime gameTime)
        {
            MouseState state = Mouse.GetState();
            mousePosition = new Vector2(state.X, state.Y);

            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();

            // Draw map
            for (int x = 0; x < 10; x++)
            {
                for (int y = 0; y < 10; y++)
                {
                    spriteBatch.Draw(
                        tileset,
                        new Rectangle(x * 64 + (y % 2 == 0 ? 0 : 32), y * 16, 64, 64),
                        new Rectangle(0, 0, 64, 64),
                        Color.White);
                }
            }

            // Draw mouse
            spriteBatch.Draw(cursor, mousePosition, Color.White);

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
