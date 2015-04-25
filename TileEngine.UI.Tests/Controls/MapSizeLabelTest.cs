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
        private readonly Point POSITION = new Point(1, 2);
        private MapSizeLabel label;
        private FakeUIRenderer renderer;
        private FakeMapSizeProvider provider;
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
            provider = new FakeMapSizeProvider();

            label = new MapSizeLabel(POSITION, provider);
            label.Draw(renderer);
        }

        [TestMethod]
        public void SizeOfMapShouldBeWritten()
        {
            Assert.AreEqual("Map size : " + provider.Rows + " x " + provider.Columns, renderer.CachedText);
        }

        [TestMethod]
        public void AssertPositionDrawn()
        {
            Assert.AreEqual(POSITION, renderer.CachedPosition);
        }
    }
}
