using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TileEngine.UI.Controls;
using Microsoft.Xna.Framework;

namespace TileEngine.UI.Tests.Controls
{
    [TestClass]
    public class MinimapTest
    {
        private static readonly Rectangle MINIMAP_BOUNDS = new Rectangle(1, 2, 100, 100);
        private Minimap minimap;
        private FakeUIRenderer renderer;

        [TestInitialize]
        public void Setup()
        {
            renderer = new FakeUIRenderer();
            minimap = new Minimap(MINIMAP_BOUNDS);

            minimap.Draw(renderer);
        }

        [TestMethod]
        public void AssertPositionDrawn()
        {
            Assert.AreEqual(MINIMAP_BOUNDS, renderer.CachedRectangle);
        }

        [TestMethod]
        public void AssertColorDrawn()
        {
            Assert.AreEqual(Color.Black, renderer.CachedColor);
        }
    }
}
