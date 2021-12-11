//-----------------------------------------------------------------------
// <copyright file="Dice_Tests.cs" company="FHWN">
//     Copyright (c) Marcel Turobin-Ort. All rights reserved.
// </copyright>
// <author>Marcel Turobin-Ort</author>
// <summary>Defines the test class for the dice class.</summary>
//-----------------------------------------------------------------------
namespace SnakesAndLadders_UnitTests.GameObjects
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using SnakesAndLadders.GameObjects;

    /// <summary>
    /// Represents the unit tests for the dice class.
    /// </summary>
    [TestClass]
    public class Dice_Tests
    {
        /// <summary>
        /// Represents the method for testing if dice "roll" works.
        /// </summary>
        [TestMethod]
        public void TestIfDiceWorks()
        {
            Dice dice = new Dice(6);

            Assert.IsNotNull(dice);
            Assert.IsTrue(dice.Size == 6);
            Assert.IsTrue(dice.RollDice() >= 1);
            Assert.IsTrue(dice.RollDice() <= 6);
        }

        /// <summary>
        /// Represents a method for testing if the parameter is too small for the dice.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestIfSizeIsTooSmall()
        {
            Dice dice = new Dice(0);
        }

        /// <summary>
        /// Represents a method for testing if the parameter is negative.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestIfSizeIsNegative()
        {
            Dice dice = new Dice(-6);
        }

        /// <summary>
        /// Represents a method for testing if the parameter is very high for a normal dice.
        /// </summary>
        [TestMethod]
        public void TestIfSizeHigh()
        {
            Dice dice = new Dice(100);

            Assert.IsTrue(dice.Size == 100);
            Assert.IsTrue(dice.RollDice() >= 1);
            Assert.IsTrue(dice.RollDice() <= 100);
        }
    }
}
