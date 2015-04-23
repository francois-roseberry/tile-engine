using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace TileEngine.UI.Controls
{
    public class FileMenu : IControl
    {
        private readonly Point position;

        public FileMenu(Point position)
        {
            this.position = position;
        }

        public void Draw(IUIRenderer renderer)
        {
            renderer.DrawText("File", position);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override bool Equals(Object obj)
        {
            FileMenu other = obj as FileMenu;
            if (other == null)
                return false;
            else
                return position.Equals(other.position);
        }
    }
}
