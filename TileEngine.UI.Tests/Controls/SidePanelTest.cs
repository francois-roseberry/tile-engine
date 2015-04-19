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
    public class SidePanelTest
    {
        private readonly Rectangle SIDE_PANEL_BOUNDS = new Rectangle(1, 2, 100, 200);
        private FakeUIRenderer renderer;
        private SidePanel panel;

        [TestInitialize]
        public void Setup()
        {
            renderer = new FakeUIRenderer();

            panel = new SidePanel(SIDE_PANEL_BOUNDS, new FakeMapProvider());
            panel.Draw(renderer);
        }

        [TestMethod]
        public void MinimapShouldBeCreatedAtRightPlace()
        {
            Minimap minimap = new Minimap(new Rectangle(10, 10, 200, 200));

            Assert.IsTrue(panel.Children.Contains(minimap));
        }

        [TestMethod]
        public void MapSizeLabelShouldBeCreatedAtRightPlace()
        {
            MapSizeLabel label = new MapSizeLabel(new Point(30, 240), new FakeMapProvider());

            Assert.IsTrue(panel.Children.Contains(label));
        }

        [TestMethod]
        public void AssertPositionDrawn()
        {
            Assert.AreEqual(SIDE_PANEL_BOUNDS, renderer.CachedPanel);
        }
    }
}
