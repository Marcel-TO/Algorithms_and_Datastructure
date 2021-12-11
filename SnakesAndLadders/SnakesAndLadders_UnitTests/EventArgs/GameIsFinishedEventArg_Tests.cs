//-----------------------------------------------------------------------
// <copyright file="GameIsFinishedEventArg_Tests.cs" company="FHWN">
//     Copyright (c) Marcel Turobin-Ort. All rights reserved.
// </copyright>
// <author>Marcel Turobin-Ort</author>
// <summary>Defines the test class for the event that fires if a game is finished.</summary>
//-----------------------------------------------------------------------
namespace SnakesAndLadders_UnitTests.EventArgs
{
    using System;
    using System.Collections.Generic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using SnakesAndLadders.EventArgs;
    using SnakesAndLadders.GameObjects;
    using SnakesAndLadders.Logic;

    /// <summary>
    /// Represents the unit tests for the event argument class if game is finished.
    /// </summary>
    [TestClass]
    public class GameIsFinishedEventArg_Tests
    {
        /// <summary>
        /// Represents the method for testing if parameter is null.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestIfParameterIsNull()
        {
            GameIsFinishedEventArg eventArg = new GameIsFinishedEventArg(null);
        }

        /// <summary>
        /// Represents the method for testing if the constructor works properly.
        /// </summary>
        [TestMethod]
        public void TestIfEventPropertyWorks()
        {
            GameIsFinishedEventArg eventArg = new GameIsFinishedEventArg(new Game("test", new List<Field>(), new Dice(6), new List<Player>()));

            Assert.IsNotNull(eventArg.Game);
        }

        /// <summary>
        /// Represents the method for testing if the event fires.
        /// </summary>
        [TestMethod]
        public void TestIfEventFires()
        {
            GameFactory factory = new GameFactory();
            Game game = factory.CreateGame("test", 10, 5, 1);

            bool eventFired = false;

            // Sets delegate if event fires.
            game.GameIsFinished += delegate(object sender, GameIsFinishedEventArg e)
            {
                eventFired = true;
            };

            game.Run();
            Assert.IsTrue(eventFired);
        }
    }
}
