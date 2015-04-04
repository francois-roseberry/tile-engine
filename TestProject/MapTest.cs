using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TileEngine;

namespace TestProject
{
    /// <summary>
    /// Summary description for MapTest
    /// </summary>
    [TestClass]
    public class MapTest
    {
        private Map map;
        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
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
        public void Setup() {
            map = new Map();
        }

        [TestMethod]
        public void WidthShouldBeNumberOfTilesPerRowTimesTileWidth()
        {
            Assert.AreEqual((Map.NB_TILES_PER_ROW - 1) * Map.TILE_WIDTH, map.Width);
        }

        [TestMethod]
        public void HeightShouldBeNumberOfTilesPerColumnTimesQuarterOfTileHeight()
        {
            Assert.AreEqual((Map.NB_TILES_PER_COLUMN - 1) * Map.TILE_HEIGHT / 4, map.Height);
        }

        [TestMethod]
        public void ShouldHaveRightNumberOfTiles()
        {
            Assert.AreEqual(Map.NB_TILES_PER_ROW * Map.NB_TILES_PER_COLUMN, map.Tiles.Count);
        }

        [TestMethod]
        public void AllTilesShouldHaveGrassType()
        {
            Assert.IsTrue(map.Tiles.All(tile => tile.Type == TileType.Grass));
        }
    }
}
