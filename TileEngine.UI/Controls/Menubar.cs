using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace TileEngine.UI.Controls
{
    public class Menubar
    {
        private readonly Rectangle bounds;
        private readonly List<IControl> children = new List<IControl>();

        public Menubar(Rectangle bounds)
        {
            this.bounds = bounds;
            children.Add(new FileMenu(new Point(4, 4)));
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
