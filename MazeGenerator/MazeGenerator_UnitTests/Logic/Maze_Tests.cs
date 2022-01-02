//-----------------------------------------------------------------------
// <copyright file="Maze_Tests.cs" company="FHWN">
//     Copyright (c) Marcel Turobin-Ort. All rights reserved.
// </copyright>
// <author>Marcel Turobin-Ort</author>
// <summary>Defines the unit tests for the maze class.</summary>
//-----------------------------------------------------------------------
namespace MazeGenerator_UnitTests.Logic
{
    using System;
    using System.Collections.Generic;
    using MazeGenerator_Model.Logic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Represents the unit tests for the maze tests.
    /// </summary>
    [TestClass]
    public class Maze_Tests
    {
        /// <summary>
        /// Represents the method for testing if list is null.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestIfListIsNull()
        {
            Maze maze = new Maze(null, 1);
        }

        /// <summary>
        /// Represents the method for testing if size is negative.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestIfSizeIsNegative()
        {
            Maze maze = new Maze(new List<Hexagon>(), -1);
        }
    }
}
