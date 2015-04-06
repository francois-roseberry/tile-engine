using TileEngine;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Microsoft.Xna.Framework;

namespace TestProject
{
    [TestClass]
    public class CameraTest
    {
        private static readonly Size VIEWPORT = new Size(200, 200);

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
            scrollable.Width = VIEWPORT.Width * 5;
            scrollable.Height = VIEWPORT.Height * 5;
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
            for (int x = 50; x < VIEWPORT.Width - 50; x++)
            {
                for (int y = 50; y < VIEWPORT.Height - 50; y++)
                {
                    input.Position = new Point(x, y);

                    Camera movedCamera = camera.Update(VIEWPORT, scrollable);

                    Assert.AreEqual(camera.X, movedCamera.X, "Should not scroll left or right");
                    Assert.AreEqual(camera.Y, movedCamera.Y, "Should not scroll down or up");
                }
            }
        }

        [TestMethod] 
        public void WhenMouseIsInRightZoneAndCanScrollRightThenShouldScroll()
        {
            for (int y = 50; y <= VIEWPORT.Height - 50; y++)
            {
                for (int x = VIEWPORT.Width - 50 + 1; x < VIEWPORT.Width; x++)
                {
                    input.Position = new Point(x, y);

                    Camera movedCamera = camera.Update(VIEWPORT, scrollable);

                    Assert.AreEqual(camera.X + 1, movedCamera.X, "Should scroll right");
                    Assert.AreEqual(camera.Y, movedCamera.Y, "Should not scroll down or up");
                }
            }

            scrollable.Width = VIEWPORT.Width;
            Camera newCamera = camera.Update(VIEWPORT, scrollable);

            Assert.AreEqual(camera.X, newCamera.X, "Should not scroll right because map is at maximum right");
            Assert.AreEqual(camera.Y, newCamera.Y, "Should not scroll down or up");
        }

        [TestMethod]
        public void WhenMouseIsInLeftZoneThenShouldScroll()
        {
            camera = camera.SetPosition(20, 20);
            for (int y = 50; y <= VIEWPORT.Height - 50; y++)
            {
                for (int x = 0; x < 50; x++)
                {
                    input.Position = new Point(x, y);

                    Camera moved = camera.Update(VIEWPORT, scrollable);

                    Assert.AreEqual(camera.X - 1, moved.X, "Should scroll left");
                    Assert.AreEqual(camera.Y, moved.Y, "Should not scroll up or down");
                }
            }

            camera = camera.SetPosition(0, 0);
            Camera newCamera = camera.Update(VIEWPORT, scrollable);

            Assert.AreEqual(camera.X, newCamera.X, "Should not scroll left because map is already at maximum left");
            Assert.AreEqual(camera.Y, newCamera.Y, "Should not scroll down or up");
        }

        [TestMethod]
        public void WhenMouseIsInTopZoneThenShouldScroll()
        {
            camera = camera.SetPosition(20, 20);
            for (int x = 50; x <= VIEWPORT.Width - 50; x++)
            {
                for (int y = 0; y < 50; y++)
                {
                    input.Position = new Point(x, y);

                    Camera moved = camera.Update(VIEWPORT, scrollable);

                    Assert.AreEqual(camera.X, moved.X, "Should not scroll left or right");
                    Assert.AreEqual(camera.Y - 1, moved.Y, "Should scroll up");
                }
            }

            camera = camera.SetPosition(0, 0);
            Camera newCamera = camera.Update(VIEWPORT, scrollable);

            Assert.AreEqual(camera.X, newCamera.X, "Should not scroll left or right");
            Assert.AreEqual(camera.Y, newCamera.Y, "Should not scroll or up because map is already at top");
        }

        [TestMethod]
        public void WhenMouseIsInBottomZoneThenShouldScroll()
        {
            for (int x = 50; x <= VIEWPORT.Width - 50; x++)
            {
                for (int y = VIEWPORT.Height - 50 + 1; y < VIEWPORT.Height; y++)
                {
                    input.Position = new Point(x, y);

                    Camera moved = camera.Update(VIEWPORT, scrollable);

                    Assert.AreEqual(camera.X, moved.X, "Should not scroll left or right");
                    Assert.AreEqual(camera.Y + 1, moved.Y, "Should scroll down");
                }
            }

            scrollable.Height = VIEWPORT.Height;
            Camera newCamera = camera.Update(VIEWPORT, scrollable);

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

                    Camera moved = camera.Update(VIEWPORT, scrollable);

                    Assert.AreEqual(camera.X - 1, moved.X, "Should scroll left");
                    Assert.AreEqual(camera.Y - 1, moved.Y, "Should scroll up");
                }
            }

            camera = camera.SetPosition(0, 0);
            Camera newCamera = camera.Update(VIEWPORT, scrollable);

            Assert.AreEqual(camera.X, newCamera.X, "Should not scroll left because map is already at maximum left");
            Assert.AreEqual(camera.Y, newCamera.Y, "Should not scroll up because map is already at top");
        }

        [TestMethod] 
        public void WhenMouseIsInTopRightCornerThenShouldScroll()
        {
            camera = camera.SetPosition(20, 20);
            for (int x = VIEWPORT.Width - 50 + 1; x < VIEWPORT.Width; x++)
            {
                for (int y = 0; y < 50; y++)
                {
                    input.Position = new Point(x, y);

                    Camera moved = camera.Update(VIEWPORT, scrollable);

                    Assert.AreEqual(camera.X + 1, moved.X, "Should scroll right");
                    Assert.AreEqual(camera.Y - 1, moved.Y, "Should scroll up");
                }
            }

            camera = camera.SetPosition(0, 0);
            Camera newCamera = camera.Update(VIEWPORT, scrollable);

            Assert.AreEqual(camera.X, newCamera.X, "Should not scroll right because map is already at maximum right");
            Assert.AreEqual(camera.Y, newCamera.Y, "Should not scroll up because map is already at top");
        }

        [TestMethod]
        public void WhenMouseInInBottomLeftCornerThenShouldScroll()
        {
            camera = camera.SetPosition(20, 20);
            for (int x = 0; x < 50; x++)
            {
                for (int y = VIEWPORT.Height - 50 + 1; y < VIEWPORT.Height; y++)
                {
                    input.Position = new Point(x, y);

                    Camera moved = camera.Update(VIEWPORT, scrollable);

                    Assert.AreEqual(camera.X - 1, moved.X, "Should scroll left");
                    Assert.AreEqual(camera.Y + 1, moved.Y, "Should scroll down");
                }
            }

            camera = camera.SetPosition(0, 0);
            scrollable.Height = VIEWPORT.Height;
            Camera newCamera = camera.Update(VIEWPORT, scrollable);

            Assert.AreEqual(camera.X, newCamera.X, "Should not scroll left because map is already at maximum left");
            Assert.AreEqual(camera.Y, newCamera.Y, "Should not scroll down because map is already at bottom");
        }

        [TestMethod]
        public void WhenMouseIsInBottomRightCornerThenShouldScroll()
        {
            for (int x = VIEWPORT.Width - 50 + 1; x < VIEWPORT.Width; x++)
            {
                for (int y = VIEWPORT.Height - 50 + 1; y < VIEWPORT.Height; y++)
                {
                    input.Position = new Point(x, y);

                    Camera moved = camera.Update(VIEWPORT, scrollable);

                    Assert.AreEqual(camera.X + 1, moved.X, "Should scroll right");
                    Assert.AreEqual(camera.Y + 1, moved.Y, "Should scroll up");
                }
            }

            camera = camera.SetPosition(0, 0);
            scrollable.Width = VIEWPORT.Width;
            Camera newCamera = camera.Update(VIEWPORT, scrollable);

            Assert.AreEqual(camera.X, newCamera.X, "Should not scroll right because map is already at maximum right");
            Assert.AreEqual(camera.Y, newCamera.Y, "Should not scroll up because map is already at top");
        }

        [TestMethod]
        public void WhenConvertingScreenToWorldCoordinatesShouldAddCameraCoordinatesAndAccountForZoom()
        {
            camera = ZoomIn(camera.SetPosition(20, 30));
            Point screenCoordinates = new Point(2, 3);
            Point worldCoordinates = camera.ScreenToWorld(screenCoordinates);

            Assert.AreEqual((camera.X + screenCoordinates.X) / camera.Zoom, worldCoordinates.X);
            Assert.AreEqual((camera.Y + screenCoordinates.Y) / camera.Zoom, worldCoordinates.Y);
        }

        [TestMethod]
        public void WhenMouseIsScrolledForwardThenShouldZoomIn()
        {
            input.Scrolling = MouseScrolling.FORWARD;

            Camera newCamera = camera.Update(VIEWPORT, scrollable);

            Assert.AreEqual(camera.Zoom + 1, newCamera.Zoom);
        }

        [TestMethod]
        public void CannotZoomInCloserThan2()
        {
            input.Scrolling = MouseScrolling.FORWARD;

            Camera newCamera = camera
                .Update(VIEWPORT, scrollable)
                .Update(VIEWPORT, scrollable)
                .Update(VIEWPORT, scrollable)
                .Update(VIEWPORT, scrollable);

            Assert.AreEqual(2, newCamera.Zoom);
        }

        [TestMethod]
        public void WhenMouseIsScrolledBackwardThenShouldZoomOut()
        {
            camera = ZoomIn(camera);
            input.Scrolling = MouseScrolling.BACKWARD;

            Camera newCamera = camera.Update(VIEWPORT, scrollable);

            Assert.AreEqual(camera.Zoom - 1, newCamera.Zoom);
        }

        [TestMethod]
        public void CannotZoomOutFartherThanOne()
        {
            input.Scrolling = MouseScrolling.BACKWARD;

            Camera newCamera = camera
                .Update(VIEWPORT, scrollable)
                .Update(VIEWPORT, scrollable);

            Assert.AreEqual(camera.Zoom, newCamera.Zoom);
        }

        [TestMethod]
        public void WhenMouseIsNotScrolledThenShouldNotAffectZoom()
        {
            input.Scrolling = MouseScrolling.NONE;

            Camera newCamera = camera.Update(VIEWPORT, scrollable);

            Assert.AreEqual(camera.Zoom, newCamera.Zoom);
        }

        [TestMethod]
        public void WhenZoomingInThenCoordinatesShouldBeCloser()
        {
            input.Scrolling = MouseScrolling.FORWARD;

            Camera newCamera = camera.Update(VIEWPORT, scrollable);

            Assert.AreEqual(camera.X + VIEWPORT.Width / 4, newCamera.X);
            Assert.AreEqual(camera.Y + VIEWPORT.Height / 4, newCamera.Y);
        }

        [TestMethod]
        public void WhenZoomingOutThenCoordinatesShouldNeverBecomeLowerThanZero()
        {
            camera = ZoomIn(camera);
            input.Scrolling = MouseScrolling.BACKWARD;

            Camera newCamera = camera.Update(VIEWPORT, scrollable);

            Assert.AreEqual(0, newCamera.X);
            Assert.AreEqual(0, newCamera.Y);
        }

        private Camera ZoomIn(Camera camera)
        {
            input.Scrolling = MouseScrolling.FORWARD;
            return camera.Update(VIEWPORT, scrollable);
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
