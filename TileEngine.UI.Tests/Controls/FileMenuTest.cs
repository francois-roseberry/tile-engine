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
    public class FileMenuTest
    {
        private static readonly Point POSITION = new Point(1, 2);
        private FakeUIRenderer renderer;
        private FileMenu menu;

        [TestInitialize]
        public void Setup()
        {
            renderer = new FakeUIRenderer();

            menu = new FileMenu(POSITION);
            menu.Draw(renderer);
        }

        [TestMethod]
        public void AssertPositionDrawn()
        {
            Assert.AreEqual(POSITION, renderer.CachedPosition);
        }

        [TestMethod]
        public void AssertTextDrawn()
        {
            Assert.AreEqual("File", renderer.CachedText);
        }
    }
}
