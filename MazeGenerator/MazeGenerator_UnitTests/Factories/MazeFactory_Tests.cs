namespace MazeGenerator_UnitTests.Factories
{
    using System;
    using MazeGenerator_Model.Factories;
    using MazeGenerator_Model.Logic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class MazeFactory_Tests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestIfParameterIsNull()
        {
            MazeFactory factory = new MazeFactory(null);
        }

        [TestMethod]
        public void TestIfCreateMazeWorks()
        {
            MazeFactory factory = new MazeFactory(new RandomGenerator());
            Maze maze = factory.CreateMaze(1);

            Assert.IsTrue(maze.Hexagons.Count == 7);
            Assert.IsTrue(maze.Size == 1);

            for (int i = 0; i < maze.Hexagons.Count; i++)
            {
                Assert.IsTrue(maze.Hexagons[i].IsChosen == true);
            }
        }
    }
}
