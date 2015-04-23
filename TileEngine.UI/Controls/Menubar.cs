using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace TileEngine.UI.Controls
{
    public class Menubar : CompositeControl
    {
        private readonly Rectangle bounds;
        private readonly List<IControl> children = new List<IControl>();

        public Menubar(Rectangle bounds)
            : base(new FileMenu(new Point(4, 4)))
        {
            this.bounds = bounds;
        }

        public override void Draw(IUIRenderer renderer)
        {
            renderer.DrawPanel(bounds);
            IUIRenderer childRenderer = renderer.Translate(bounds.Location);
            base.Draw(childRenderer);
        }
    }
}
