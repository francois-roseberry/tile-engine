using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace TileEngine.UI.Tests
{
    class FakeUIRenderer : IUIRenderer
    {
        private string cachedText;
        private Vector2 cachedPosition;
        private Rectangle cachedRectangle;
        private Color cachedColor;

        public string CachedText
        { get { return cachedText; } }

        public Vector2 CachedPosition
        { get { return cachedPosition; } }

        public Rectangle CachedRectangle
        { get { return cachedRectangle; } }

        public Color CachedColor
        { get { return cachedColor; } }

        public void DrawText(string text, Vector2 position)
        {
            cachedText = text;
            cachedPosition = position;
        }

        public void FillRectangle(Rectangle bounds, Color color)
        {
            cachedRectangle = bounds;
            cachedColor = color;
        }

        public void DrawPanel(Rectangle bounds)
        {
        }
    }
}
