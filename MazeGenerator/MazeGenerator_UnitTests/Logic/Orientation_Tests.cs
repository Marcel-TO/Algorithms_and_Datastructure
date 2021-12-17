namespace MazeGenerator_UnitTests.Logic
{
    using System;
    using System.Collections.Generic;
    using MazeGenerator_Model.Logic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class Orientation_Tests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestIfForwardIsNull()
        {
            Orientation o = new Orientation(null, new List<double> { 1, 1, 2, 2 }, 60);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestIfInverseIsNull()
        {
            Orientation o = new Orientation(new List<double> { 1, 1, 2, 2 }, null, 60);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestIfForwardIsWrong()
        {
            Orientation o = new Orientation(new List<double>(), new List<double> { 1, 1, 2, 2 }, 60);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestIfInverseIsWrong()
        {
            Orientation o = new Orientation(new List<double> { 1, 1, 2, 2 }, new List<double>(), 60);
        }

        [TestMethod]
        public void TestIfOrientationWorks()
        {
            Orientation o = new Orientation(new List<double> { 1, 1, 2, 2 }, new List<double> { 1, 1, 2, 2 }, 60);

            Assert.IsNotNull(o);
        }
    }
}
