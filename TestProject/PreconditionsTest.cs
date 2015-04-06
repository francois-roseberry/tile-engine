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
    }
}
