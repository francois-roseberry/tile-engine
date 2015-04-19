using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TileEngine.UI
{
    public interface IControl
    {
        void Draw(int parentX, int parentY, IUIRenderer renderer);
    }
}
