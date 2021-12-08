//-----------------------------------------------------------------------
// <copyright file="PutCommand_Tests.cs" company="FHWN">
//     Copyright (c) Marcel Turobin-Ort. All rights reserved.
// </copyright>
// <author>Marcel Turobin-Ort</author>
// <summary>Defines the test class for the put command class.</summary>
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
    /// Represents the unit tests for the put command class.
    /// </summary>
    [TestClass]
    public class PutCommand_Tests
    {
        /// <summary>
        /// Represents a method for testing if parameters are null.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestIfParameterIsNull()
        {
            PutCommand command = new PutCommand(null);
        }

        /// <summary>
        /// Represents a method if execute reacts properly to null program.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestIfProgramInExecuteIsNull()
        {
            ILogger logger = new LoggerReplacementInstance();

            PutCommand command = new PutCommand(new BefungeProgram(new Stack<int>(), new string[] { "p" }, new Position(0, 0)));

            command.Execute(null, logger);
        }

        /// <summary>
        /// Represents a method if execute reacts properly to null logger.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestIfLoggerInExecuteIsNull()
        {
            PutCommand command = new PutCommand(new BefungeProgram(new Stack<int>(), new string[] { "p" }, new Position(0, 0)));

            command.Execute(command.Program, null);
        }

        /// <summary>
        /// Represents a method for testing if put command works properly.
        /// </summary>
        [TestMethod]
        public void TestIfGetIsCorrect()
        {
            ILogger logger = new LoggerReplacementInstance();

            PutCommand command = new PutCommand(new BefungeProgram(new Stack<int>(), new string[] { ">f00p@" }, new Position(0, 0)));
            command.Program.StackPush(102);
            command.Program.StackPush(0);
            command.Program.StackPush(0);

            command.Execute(command.Program, logger);

            Assert.IsTrue(command.Program.Stack.Count == 0);
            Assert.IsTrue(command.Program.Content[0][0] == 'f');
        }

        /// <summary>
        /// Represents a method for testing if stack is empty.
        /// </summary>
        [TestMethod]
        public void TestIfStackIsEmpty()
        {
            ILogger logger = new LoggerReplacementInstance();

            PutCommand command = new PutCommand(new BefungeProgram(new Stack<int>(), new string[] { "p" }, new Position(0, 0)));
            Assert.IsTrue(command.Program.Content[0][0] == 'p');
            command.Execute(command.Program, logger);

            Assert.IsTrue(command.Program.Content[0][0] == ' ');
        }

        /// <summary>
        /// Represents a method for testing if stack doesn't have enough values.
        /// </summary>
        [TestMethod]
        public void TestIfStackIsNotEnough()
        {
            ILogger logger = new LoggerReplacementInstance();

            PutCommand command = new PutCommand(new BefungeProgram(new Stack<int>(), new string[] { "p" }, new Position(0, 0)));
            command.Program.StackPush(0);

            command.Execute(command.Program, logger);

            Assert.IsTrue(command.Program.Stack.Count == 0);
            Assert.IsTrue(command.Program.Content[0][0] == 'p');
        }

        /// <summary>
        /// Represents a method for testing if values are out of range.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestIfStackValuesAreOutOfRange()
        {
            ILogger logger = new LoggerReplacementInstance();

            PutCommand command = new PutCommand(new BefungeProgram(new Stack<int>(), new string[] { "4p" }, new Position(0, 0)));
            command.Program.StackPush(102);
            command.Program.StackPush(4);
            command.Program.StackPush(4);

            command.Execute(command.Program, logger);
        }
    }
}
