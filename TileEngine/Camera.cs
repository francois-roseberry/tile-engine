using System;
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
        private readonly ICameraInput input;

        public int X { get { return x; } }
        public int Y { get { return y; } }
        public int Zoom { get { return zoom; } }

        public static Camera Default(ICameraInput input)
        {
            Preconditions.CheckNotNull(input, "Camera needs an input");

            return new Camera(0, 0, 1, input);
        }

        private Camera(int x, int y, int zoom, ICameraInput input)
        {
            this.x = x;
            this.y = y;
            this.zoom = zoom;
            this.input = input;
        }

        public Camera SetPosition(int x, int y)
        {
            Preconditions.CheckArgument(x >= 0, "x must be >= 0");
            Preconditions.CheckArgument(y >= 0, "y must be >= 0");

            return new Camera(x, y, zoom, input);
        }

        public Point ScreenToWorld(Point screenCoordinates)
        {
            return new Point(screenCoordinates.X/zoom + x, screenCoordinates.Y/zoom + y);
        }

        public Camera Update(Size viewport, IScrollable scrollable)
        {
            Preconditions.CheckNotNull(viewport, "Camera needs a viewport to be updated");
            Preconditions.CheckNotNull(scrollable, "Camera needs an IScrollable to be updated");

            ScrollingInput mouseScrolling = input.Scrolling;
            int dz = 0;
            if (mouseScrolling == ScrollingInput.FORWARD)
            {
                dz = 1;
            }
            else if (mouseScrolling == ScrollingInput.BACKWARD)
            {
                dz = -1;
            }
            int dx = 0;
            int dy = 0;
            ScrollingDirection scrolling = GetScrollingDirection(viewport.Width, viewport.Height);
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
                    if (CanMoveUp() && CanMoveRight(scrollable.Width * zoom - viewport.Width))
                    {
                        dx = 1;
                        dy = -1;
                    }
                    break;
                case ScrollingDirection.DOWNLEFT:
                    if (CanMoveDown(scrollable.Height * zoom - viewport.Height) && CanMoveLeft())
                    {
                        dx = -1;
                        dy = 1;
                    }
                    break;
                case ScrollingDirection.DOWN:
                    if (CanMoveDown(scrollable.Height * zoom - viewport.Height))
                    {
                        dy = 1;
                    }
                    break;
                case ScrollingDirection.DOWNRIGHT:
                    if (CanMoveDown(scrollable.Height * zoom - viewport.Height) && CanMoveRight(scrollable.Width * zoom - viewport.Width))
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
                    if (CanMoveRight(scrollable.Width * zoom - viewport.Width))
                    {
                        dx = 1;
                    }
                    break;
            }
            return Move(dx, dy, dz, viewport);
        }

        private Camera Move(int dx, int dy, int dz, Size viewport)
        {
            int newZoom = Math.Max(Math.Min(zoom + dz, 2), 1);
            int newX = x + dx;    
            int newY = y + dy;
            if (newZoom - zoom > 0) // We've zoomed in
            {
                newX += viewport.Width * zoom / 4;
                newY += viewport.Height * zoom / 4;
            }
            else if (newZoom - zoom < 0) /// We've zoomed out
            {
                newX = Math.Max(newX - viewport.Width * zoom / 4, 0);
                newY = Math.Max(newY - viewport.Height * zoom / 4, 0);
            }
            return new Camera(newX, newY, newZoom, input);
        }

        private bool CanMoveRight(int width)
        {
            return x * zoom < width;
        }

        private bool CanMoveLeft()
        {
            return x > 0;
        }

        private bool CanMoveDown(int height)
        {
            return y * zoom < height;
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