//-----------------------------------------------------------------------
// <copyright file="Turn_Tests.cs" company="FHWN">
//     Copyright (c) Marcel Turobin-Ort. All rights reserved.
// </copyright>
// <author>Marcel Turobin-Ort</author>
// <summary>Defines the test class for the turn class.</summary>
//-----------------------------------------------------------------------
namespace SnakesAndLadders_UnitTests.GameObjects
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using SnakesAndLadders.GameObjects;

    /// <summary>
    /// Represents the unit tests for the turn class.
    /// </summary>
    [TestClass]
    public class Turn_Tests
    {
        /// <summary>
        /// Represents a method for testing if roll value is not valid.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestIfRollIsNotValid()
        {
            Turn turn = new Turn(-1, 0, 0, false);
        }

        /// <summary>
        /// Represents a method for testing if old position value is not valid.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestIfOldPositionIsNotValid()
        {
            Turn oldPos = new Turn(6, -1, 0, false);
        }

        /// <summary>
        /// Represents a method for testing if new position value is not valid.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestIfNewPositionIsNotValid()
        {
            Turn newPos = new Turn(6, 0, -1, false);
        }

        /// <summary>
        /// Represents a method for testing if turn works properly.
        /// </summary>
        [TestMethod]
        public void TestIfTurnWorks()
        {
            Turn turn = new Turn(6, 0, 6, false);

            Assert.IsTrue(turn.DiceRoll == 6);
            Assert.IsTrue(turn.OldPosition == 0);
            Assert.IsTrue(turn.NewPosition == 6);
            Assert.IsFalse(turn.UsedSpecial);
        }
    }
}
