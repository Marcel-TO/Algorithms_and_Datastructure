//-----------------------------------------------------------------------
// <copyright file="Position_Tests.cs" company="FHWN">
//     Copyright (c) Marcel Turobin-Ort. All rights reserved.
// </copyright>
// <author>Marcel Turobin-Ort</author>
// <summary>Defines the test class for the position class.</summary>
//-----------------------------------------------------------------------
namespace BefungeInterpreter_UnitTest.Logic
{
    using System;
    using BefungeInterpreter.Logic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Represents the unit tests for the position class.
    /// </summary>
    [TestClass]
    public class Position_Tests
    {
        /// <summary>
        /// Represents a method for testing if content is null.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestIfContentIsNull()
        {
            Position position = new Position(0, 0);

            position.ValidatePosition(position, null);
        }

        /// <summary>
        /// Represents a method for testing if y position works properly if out of range.
        /// </summary>
        [TestMethod]
        public void TestYPosition()
        {
            Position position = new Position(0, 5);

            position.ValidatePosition(position, new string[] { "1", "2" });

            Assert.IsTrue(position.Y == 0);
        }

        /// <summary>
        /// Represents a method for testing if x position works properly if out of range.
        /// </summary>
        [TestMethod]
        public void TestXPosition()
        {
            Position position = new Position(5, 0);

            position.ValidatePosition(position, new string[] { "12" });

            Assert.IsTrue(position.X == 0);
        }
    }
}
