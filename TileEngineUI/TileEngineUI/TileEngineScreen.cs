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
        private readonly MapRenderer renderer;
        private readonly Map map;
        private Camera camera = Camera.Default(new DefaultCameraInput());
        private readonly MouseCursor cursor = new MouseCursor();
        private readonly MousePicker picker = new MousePicker();

        public TileEngineScreen(Game game)
            : base(game)
        {
            map = new Map();
            renderer = new MapRenderer(map);
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            picker.LoadContent(Game.Content);
            renderer.LoadContent(Game.Content);
            cursor.LoadContent(Game.Content);
        }

        /// <summary>
        /// Allows the game component to update itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        public override void Update(GameTime gameTime)
        {
            KeyboardState state = Keyboard.GetState();
            renderer.DrawDebugInfo = state.IsKeyDown(Keys.D);

            camera = camera.Update(Viewport, renderer);
            cursor.Update();
            picker.Update(camera);

            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {  
            RenderTarget2D target = renderer.Render(spriteBatch, camera, Viewport, picker.HoveredTileCoordinates);
            
            GraphicsDevice.Clear(Color.Black);
            spriteBatch.Begin();

            Rectangle destination = new Rectangle(0, 0, Viewport.Width, Viewport.Height);

            spriteBatch.Draw(target, destination, Color.White);
            cursor.Draw(spriteBatch);

            spriteBatch.End();

            base.Draw(gameTime);
        }

        private Size Viewport
        {
            get
            {
                int viewportWidth = GraphicsDevice.PresentationParameters.BackBufferWidth;
                int viewportHeight = GraphicsDevice.PresentationParameters.BackBufferHeight;
                return new Size(viewportWidth, viewportHeight);
            }
        }
    }
}
