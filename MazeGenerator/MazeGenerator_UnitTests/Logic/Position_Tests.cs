namespace MazeGenerator_UnitTests.Logic
{
    using System;
    using System.Collections.Generic;
    using MazeGenerator_Model.Logic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class Position_Tests
    {
        [TestMethod]
        public void TestIfGetWorks()
        {
            Position pos = new Position(0, 0);

            Assert.IsTrue(pos.X == 0);
            Assert.IsTrue(pos.Y == 0);
        }

        [TestMethod]
        public void TestIfSetWorks()
        {
            Position pos = new Position(0, 0);

            pos.X = 23.5;
            pos.Y = -37.3;

            Assert.IsTrue(pos.X == 23.5);
            Assert.IsTrue(pos.Y == -37.3);
        }
    }
}
