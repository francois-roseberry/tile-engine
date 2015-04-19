using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace TileEngine.UI
{
    public interface IUIRenderer
    {
        void DrawText(string text, Vector2 position);
        void FillRectangle(Rectangle bounds, Color color);
    }
}
