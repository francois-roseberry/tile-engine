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
        private Point cachedPosition;
        private Rectangle cachedRectangle;
        private Color cachedColor;
        private Rectangle cachedPanel;

        public string CachedText
        { get { return cachedText; } }

        public Point CachedPosition
        { get { return cachedPosition; } }

        public Rectangle CachedRectangle
        { get { return cachedRectangle; } }

        public Color CachedColor
        { get { return cachedColor; } }

        public Rectangle CachedPanel
        { get { return cachedPanel; } }

        public IUIRenderer Translate(Point translation)
        {
            return new FakeUIRenderer();
        }

        public void DrawText(string text, Point position)
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
            cachedPanel = bounds;
        }
    }
}
