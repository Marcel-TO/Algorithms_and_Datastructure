namespace MazeGenerator_UnitTests.Logic
{
    using System;
    using System.Collections.Generic;
    using MazeGenerator_Model.Logic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class Maze_Tests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestIfListIsNull()
        {
            Maze maze = new Maze(null, 1);
        }

        [TestMethod]
        public void TestIfSizeIsNegative()
        {
            Maze maze = new Maze(new List<Hexagon>(), 1);
        }
    }
}
