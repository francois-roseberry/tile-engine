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
    public class MenubarTest
    {
        private readonly Rectangle MENUBAR_BOUNDS = new Rectangle(0, 0, 100, 100);
        private FakeUIRenderer renderer;
        private Menubar menubar;

        [TestInitialize]
        public void Setup()
        {
            renderer = new FakeUIRenderer();

            menubar = new Menubar(MENUBAR_BOUNDS);
            menubar.Draw(renderer);
        }

        [TestMethod]
        public void AssertPositionDrawn()
        {
            Assert.AreEqual(MENUBAR_BOUNDS, renderer.CachedPanel);
        }
    }
}
