//-----------------------------------------------------------------------
// <copyright file="BridgeCommand_Tests.cs" company="FHWN">
//     Copyright (c) Marcel Turobin-Ort. All rights reserved.
// </copyright>
// <author>Marcel Turobin-Ort</author>
// <summary>Defines the test class for the bridge command class.</summary>
//-----------------------------------------------------------------------
namespace BefungeInterpreter_UnitTest.Commands
{
    using System;
    using System.Collections.Generic;
    using BefungeInterpreter.Commands;
    using BefungeInterpreter.Interfaces;
    using BefungeInterpreter.Logic;
    using BefungeInterpreter_UnitTests.TestInstances;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Represents the unit tests for the bridge command class.
    /// </summary>
    [TestClass]
    public class BridgeCommand_Tests
    {
        /// <summary>
        /// Represents a method for testing if parameters are null.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestIfParameterIsNull()
        {
            BridgeCommand command = new BridgeCommand(null);
        }

        /// <summary>
        /// Represents a method if execute reacts properly to null program.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestIfProgramInExecuteIsNull()
        {
            ILogger logger = new LoggerReplacementInstance();

            BridgeCommand command = new BridgeCommand(new BefungeProgram(new Stack<int>(), new string[] { "#" }, new Position(0, 0)));

            command.Execute(null, logger);
        }

        /// <summary>
        /// Represents a method if execute reacts properly to null logger.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestIfLoggerInExecuteIsNull()
        {
            BridgeCommand command = new BridgeCommand(new BefungeProgram(new Stack<int>(), new string[] { "#" }, new Position(0, 0)));

            command.Execute(command.Program, null);
        }

        /// <summary>
        /// Represents a method for testing if the right direction works.
        /// </summary>
        [TestMethod]
        public void TestIfBridgeRightIsCorrect()
        {
            ILogger logger = new LoggerReplacementInstance();

            BridgeCommand command = new BridgeCommand(new BefungeProgram(new Stack<int>(), new string[] { "12345678" }, new Position(0, 0)));
            Assert.IsTrue(command.Program.Position.X == 0 && command.Program.Position.Y == 0);
            Assert.IsTrue(command.Program.Content[command.Program.Position.Y][command.Program.Position.X] == '1');

            // Note: The Bridge Command goes only 1 character in the current direction, because the interpreter moves to the next character too.
            command.Execute(command.Program, logger);

            Assert.IsTrue(command.Program.Position.X == 1 && command.Program.Position.Y == 0);
            Assert.IsTrue(command.Program.Content[command.Program.Position.Y][command.Program.Position.X] == '2');
        }

        /// <summary>
        /// Represents a method for testing if the left direction works.
        /// </summary>
        [TestMethod]
        public void TestIfBridgeLeftIsCorrect()
        {
            ILogger logger = new LoggerReplacementInstance();

            BridgeCommand command = new BridgeCommand(new BefungeProgram(new Stack<int>(), new string[] { "12345678" }, new Position(0, 0)));
            command.Program.Direction = Direction.Left;

            Assert.IsTrue(command.Program.Position.X == 0 && command.Program.Position.Y == 0);
            Assert.IsTrue(command.Program.Content[command.Program.Position.Y][command.Program.Position.X] == '1');

            // Note: The Bridge Command goes only 1 character in the current direction, because the interpreter moves to the next character too.
            command.Execute(command.Program, logger);

            Assert.IsTrue(command.Program.Position.X == 7 && command.Program.Position.Y == 0);
            Assert.IsTrue(command.Program.Content[command.Program.Position.Y][command.Program.Position.X] == '8');
        }

        /// <summary>
        /// Represents a method for testing if the left direction works.
        /// </summary>
        [TestMethod]
        public void TestIfBridgeUpIsCorrect()
        {
            ILogger logger = new LoggerReplacementInstance();

            BridgeCommand command = new BridgeCommand(new BefungeProgram(new Stack<int>(), new string[] { "1", "2", "3" }, new Position(0, 0)));
            command.Program.Direction = Direction.Up;

            Assert.IsTrue(command.Program.Position.X == 0 && command.Program.Position.Y == 0);
            Assert.IsTrue(command.Program.Content[command.Program.Position.Y][command.Program.Position.X] == '1');

            // Note: The Bridge Command goes only 1 character in the current direction, because the interpreter moves to the next character too.
            command.Execute(command.Program, logger);

            Assert.IsTrue(command.Program.Position.X == 0 && command.Program.Position.Y == 2);
            Assert.IsTrue(command.Program.Content[command.Program.Position.Y][command.Program.Position.X] == '3');
        }

        /// <summary>
        /// Represents a method for testing if the down direction works.
        /// </summary>
        [TestMethod]
        public void TestIfBridgeDownIsCorrect()
        {
            ILogger logger = new LoggerReplacementInstance();

            BridgeCommand command = new BridgeCommand(new BefungeProgram(new Stack<int>(), new string[] { "1", "2", "3" }, new Position(0, 0)));
            command.Program.Direction = Direction.Down;

            Assert.IsTrue(command.Program.Position.X == 0 && command.Program.Position.Y == 0);
            Assert.IsTrue(command.Program.Content[command.Program.Position.Y][command.Program.Position.X] == '1');

            // Note: The Bridge Command goes only 1 character in the current direction, because the interpreter moves to the next character too.
            command.Execute(command.Program, logger);

            Assert.IsTrue(command.Program.Position.X == 0 && command.Program.Position.Y == 1);
            Assert.IsTrue(command.Program.Content[command.Program.Position.Y][command.Program.Position.X] == '2');
        }
    }
}
