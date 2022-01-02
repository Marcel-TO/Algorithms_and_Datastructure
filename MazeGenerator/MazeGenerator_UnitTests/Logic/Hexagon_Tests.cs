//-----------------------------------------------------------------------
// <copyright file="Hexagon_Tests.cs" company="FHWN">
//     Copyright (c) Marcel Turobin-Ort. All rights reserved.
// </copyright>
// <author>Marcel Turobin-Ort</author>
// <summary>Defines the unit tests for the hexagon class.</summary>
//-----------------------------------------------------------------------
namespace MazeGenerator_UnitTests.Logic
{
    using System;
    using MazeGenerator_Model.Logic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Represents the unit tests for the hexagon class.
    /// </summary>
    [TestClass]
    public class Hexagon_Tests
    {
        /// <summary>
        /// Represents the method for testing if hexagon works.
        /// </summary>
        [TestMethod]
        public void TestIfHexagonWorks()
        {
            Hexagon hex = new Hexagon(0, 0, 0);

            Assert.IsNotNull(hex);
            Assert.IsTrue(hex.Direction == 0);
            Assert.IsFalse(hex.IsChosen);
            Assert.IsTrue(hex.IsOpen.Length == 6);
        }

        /// <summary>
        /// Represents the method for testing if direction sets is negative.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestIfDirectionSetsNegative()
        {
            Hexagon hex = new Hexagon(0, 0, 0);

            hex.Direction = -5;
        }

        /// <summary>
        /// Represents the method for testing if direction sets is too high.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestIfDirectionSetsTooHigh()
        {
            Hexagon hex = new Hexagon(0, 0, 0);

            hex.Direction = 8;
        }

        /// <summary>
        /// Represents the method for testing if direction sets works.
        /// </summary>
        [TestMethod]
        public void TestIfDirectionSetWorks()
        {
            Hexagon hex = new Hexagon(0, 0, 0);

            hex.Direction = 3;

            Assert.IsTrue(hex.Direction == 3);
        }
    }
}
