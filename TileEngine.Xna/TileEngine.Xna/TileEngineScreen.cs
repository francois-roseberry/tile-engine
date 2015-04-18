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
using TileEngine.Controls;


namespace TileEngine
{
    /// <summary>
    /// This is a game component that implements IUpdateable.
    /// </summary>
    public class TileEngineScreen : Microsoft.Xna.Framework.DrawableGameComponent
    {
        private SpriteBatch spriteBatch;
        private readonly MouseCursor cursor = new MouseCursor();
        private MapViewport viewport;
        private SidePanel panel;
        private UIRenderer renderer;

        public TileEngineScreen(Game game)
            : base(game)
        { }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            renderer = new UIRenderer(GraphicsDevice, Game.Content, spriteBatch);
            cursor.LoadContent(Game.Content);
            viewport = new MapViewport(Viewport, Game.Content);
            panel = new SidePanel(SidePanelBounds, viewport.MapProvider);
        }

        /// <summary>
        /// Allows the game component to update itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        public override void Update(GameTime gameTime)
        {
            cursor.Update();
            viewport.Update();

            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            viewport.Draw(spriteBatch);

            spriteBatch.Begin();
            panel.Draw(renderer);
         
            cursor.Draw(spriteBatch);
            spriteBatch.End();

            base.Draw(gameTime);
        }

        private Size Viewport
        {
            get
            {
                int viewportWidth = GraphicsDevice.PresentationParameters.BackBufferWidth - 220;
                int viewportHeight = GraphicsDevice.PresentationParameters.BackBufferHeight;
                return new Size(viewportWidth, viewportHeight);
            }
        }

        private Rectangle SidePanelBounds
        {
            get
            {
                int x = GraphicsDevice.PresentationParameters.BackBufferWidth - 220;
                int y = 0;
                int width = 220;
                int height = GraphicsDevice.PresentationParameters.BackBufferHeight;
                return new Rectangle(x, y, width, height);
            }
        }
    }
}
