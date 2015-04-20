using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using TileEngine.Core;

namespace TileEngine.Xna.Controls
{
    class MapViewport
    {
        private readonly MapRenderer renderer;
        private readonly Map map = new Map();
        private Camera camera = Camera.Default(new DefaultCameraInput());
        private readonly MousePicker picker;
        private Rectangle bounds;

        public MapViewport(Rectangle bounds, ContentManager content)
        {
            this.bounds = bounds;
            
            renderer = new MapRenderer(map, content);
            picker = new MousePicker(content);
            
        }

        public IMapProvider MapProvider { get { return renderer; } }

        public void Update()
        {
            KeyboardState state = Keyboard.GetState();
            renderer.DrawDebugInfo = state.IsKeyDown(Keys.D);

            camera = camera.Update(bounds, renderer);
            picker.Update(bounds.X, bounds.Y, camera);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            RenderTarget2D target = renderer.Render(spriteBatch, camera, new Size(bounds.Width, bounds.Height), picker.HoveredTileCoordinates);

            spriteBatch.Begin();

            spriteBatch.Draw(target, bounds, Color.White);

            spriteBatch.End();
        }
    }
}
