using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TileEngine.Core
{
    public interface IMapProvider
    {
        Map Map { get; }
    }
}
