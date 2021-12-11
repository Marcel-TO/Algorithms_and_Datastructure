//-----------------------------------------------------------------------
// <copyright file="Player_Tests.cs" company="FHWN">
//     Copyright (c) Marcel Turobin-Ort. All rights reserved.
// </copyright>
// <author>Marcel Turobin-Ort</author>
// <summary>Defines the test class for the player class.</summary>
//-----------------------------------------------------------------------
namespace SnakesAndLadders_UnitTests.GameObjects
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using SnakesAndLadders.GameObjects;

    /// <summary>
    /// Represents the unit tests for the player class.
    /// </summary>
    [TestClass]
    public class Player_Tests
    {
        /// <summary>
        /// Represents a method for testing if parameter is null.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestIfParameterIsNull()
        {
            Player player = new Player(null);
        }

        /// <summary>
        /// Represents a method for testing if player property works properly.
        /// </summary>
        [TestMethod]
        public void TestIfPlayerWorks()
        {
            Player player = new Player("tester");
            Assert.IsTrue(player.Name == "tester");
            Assert.IsTrue(player.Position == 0);
            Assert.IsTrue(player.Turns.Count == 0);
        }

        /// <summary>
        /// Represents a method for testing if turns property works properly.
        /// </summary>
        [TestMethod]
        public void TestIfTurnsWorks()
        {
            Player player = new Player("tester");
            Assert.IsNotNull(player.Turns);

            player.Turns.Add(new Turn(4, player.Position, player.Position + 4, false));

            Assert.IsTrue(player.Turns.Count == 1);
            Assert.IsTrue(player.Turns[0].DiceRoll == 4);
        }

        /// <summary>
        /// Represents a method for testing if position property works properly.
        /// </summary>
        [TestMethod]
        public void TestIfPositionWorks()
        {
            Player player = new Player("tester");
            Assert.IsTrue(player.Position == 0);

            player.Position = 4;
            Assert.IsTrue(player.Position == 4);
        }

        /// <summary>
        /// Represents a method for testing if position property works properly when handling negative input.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestIfPositionNegative()
        {
            Player player = new Player("tester");
            Assert.IsTrue(player.Position == 0);

            player.Position = -4;
        }
    }
}
