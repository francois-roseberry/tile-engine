using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TileEngine.Core
{
    public interface IMapSizeProvider
    {
        int Rows { get; }
        int Columns { get; }
    }
}
