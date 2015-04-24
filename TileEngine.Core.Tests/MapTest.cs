using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TileEngine;
using TileEngine.Core;

namespace TileEngine.Core.Tests
{
    [TestClass]
    public class MapTest
    {
        private Map map;

        [TestInitialize]
        public void Setup() {
            map = new Map();
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
