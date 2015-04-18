using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TileEngine.UI.Controls;
using Microsoft.Xna.Framework;
using TileEngine.Core;

namespace TileEngine.UI.Tests.Controls
{
    [TestClass]
    public class MapSizeLabelTest
    {
        private const int MAP_COLUMNS = 40;
        private const int MAP_ROWS = 60;
        private const int PARENT_X = 10;
        private const int PARENT_Y = 20;
        private const int X = 1;
        private const int Y = 2;
        private MapSizeLabel label;
        private FakeUIRenderer renderer;
        private TestContext testContextInstance;

        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        [TestInitialize]
        public void Setup()
        {
            renderer = new FakeUIRenderer();

            label = new MapSizeLabel(new Point(X, Y), new FakeMapProvider());
            label.Draw(PARENT_X, PARENT_Y, renderer);
        }

        [TestMethod]
        public void SizeOfMapShouldBeWritten()
        {
            Assert.AreEqual("Map size : " + MAP_ROWS + " x " + MAP_COLUMNS, renderer.CachedText);
        }

        [TestMethod]
        public void AssertPositionDrawn()
        {
            Assert.AreEqual(new Vector2(PARENT_X + X, PARENT_Y + Y), renderer.CachedPosition);
        }

        private class FakeUIRenderer : IUIRenderer
        {
            private string cachedText;
            private Vector2 cachedPosition;

            public string CachedText
            { get { return cachedText; } }

            public Vector2 CachedPosition
            { get { return cachedPosition; } }

            public void DrawText(string text, Vector2 position)
            {
                cachedText = text;
                cachedPosition = position;
            }
        }

        private class FakeMapProvider : IMapProvider
        {
            public Map Map
            {
                get { return new FakeMap(); }
            }
        }

        private class FakeMap : Map
        {
            public override int Columns
            { get { return MAP_COLUMNS; } }

            public override int Rows
            { get { return MAP_ROWS; } }
        }
    }
}
