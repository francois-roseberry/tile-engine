using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TileEngine.Core;

namespace TileEngine.UI.Tests
{
    class FakeMapSizeProvider : IMapSizeProvider
    {
        private const int MAP_COLUMNS = 40;
        private const int MAP_ROWS = 60;

        public int Rows
        { get { return MAP_ROWS; } }

        public int Columns
        { get { return MAP_COLUMNS; } }       
    }
}
