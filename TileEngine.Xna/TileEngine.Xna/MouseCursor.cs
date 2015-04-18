using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace TileEngine
{
    public class MouseCursor
    {
        private Texture2D cursor;
        private Vector2 position;

        public void LoadContent(ContentManager content)
        {
            cursor = content.Load<Texture2D>(@"cursor");
        }

        public void Update()
        {
            MouseState state = Mouse.GetState();
            position = new Vector2(state.X, state.Y);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(cursor, position, Color.White);
        }
    }
}
