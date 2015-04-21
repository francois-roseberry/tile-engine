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
    public class SidePanel
    {
        private readonly Rectangle bounds;
        private readonly List<IControl> children = new List<IControl>();

        public SidePanel(Rectangle bounds, IMapProvider provider)
        {
            this.bounds = bounds;
            children.Add(new Minimap(new Rectangle(10, 10, 200, 200)));
            children.Add(new MapSizeLabel(new Point(30, 240), provider));
        }

        public List<IControl> Children
        { get { return children; } }

        public void Draw(IUIRenderer renderer)
        {
            renderer.DrawPanel(bounds);
            IUIRenderer childRenderer = renderer.Translate(bounds.Location);
            foreach (IControl child in children)
            {
                child.Draw(childRenderer);
            }
        }
    }
}
