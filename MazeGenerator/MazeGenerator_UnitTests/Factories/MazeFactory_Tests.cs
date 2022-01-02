//-----------------------------------------------------------------------
// <copyright file="MazeFactory_Tests.cs" company="FHWN">
//     Copyright (c) Marcel Turobin-Ort. All rights reserved.
// </copyright>
// <author>Marcel Turobin-Ort</author>
// <summary>Defines the unit tests for the maze factory class.</summary>
//-----------------------------------------------------------------------
namespace MazeGenerator_UnitTests.Factories
{
    using System;
    using MazeGenerator_Model.Factories;
    using MazeGenerator_Model.Logic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Represents the unit tests for the maze factory class.
    /// </summary>
    [TestClass]
    public class MazeFactory_Tests
    {
        /// <summary>
        /// Represents the method for testing if parameter is null.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestIfParameterIsNull()
        {
            MazeFactory factory = new MazeFactory(null);
        }

        /// <summary>
        /// Represents the method for creating the maze.
        /// </summary>
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

        /// <summary>
        /// Represents the method for testing if create maze is too small.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestIfCreateMazeIsNegative()
        {
            MazeFactory factory = new MazeFactory(new RandomGenerator());
            Maze maze = factory.CreateMaze(-1);
        }
    }
}
