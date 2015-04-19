﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using TileEngine.UI;
using TileEngine.Core;

namespace TileEngine.UI.Controls
{
    public class MapSizeLabel : IControl
    {
        private readonly Point position;
        private readonly IMapProvider provider;
        private Point point;

        public MapSizeLabel(Point position, IMapProvider provider)
        {
            this.position = position;
            this.provider = provider;
        }

        public void Draw(int parentX, int parentY, IUIRenderer renderer)
        {
            String text = String.Format("Map size : {0} x {1}", provider.Map.Rows, provider.Map.Columns);
            renderer.DrawText(text, new Vector2(parentX + position.X, parentY + position.Y));
        }

        public override bool Equals(Object obj)
        {
            MapSizeLabel other = obj as MapSizeLabel;
            if (other == null)
                return false;
            else
                return position.Equals(other.position);
        }
    }
}
