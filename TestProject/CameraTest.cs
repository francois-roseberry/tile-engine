using TileEngine;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Microsoft.Xna.Framework;

namespace TestProject
{
    /// <summary>
    ///This is a test class for CameraTest and is intended
    ///to contain all CameraTest Unit Tests
    ///</summary>
    [TestClass()]
    public class CameraTest
    {
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

        [TestInitialize()]
        public void Setup()
        {
            input = new FakeMouseInput();
            scrollable = new FakeScrollable();
            scrollable.Width = 1000;
            scrollable.Height = 1000;
            camera = Camera.Default(input);
        }

        [TestMethod()]
        public void DefaultCameraShouldBePositionedAtOrigin()
        {
            Assert.AreEqual(0, camera.X);
            Assert.AreEqual(0, camera.Y);
        }

        [TestMethod()] 
        public void WhenMouseIsInRightZoneAndCanScrollRightThenShouldScroll()
        {
            input.Position = new Point(160, 100);

            Camera newCamera = camera.Update(200, 200, scrollable);

            Assert.AreEqual(1, newCamera.X);
            Assert.AreEqual(0, newCamera.Y);
        }

        [TestMethod()]
        public void WhenMouseIsInBottomZoneAndCanScrollDownThenShouldScroll()
        {
            input.Position = new Point(100, 160);

            Camera newCamera = camera.Update(200, 200, scrollable);

            Assert.AreEqual(0, newCamera.X);
            Assert.AreEqual(1, newCamera.Y);
        }

        [TestMethod()]
        public void WhenMouseIsInBottomRightCornerAndCanScrollDownRightThenShouldScroll()
        {
            input.Position = new Point(160, 160);

            Camera newCamera = camera.Update(200, 200, scrollable);

            Assert.AreEqual(1, newCamera.X);
            Assert.AreEqual(1, newCamera.Y);
        }

        private class FakeMouseInput : IMouseInput
        {
            public Point Position { get; set; }
        }

        private class FakeScrollable : IScrollable
        {
            public int Width { get; set; }
            public int Height { get; set; }
        }
    }
}
