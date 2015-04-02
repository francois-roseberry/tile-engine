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
        private readonly IMouseInput input;

        public int X { get { return x; } }
        public int Y { get { return y; } }

        public static Camera Default(IMouseInput input)
        {
            return new Camera(0, 0, input);
        }

        private Camera(int x, int y, IMouseInput input)
        {
            this.x = x;
            this.y = y;
            this.input = input;
        }

        public Camera Move(int dx, int dy)
        {
            return new Camera(x + dx, y + dy, input);
        }

        public Camera Update(int viewportWidth, int viewportHeight, IScrollable scrollable)
        {
            ScrollingDirection scrolling = GetScrollingDirection(viewportWidth, viewportHeight);
            switch (scrolling)
            {
                case ScrollingDirection.UPLEFT:
                    if (CanMoveUp() && CanMoveLeft())
                    {
                        return Move(-1, -1);
                    }
                    break;
                case ScrollingDirection.UP:
                    if (CanMoveUp())
                    {
                        return Move(0, -1);
                    }
                    break;
                case ScrollingDirection.UPRIGHT:
                    if (CanMoveUp() && CanMoveRight(scrollable.Height - viewportHeight))
                    {
                        return Move(1, -1);
                    }
                    break;
                case ScrollingDirection.DOWNLEFT:
                    if (CanMoveDown(scrollable.Height - viewportHeight) && CanMoveLeft())
                    {
                        return Move(-1, 1);
                    }
                    break;
                case ScrollingDirection.DOWN:
                    if (CanMoveDown(scrollable.Height - viewportHeight))
                    {
                        return Move(0, 1);
                    }
                    break;
                case ScrollingDirection.DOWNRIGHT:
                    if (CanMoveDown(scrollable.Height - viewportHeight) && CanMoveRight(scrollable.Width - viewportWidth))
                    {
                        return Move(1, 1);
                    }
                    break;
                case ScrollingDirection.LEFT:
                    if (CanMoveLeft())
                    {
                        return Move(-1, 0);
                    }
                    break;
                case ScrollingDirection.RIGHT:
                    if (CanMoveRight(scrollable.Width - viewportWidth))
                    {
                        return Move(1, 0);
                    }
                    break;
            }
            return this;
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