//-----------------------------------------------------------------------
// <copyright file="GameFactory_Tests.cs" company="FHWN">
//     Copyright (c) Marcel Turobin-Ort. All rights reserved.
// </copyright>
// <author>Marcel Turobin-Ort</author>
// <summary>Defines the test class for the game factory class.</summary>
//-----------------------------------------------------------------------
namespace SnakesAndLadders_UnitTests.Logic
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using SnakesAndLadders.GameObjects;
    using SnakesAndLadders.Logic;

    /// <summary>
    /// Represents the unit tests for the game factory class.
    /// </summary>
    [TestClass]
    public class GameFactory_Tests
    {
        /// <summary>
        /// Represents the method for testing if name parameter is null.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestIfNameIsNull()
        {
            GameFactory factory = new GameFactory();
            factory.CreateGame(null, 1, 1, 1);
        }

        /// <summary>
        /// Represents the method for testing if board size parameter is too small.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestIfBoardSizeIsTooSmall()
        {
            GameFactory factory = new GameFactory();
            factory.CreateGame("test", 0, 1, 1);
        }

        /// <summary>
        /// Represents the method for testing if dice size parameter is too small.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestIfDiceSizeIsTooSmall()
        {
            GameFactory factory = new GameFactory();
            factory.CreateGame("test", 1, 0, 1);
        }

        /// <summary>
        /// Represents the method for testing if player size parameter is too small.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestIfPlayerSizeIsTooSmall()
        {
            GameFactory factory = new GameFactory();
            factory.CreateGame("test", 1, 1, 0);
        }

        /// <summary>
        /// Represents the method for testing if create game works.
        /// </summary>
        [TestMethod]
        public void TestIfCreateGameWorks()
        {
            GameFactory factory = new GameFactory();
            Game game = factory.CreateGame("test", 30, 6, 5);

            Assert.IsNotNull(game);
            Assert.IsTrue(game.Players.Count == 5);
            Assert.IsTrue(game.Fields.Count == 30);
            Assert.IsTrue(game.Dice.Size == 6);
        }
    }
}
