using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TileEngine
{
    public interface IMapProvider
    {
        Map Map { get; }
    }
}
