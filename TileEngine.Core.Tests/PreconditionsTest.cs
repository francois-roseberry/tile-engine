using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TileEngine;

namespace TestProject
{
    [TestClass]
    public class PreconditionsTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void WhenConditionFailsShouldThrowException()
        {
            Preconditions.CheckArgument(false, "Should fail");
        }

        [TestMethod]
        public void WhenConditionIsTrueShouldDoNothing()
        {
            Preconditions.CheckArgument(true, "Should not fail");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void WhenArgumentIsNullShouldThrowException()
        {
            Object obj = null;
            Preconditions.CheckNotNull(obj, "Should fail");
        }

        [TestMethod]
        public void WhenArgumentIsNotNullShouldReturnIt()
        {
            Object obj = new Object();
            Object result = Preconditions.CheckNotNull(obj, "Should not fail");

            Assert.AreEqual(obj, result);
        }
    }
}
