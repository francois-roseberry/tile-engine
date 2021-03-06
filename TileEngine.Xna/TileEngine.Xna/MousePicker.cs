﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using TileEngine.Core;

namespace TileEngine.Xna
{
    class MousePicker
    {
        private readonly Texture2D mouseMap;
        private Point hoveredTileCoordinates;

        public Point HoveredTileCoordinates { get { return hoveredTileCoordinates; } }

        public MousePicker(ContentManager content)
        {
            mouseMap = content.Load<Texture2D>("mousemap");
        }

        public void Update(int viewportX, int viewportY, Camera camera)
        {
            Preconditions.CheckNotNull(camera, "MousePicker needs a camera to be updated");

            MouseState state = Mouse.GetState();
            Point screenCoordinates = new Point(state.X - viewportX, state.Y - viewportY);
            Point worldCoordinates = camera.ScreenToWorld(screenCoordinates);
            hoveredTileCoordinates = WorldToTile(worldCoordinates);
        }

        private Point WorldToTile(Point worldCoordinates)
        {
            Point squareCoordinates = new Point(
               (int)(worldCoordinates.X / mouseMap.Width),
               ((int)(worldCoordinates.Y / mouseMap.Height)) * 2);

            int localPointX = worldCoordinates.X % mouseMap.Width;
            int localPointY = worldCoordinates.Y % mouseMap.Height;

            int dx = 0;
            int dy = 0;

            uint[] myUint = new uint[1];

            if (new Rectangle(0, 0, mouseMap.Width, mouseMap.Height).Contains(localPointX, localPointY))
            {
                mouseMap.GetData(0, new Rectangle(localPointX, localPointY, 1, 1), myUint, 0, 1);

                if (myUint[0] == 0xFF0000FF) // Red - Upper-Left
                {
                    dy = -1;
                }

                if (myUint[0] == 0xFF00FF00) // Green - Lower-Left
                {
                    dy = 1;
                }

                if (myUint[0] == 0xFF00FFFF) // Yellow - Upper-Right
                {
                    dx = 1;
                    dy = -1;
                }

                if (myUint[0] == 0xFFFF0000) // Blue - Lower-Right
                {
                    dx = 1;
                    dy = 1;
                }
            }

            squareCoordinates.X += dx;
            squareCoordinates.Y += dy + 1;

            return squareCoordinates;
        }
    }
}
