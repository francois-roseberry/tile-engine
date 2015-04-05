using TileEngine;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Microsoft.Xna.Framework;

namespace TestProject
{
    [TestClass]
    public class CameraTest
    {
        private const int VIEWPORT_WIDTH = 200;
        private const int VIEWPORT_HEIGHT = 200;

        private TestContext testContextInstance;
        private FakeMouseInput input;
        private FakeScrollable scrollable;
        private Camera camera;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        [TestInitialize]
        public void Setup()
        {
            input = new FakeMouseInput();
            scrollable = new FakeScrollable();
            scrollable.Width = VIEWPORT_WIDTH * 5;
            scrollable.Height = VIEWPORT_HEIGHT * 5;
            camera = Camera.Default(input);
        }

        [TestMethod]
        public void DefaultCameraShouldBePositionedAtOrigin()
        {
            Assert.AreEqual(0, camera.X);
            Assert.AreEqual(0, camera.Y);
            Assert.AreEqual(1, camera.Zoom);
        }

        [TestMethod]
        public void WhenMouseIsInTheMiddleShouldNotScroll()
        {
            for (int x = 50; x < VIEWPORT_WIDTH - 50; x++)
            {
                for (int y = 50; y < VIEWPORT_HEIGHT - 50; y++)
                {
                    input.Position = new Point(x, y);

                    Camera movedCamera = camera.Update(VIEWPORT_WIDTH, VIEWPORT_HEIGHT, scrollable);

                    Assert.AreEqual(camera.X, movedCamera.X, "Should not scroll left or right");
                    Assert.AreEqual(camera.Y, movedCamera.Y, "Should not scroll down or up");
                }
            }
        }

        [TestMethod] 
        public void WhenMouseIsInRightZoneAndCanScrollRightThenShouldScroll()
        {
            for (int y = 50; y <= VIEWPORT_HEIGHT - 50; y++)
            {
                for (int x = VIEWPORT_WIDTH - 50 + 1; x < VIEWPORT_WIDTH; x++)
                {
                    input.Position = new Point(x, y);

                    Camera movedCamera = camera.Update(VIEWPORT_WIDTH, VIEWPORT_HEIGHT, scrollable);

                    Assert.AreEqual(camera.X + 1, movedCamera.X, "Should scroll right");
                    Assert.AreEqual(camera.Y, movedCamera.Y, "Should not scroll down or up");
                }
            }

            scrollable.Width = VIEWPORT_WIDTH;
            Camera newCamera = camera.Update(VIEWPORT_WIDTH, VIEWPORT_HEIGHT, scrollable);

            Assert.AreEqual(camera.X, newCamera.X, "Should not scroll right because map is at maximum right");
            Assert.AreEqual(camera.Y, newCamera.Y, "Should not scroll down or up");
        }

        [TestMethod]
        public void WhenMouseIsInLeftZoneThenShouldScroll()
        {
            camera = camera.SetPosition(20, 20);
            for (int y = 50; y <= VIEWPORT_HEIGHT - 50; y++)
            {
                for (int x = 0; x < 50; x++)
                {
                    input.Position = new Point(x, y);

                    Camera moved = camera.Update(VIEWPORT_WIDTH, VIEWPORT_HEIGHT, scrollable);

                    Assert.AreEqual(camera.X - 1, moved.X, "Should scroll left");
                    Assert.AreEqual(camera.Y, moved.Y, "Should not scroll up or down");
                }
            }

            camera = camera.SetPosition(0, 0);
            Camera newCamera = camera.Update(VIEWPORT_WIDTH, VIEWPORT_HEIGHT, scrollable);

            Assert.AreEqual(camera.X, newCamera.X, "Should not scroll left because map is already at maximum left");
            Assert.AreEqual(camera.Y, newCamera.Y, "Should not scroll down or up");
        }

        [TestMethod]
        public void WhenMouseIsInTopZoneThenShouldScroll()
        {
            camera = camera.SetPosition(20, 20);
            for (int x = 50; x <= VIEWPORT_WIDTH - 50; x++)
            {
                for (int y = 0; y < 50; y++)
                {
                    input.Position = new Point(x, y);

                    Camera moved = camera.Update(VIEWPORT_WIDTH, VIEWPORT_HEIGHT, scrollable);

                    Assert.AreEqual(camera.X, moved.X, "Should not scroll left or right");
                    Assert.AreEqual(camera.Y - 1, moved.Y, "Should scroll up");
                }
            }

            camera = camera.SetPosition(0, 0);
            Camera newCamera = camera.Update(VIEWPORT_WIDTH, VIEWPORT_HEIGHT, scrollable);

            Assert.AreEqual(camera.X, newCamera.X, "Should not scroll left or right");
            Assert.AreEqual(camera.Y, newCamera.Y, "Should not scroll or up because map is already at top");
        }

        [TestMethod]
        public void WhenMouseIsInBottomZoneThenShouldScroll()
        {
            for (int x = 50; x <= VIEWPORT_WIDTH - 50; x++)
            {
                for (int y = VIEWPORT_HEIGHT - 50 + 1; y < VIEWPORT_HEIGHT; y++)
                {
                    input.Position = new Point(x, y);

                    Camera moved = camera.Update(VIEWPORT_WIDTH, VIEWPORT_HEIGHT, scrollable);

                    Assert.AreEqual(camera.X, moved.X, "Should not scroll left or right");
                    Assert.AreEqual(camera.Y + 1, moved.Y, "Should scroll down");
                }
            }

            scrollable.Height = VIEWPORT_HEIGHT;
            Camera newCamera = camera.Update(VIEWPORT_WIDTH, VIEWPORT_HEIGHT, scrollable);

            Assert.AreEqual(camera.X, newCamera.X, "Should not scroll left or right");
            Assert.AreEqual(camera.Y, newCamera.Y, "Should not scroll down because map is already at bottom");
        }

        [TestMethod]
        public void WhenMouseIsInTopLeftCornerThenShouldScroll()
        {
            camera = camera.SetPosition(20, 20);
            for (int x = 0; x < 50; x++)
            {
                for (int y = 0; y < 50; y++)
                {
                    input.Position = new Point(x, y);

                    Camera moved = camera.Update(VIEWPORT_WIDTH, VIEWPORT_HEIGHT, scrollable);

                    Assert.AreEqual(camera.X - 1, moved.X, "Should scroll left");
                    Assert.AreEqual(camera.Y - 1, moved.Y, "Should scroll up");
                }
            }

            camera = camera.SetPosition(0, 0);
            Camera newCamera = camera.Update(VIEWPORT_WIDTH, VIEWPORT_HEIGHT, scrollable);

            Assert.AreEqual(camera.X, newCamera.X, "Should not scroll left because map is already at maximum left");
            Assert.AreEqual(camera.Y, newCamera.Y, "Should not scroll up because map is already at top");
        }

        [TestMethod] 
        public void WhenMouseIsInTopRightCornerThenShouldScroll()
        {
            camera = camera.SetPosition(20, 20);
            for (int x = VIEWPORT_WIDTH - 50 + 1; x < VIEWPORT_WIDTH; x++)
            {
                for (int y = 0; y < 50; y++)
                {
                    input.Position = new Point(x, y);

                    Camera moved = camera.Update(VIEWPORT_WIDTH, VIEWPORT_HEIGHT, scrollable);

                    Assert.AreEqual(camera.X + 1, moved.X, "Should scroll right");
                    Assert.AreEqual(camera.Y - 1, moved.Y, "Should scroll up");
                }
            }

            camera = camera.SetPosition(0, 0);
            Camera newCamera = camera.Update(VIEWPORT_WIDTH, VIEWPORT_HEIGHT, scrollable);

            Assert.AreEqual(camera.X, newCamera.X, "Should not scroll right because map is already at maximum right");
            Assert.AreEqual(camera.Y, newCamera.Y, "Should not scroll up because map is already at top");
        }

        [TestMethod]
        public void WhenMouseInInBottomLeftCornerThenShouldScroll()
        {
            camera = camera.SetPosition(20, 20);
            for (int x = 0; x < 50; x++)
            {
                for (int y = VIEWPORT_HEIGHT - 50 + 1; y < VIEWPORT_HEIGHT; y++)
                {
                    input.Position = new Point(x, y);

                    Camera moved = camera.Update(VIEWPORT_WIDTH, VIEWPORT_HEIGHT, scrollable);

                    Assert.AreEqual(camera.X - 1, moved.X, "Should scroll left");
                    Assert.AreEqual(camera.Y + 1, moved.Y, "Should scroll down");
                }
            }

            camera = camera.SetPosition(0, 0);
            scrollable.Height = VIEWPORT_HEIGHT;
            Camera newCamera = camera.Update(VIEWPORT_WIDTH, VIEWPORT_HEIGHT, scrollable);

            Assert.AreEqual(camera.X, newCamera.X, "Should not scroll left because map is already at maximum left");
            Assert.AreEqual(camera.Y, newCamera.Y, "Should not scroll down because map is already at bottom");
        }

        [TestMethod]
        public void WhenMouseIsInBottomRightCornerThenShouldScroll()
        {
            for (int x = VIEWPORT_WIDTH - 50 + 1; x < VIEWPORT_WIDTH; x++)
            {
                for (int y = VIEWPORT_HEIGHT - 50 + 1; y < VIEWPORT_HEIGHT; y++)
                {
                    input.Position = new Point(x, VIEWPORT_HEIGHT - 40);

                    Camera moved = camera.Update(VIEWPORT_WIDTH, VIEWPORT_HEIGHT, scrollable);

                    Assert.AreEqual(camera.X + 1, moved.X, "Should scroll right");
                    Assert.AreEqual(camera.Y + 1, moved.Y, "Should scroll up");
                }
            }

            camera = camera.SetPosition(0, 0);
            scrollable.Width = VIEWPORT_WIDTH;
            Camera newCamera = camera.Update(VIEWPORT_WIDTH, VIEWPORT_HEIGHT, scrollable);

            Assert.AreEqual(camera.X, newCamera.X, "Should not scroll right because map is already at maximum right");
            Assert.AreEqual(camera.Y, newCamera.Y, "Should not scroll up because map is already at top");
        }

        [TestMethod]
        public void WhenConvertingScreenToWorldCoordinatesShouldAddCameraCoordinates()
        {
            camera = camera.SetPosition(20, 30);
            Point screenCoordinates = new Point(2, 3);
            Point worldCoordinates = camera.ScreenToWorld(screenCoordinates);

            Assert.AreEqual(camera.X + screenCoordinates.X, worldCoordinates.X);
            Assert.AreEqual(camera.Y + screenCoordinates.Y, worldCoordinates.Y);
        }

        [TestMethod]
        public void WhenMouseIsScrolledForwardThenShouldZoomIn()
        {
            input.Scrolling = MouseScrolling.FORWARD;

            Camera newCamera = camera.Update(VIEWPORT_WIDTH, VIEWPORT_HEIGHT, scrollable);

            Assert.AreEqual(camera.Zoom + 1, newCamera.Zoom);
        }

        [TestMethod]
        public void CannotZoomInCloserThan3()
        {
            input.Scrolling = MouseScrolling.FORWARD;

            Camera newCamera = camera
                .Update(VIEWPORT_WIDTH, VIEWPORT_HEIGHT, scrollable)
                .Update(VIEWPORT_WIDTH, VIEWPORT_HEIGHT, scrollable)
                .Update(VIEWPORT_WIDTH, VIEWPORT_HEIGHT, scrollable)
                .Update(VIEWPORT_WIDTH, VIEWPORT_HEIGHT, scrollable);

            Assert.AreEqual(3, newCamera.Zoom);
        }

        [TestMethod]
        public void WhenMouseIsScrolledBackwardThenShouldZoomOut()
        {
            camera = camera.SetZoom(2);
            input.Scrolling = MouseScrolling.BACKWARD;

            Camera newCamera = camera.Update(VIEWPORT_WIDTH, VIEWPORT_HEIGHT, scrollable);

            Assert.AreEqual(camera.Zoom - 1, newCamera.Zoom);
        }

        [TestMethod]
        public void CannotZoomOutFartherThanOne()
        {
            input.Scrolling = MouseScrolling.BACKWARD;

            Camera newCamera = camera
                .Update(VIEWPORT_WIDTH, VIEWPORT_HEIGHT, scrollable)
                .Update(VIEWPORT_WIDTH, VIEWPORT_HEIGHT, scrollable);

            Assert.AreEqual(camera.Zoom, newCamera.Zoom);
        }

        [TestMethod]
        public void WhenMouseIsNotScrolledThenShouldNotAffectZoom()
        {
            input.Scrolling = MouseScrolling.NONE;

            Camera newCamera = camera.Update(VIEWPORT_WIDTH, VIEWPORT_HEIGHT, scrollable);

            Assert.AreEqual(camera.Zoom, newCamera.Zoom);
        }

        private class FakeMouseInput : IMouseInput
        {
            public Point Position { get; set; }
            public MouseScrolling Scrolling { get; set; }
        }

        private class FakeScrollable : IScrollable
        {
            public int Width { get; set; }
            public int Height { get; set; }
        }
    }
}
