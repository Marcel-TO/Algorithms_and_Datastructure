//-----------------------------------------------------------------------
// <copyright file="Game_Tests.cs" company="FHWN">
//     Copyright (c) Marcel Turobin-Ort. All rights reserved.
// </copyright>
// <author>Marcel Turobin-Ort</author>
// <summary>Defines the test class for the game class.</summary>
//-----------------------------------------------------------------------
namespace SnakesAndLadders_UnitTests.GameObjects
{
    using System;
    using System.Collections.Generic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using SnakesAndLadders.GameObjects;
    using SnakesAndLadders.Logic;

    /// <summary>
    /// Represents the unit tests for the game class.
    /// </summary>
    [TestClass]
    public class Game_Tests
    {
        /// <summary>
        /// Represents a method for testing if name is null.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestIfNameIsNull()
        {
            Game game = new Game(null, new List<Field>(), new Dice(6), new List<Player>());
        }

        /// <summary>
        /// Represents a method for testing if field list is null.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestIfFieldsIsNull()
        {
            Game game = new Game("test", null, new Dice(6), new List<Player>());
        }

        /// <summary>
        /// Represents a method for testing if dice is null.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestIfDiceIsNull()
        {
            Game game = new Game("test", new List<Field>(), null, new List<Player>());
        }

        /// <summary>
        /// Represents a method for testing if player list is null.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestIfPlayersIsNull()
        {
            Game game = new Game("test", new List<Field>(), new Dice(6), null);
        }

        /// <summary>
        /// Represents a method for testing if constructor works.
        /// </summary>
        [TestMethod]
        public void TestIfConstructorWorks()
        {
            Game game = new Game("test", new List<Field>(), new Dice(6), new List<Player>());

            Assert.IsNotNull(game.Name);
            Assert.IsNotNull(game.Fields);
            Assert.IsNotNull(game.Dice);
            Assert.IsNotNull(game.Players);
            Assert.IsNotNull(game.IsFinished);
            Assert.IsNotNull(game.Time);
        }

        /// <summary>
        /// Represents a method for testing if the get from name works.
        /// </summary>
        [TestMethod]
        public void TestIfNameGetWorks()
        {
            Game game = new Game("test", new List<Field>(), new Dice(6), new List<Player>());

            Assert.IsTrue(game.Name == "test");
        }

        /// <summary>
        /// Represents a method for testing if the get from fields works.
        /// </summary>
        [TestMethod]
        public void TestIFieldsGetWorks()
        {
            Game game = new Game("test", new List<Field> { new Field(5) }, new Dice(6), new List<Player>());

            Assert.IsTrue(game.Fields.Count == 1);
            Assert.IsTrue(game.Fields[game.Fields.Count - 1].Pointer == 5);
        }

        /// <summary>
        /// Represents a method for testing if the get from dice works.
        /// </summary>
        [TestMethod]
        public void TestIDiceGetWorks()
        {
            Game game = new Game("test", new List<Field>(), new Dice(6), new List<Player>());

            Assert.IsTrue(game.Dice.Size == 6);
        }

        /// <summary>
        /// Represents a method for testing if the get from players works.
        /// </summary>
        [TestMethod]
        public void TestIPlayersGetWorks()
        {
            Game game = new Game("test", new List<Field>(), new Dice(6), new List<Player> { new Player("tester") });

            Assert.IsTrue(game.Players.Count == 1);
            Assert.IsTrue(game.Players[game.Players.Count - 1].Name == "tester");
        }

        /// <summary>
        /// Represents a method for testing if the get from is finished works.
        /// </summary>
        [TestMethod]
        public void TestIfIsFinishedGetWorks()
        {
            Game game = new Game("test", new List<Field>(), new Dice(6), new List<Player>());

            Assert.IsFalse(game.IsFinished);
        }

        /// <summary>
        /// Represents a method for testing if the get from is finished works.
        /// </summary>
        [TestMethod]
        public void TestIfTimespanGetWorks()
        {
            Game game = new Game("test", new List<Field>(), new Dice(6), new List<Player>());

            Assert.IsTrue(game.Time == TimeSpan.Zero);
        }

        /// <summary>
        /// Represents a method for testing if the run game simulation works.
        /// </summary>
        [TestMethod]
        public void TestIfRunGameWorks()
        {
            GameFactory factory = new GameFactory();
            Game game = factory.CreateGame("test", 100, 6, 1);

            game.Run();

            Assert.IsTrue(game.IsFinished);
            Assert.IsFalse(game.Time == TimeSpan.Zero);
            Assert.IsTrue(game.Players[game.Players.Count - 1].IsFinished);
            Assert.IsTrue(game.Players[game.Players.Count - 1].Position == 99);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestRunSimulation()
        {
            GameFactory factory = new GameFactory();
            Game game = factory.CreateGame("test", 100, 6, 1);

            game.RunPlayerSimulation(null);
        }
    }
}
