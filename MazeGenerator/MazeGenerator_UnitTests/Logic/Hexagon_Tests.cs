namespace MazeGenerator_UnitTests.Logic
{
    using System;
    using MazeGenerator_Model.Logic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class Hexagon_Tests
    {
        [TestMethod]
        public void TestIfHexagonWorks()
        {
            Hexagon hex = new Hexagon(0, 0, 0);

            Assert.IsNotNull(hex);
            Assert.IsTrue(hex.Direction == 0);
            Assert.IsFalse(hex.IsChosen);
            Assert.IsTrue(hex.IsOpen.Length == 6);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestIfDirectionSetsNegative()
        {
            Hexagon hex = new Hexagon(0, 0, 0);

            hex.Direction = -5;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestIfDirectionSetsTooHigh()
        {
            Hexagon hex = new Hexagon(0, 0, 0);

            hex.Direction = 8;
        }

        [TestMethod]
        public void TestIfDirectionSetWorks()
        {
            Hexagon hex = new Hexagon(0, 0, 0);

            hex.Direction = 3;

            Assert.IsTrue(hex.Direction == 3);
        }
    }
}
