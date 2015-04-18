using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using TileEngine.Core;

namespace TileEngine.Xna
{
    class DefaultCameraInput : ICameraInput
    {
        private int previousScrollValue = 0;

        public Point Position 
        { 
            get 
            {
                MouseState state = Mouse.GetState();
                return new Point(state.X, state.Y);
            } 
        }

        public ScrollingInput Scrolling
        {
            get
            {
                MouseState state = Mouse.GetState();
                int delta = state.ScrollWheelValue - previousScrollValue;
                previousScrollValue = state.ScrollWheelValue;
                if (delta > 0)
                {
                    return ScrollingInput.FORWARD;
                }

                if (delta < 0)
                {
                    return ScrollingInput.BACKWARD;
                }

                return ScrollingInput.NONE;
            }
        }
    }
}
