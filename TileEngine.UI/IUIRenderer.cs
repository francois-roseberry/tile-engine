using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace TileEngine.UI
{
    public interface IUIRenderer
    {
        IUIRenderer Translate(Point translation);
        void DrawText(string text, Point position);
        void FillRectangle(Rectangle bounds, Color color);
        void DrawPanel(Rectangle bounds);
    }
}
