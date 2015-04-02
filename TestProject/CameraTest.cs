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
        private IMouseInput input;

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
        }

        [TestMethod()]
        public void DefaultCameraShouldBePositionedAtOrigin()
        {
            Camera actual = Camera.Default(input);

            Assert.AreEqual(0, actual.X);
            Assert.AreEqual(0, actual.Y);
        }

        private class FakeMouseInput : IMouseInput
        {
            public Point Position { get; set; }
        }
    }
}
