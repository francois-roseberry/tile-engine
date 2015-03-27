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
        private Map map;
        private Texture2D cursor;
        private Vector2 mousePosition;
        private Camera camera = new Camera();

        public UI(Game game)
            : base(game)
        {
            map = new Map(new DefaultMapRenderer());
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            map.LoadContent(Game.Content);
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

            map.Draw(camera, spriteBatch);

            // Draw mouse
            spriteBatch.Draw(cursor, mousePosition, Color.White);

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
