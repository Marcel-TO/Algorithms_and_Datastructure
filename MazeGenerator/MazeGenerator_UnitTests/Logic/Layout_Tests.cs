namespace MazeGenerator_UnitTests.Logic
{
    using System;
    using System.Collections.Generic;
    using MazeGenerator_Model.Logic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class Layout_Tests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestIfOrientationIsNull()
        {
            Layout layout = new Layout(null, new Position(100, 100), new Position(0, 0));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestISizeIsNull()
        {
            Layout layout = new Layout(new Orientation(new List<double> { 1, 1, 2, 2 }, new List<double> { 2, 2, 1, 1 }, 60), null, new Position(0, 0));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestIfOriginIsNull()
        {
            Layout layout = new Layout(new Orientation(new List<double> { 1, 1, 2, 2 }, new List<double> { 2, 2, 1, 1 }, 60), new Position(0, 0), null);
        }
    }
}
