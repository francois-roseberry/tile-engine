using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace TileEngine
{
    public interface IMouseInput
    {
        Point Position { get; }
    }
}
