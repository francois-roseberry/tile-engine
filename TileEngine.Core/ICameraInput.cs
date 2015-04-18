using Microsoft.Xna.Framework;

namespace TileEngine.Core
{
    public enum ScrollingInput
    {
        NONE,
        FORWARD,
        BACKWARD
    }

    public interface ICameraInput
    {
        Point Position { get; }
        ScrollingInput Scrolling { get; }
    }
}
