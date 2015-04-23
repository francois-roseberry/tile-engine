using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using TileEngine.UI.Controls;
using TileEngine.Core;

namespace TileEngine.UI.Controls
{
    public class SidePanel : CompositeControl
    {
        private readonly Rectangle bounds;

        public SidePanel(Rectangle bounds, IMapProvider provider)
            : base(
                new Minimap(new Rectangle(10, 10, 200, 200)),
                new MapSizeLabel(new Point(30, 240), provider))
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
