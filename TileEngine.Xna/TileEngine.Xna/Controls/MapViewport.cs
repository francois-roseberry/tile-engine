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
        private Size size;

        public MapViewport(Size size, ContentManager content)
        {
            this.size = size;
            
            renderer = new MapRenderer(map, content);
            picker = new MousePicker(content);
            
        }

        public IMapProvider MapProvider { get { return renderer; } }

        public void Update()
        {
            KeyboardState state = Keyboard.GetState();
            renderer.DrawDebugInfo = state.IsKeyDown(Keys.D);

            camera = camera.Update(size, renderer);
            picker.Update(camera);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            RenderTarget2D target = renderer.Render(spriteBatch, camera, size, picker.HoveredTileCoordinates);

            spriteBatch.Begin();

            Rectangle destination = new Rectangle(0, 0, size.Width, size.Height);

            spriteBatch.Draw(target, destination, Color.White);

            spriteBatch.End();
        }
    }
}
