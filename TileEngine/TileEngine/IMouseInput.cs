using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace TileEngine
{
    public enum MouseScrolling
    {
        NONE,
        FORWARD,
        BACKWARD
    }

    public interface IMouseInput
    {
        Point Position { get; }
        MouseScrolling Scrolling { get; }
    }
}
