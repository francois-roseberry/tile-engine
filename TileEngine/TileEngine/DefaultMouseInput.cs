using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace TileEngine
{
    class DefaultMouseInput : IMouseInput
    {
        public Point Position 
        { 
            get 
            {
                MouseState state = Mouse.GetState();
                return new Point(state.X, state.Y);
            } 
        }
    }
}
