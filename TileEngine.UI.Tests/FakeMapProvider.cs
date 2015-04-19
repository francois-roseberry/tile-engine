using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TileEngine.Core;

namespace TileEngine.UI.Tests
{
    class FakeMapProvider : IMapProvider
    {
        private const int MAP_COLUMNS = 40;
        private const int MAP_ROWS = 60;

        public Map Map
        {
            get { return new FakeMap(); }
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
