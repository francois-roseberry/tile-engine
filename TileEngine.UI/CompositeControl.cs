using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TileEngine.UI
{
    public abstract class CompositeControl
    {
        private readonly List<IControl> children;

        public CompositeControl(params IControl[] children)
        {
            this.children = new List<IControl>(children);
        }

        public List<IControl> Children
        { get { return children; } }

        public virtual void Draw(IUIRenderer renderer)
        {
            foreach (IControl child in children)
            {
                child.Draw(renderer);
            }
        }
    }
}
