using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;

namespace TileEngine
{
    public class Camera
    {
        private enum ScrollingDirection
        {
            UPLEFT,
            LEFT,
            DOWNLEFT,
            DOWN,
            DOWNRIGHT,
            RIGHT,
            UPRIGHT,
            UP,
            NONE
        }

        private const int SCROLL_BUFFER = 50;
        private readonly int x;
        private readonly int y;
        private readonly int zoom;
        private readonly IMouseInput input;

        public int X { get { return x; } }
        public int Y { get { return y; } }
        public int Zoom { get { return zoom; } }

        public static Camera Default(IMouseInput input)
        {
            return new Camera(0, 0, 1, input);
        }

        private Camera(int x, int y, int zoom, IMouseInput input)
        {
            this.x = x;
            this.y = y;
            this.zoom = zoom;
            this.input = input;
        }

        public Camera SetPosition(int x, int y)
        {
            return new Camera(x, y, zoom, input);
        }

        public Camera SetZoom(int zoom)
        {
            int newZoom = Math.Max(Math.Min(zoom, 3), 1);
            return new Camera(x, y, zoom, input);
        }

        public Point ScreenToWorld(Point screenCoordinates)
        {
            return new Point(screenCoordinates.X + x, screenCoordinates.Y + y);
        }

        public Camera Update(int viewportWidth, int viewportHeight, IScrollable scrollable)
        {
            MouseScrolling mouseScrolling = input.Scrolling;
            int dz = 0;
            if (mouseScrolling == MouseScrolling.FORWARD)
            {
                dz = 1;
            }
            else if (mouseScrolling == MouseScrolling.BACKWARD)
            {
                dz = -1;
            }
            int dx = 0;
            int dy = 0;
            ScrollingDirection scrolling = GetScrollingDirection(viewportWidth, viewportHeight);
            switch (scrolling)
            {
                case ScrollingDirection.UPLEFT:
                    if (CanMoveUp() && CanMoveLeft())
                    {
                        dx = -1;
                        dy = -1;
                    }
                    break;
                case ScrollingDirection.UP:
                    if (CanMoveUp())
                    {
                        dy = -1;
                    }
                    break;
                case ScrollingDirection.UPRIGHT:
                    if (CanMoveUp() && CanMoveRight(scrollable.Height - viewportHeight))
                    {
                        dx = 1;
                        dy = -1;
                    }
                    break;
                case ScrollingDirection.DOWNLEFT:
                    if (CanMoveDown(scrollable.Height - viewportHeight) && CanMoveLeft())
                    {
                        dx = -1;
                        dy = 1;
                    }
                    break;
                case ScrollingDirection.DOWN:
                    if (CanMoveDown(scrollable.Height - viewportHeight))
                    {
                        dy = 1;
                    }
                    break;
                case ScrollingDirection.DOWNRIGHT:
                    if (CanMoveDown(scrollable.Height - viewportHeight) && CanMoveRight(scrollable.Width - viewportWidth))
                    {
                        dx = 1;
                        dy = 1;
                    }
                    break;
                case ScrollingDirection.LEFT:
                    if (CanMoveLeft())
                    {
                        dx = -1;
                    }
                    break;
                case ScrollingDirection.RIGHT:
                    if (CanMoveRight(scrollable.Width - viewportWidth))
                    {
                        dx = 1;
                    }
                    break;
            }
            return Move(dx, dy, dz);
        }

        private Camera Move(int dx, int dy, int dz)
        {
            int newZoom = Math.Max(Math.Min(zoom + dz, 3), 1);
            return new Camera(x + dx, y + dy, newZoom, input);
        }

        private bool CanMoveRight(int width)
        {
            return x < width;
        }

        private bool CanMoveLeft()
        {
            return x > 0;
        }

        private bool CanMoveDown(int height)
        {
            return y < height;
        }

        private bool CanMoveUp()
        {
            return y > 0;
        }

        private ScrollingDirection GetScrollingDirection(int viewportWidth, int viewportHeight)
        {
            ScrollingDirection scrolling = ScrollingDirection.NONE;
            Point position = input.Position;
            if (position.X < SCROLL_BUFFER)
            {
                scrolling = ScrollingDirection.LEFT;
            }
            else if (position.X > viewportWidth - SCROLL_BUFFER)
            {
                scrolling = ScrollingDirection.RIGHT;
            }
            if (position.Y < SCROLL_BUFFER)
            {
                if (scrolling == ScrollingDirection.LEFT)
                {
                    return ScrollingDirection.UPLEFT;
                }

                if (scrolling == ScrollingDirection.RIGHT)
                {
                    return ScrollingDirection.UPRIGHT;
                }

                return ScrollingDirection.UP;                
            }
            else if (position.Y > viewportHeight - SCROLL_BUFFER)
            {
                if (scrolling == ScrollingDirection.LEFT)
                {
                    return ScrollingDirection.DOWNLEFT;
                }

                if (scrolling == ScrollingDirection.RIGHT)
                {
                    return ScrollingDirection.DOWNRIGHT;
                }
                
                return ScrollingDirection.DOWN;              
            }

            return scrolling;
        }
    }
}