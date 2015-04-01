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
    public class TileEngineScreen : Microsoft.Xna.Framework.DrawableGameComponent
    {
        private SpriteBatch spriteBatch;
        private Map map;
        private Camera camera = Camera.Default();
        private MouseCursor cursor = new MouseCursor();
        private MousePicker picker = new MousePicker();

        public TileEngineScreen(Game game)
            : base(game)
        {
            map = new Map(new DefaultMapRenderer());
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            picker.LoadContent(Game.Content);
            map.LoadContent(Game.Content);
            cursor.LoadContent(Game.Content);
        }

        /// <summary>
        /// Allows the game component to update itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        public override void Update(GameTime gameTime)
        {
            KeyboardState state = Keyboard.GetState();
            map.Renderer.DrawDebugInfo = state.IsKeyDown(Keys.D);

            int viewportWidth = GraphicsDevice.PresentationParameters.BackBufferWidth;
            int viewportHeight = GraphicsDevice.PresentationParameters.BackBufferHeight;
            camera = camera.Update(viewportWidth, viewportHeight, map);
            cursor.Update();
            picker.Update(camera);

            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();

            map.Draw(camera, spriteBatch, picker.HoveredTileCoordinates);
            cursor.Draw(spriteBatch);

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}