//-----------------------------------------------------------------------
// <copyright file="InputCommand_Char_Tests.cs" company="FHWN">
//     Copyright (c) Marcel Turobin-Ort. All rights reserved.
// </copyright>
// <author>Marcel Turobin-Ort</author>
// <summary>Defines the test class for the character input command class.</summary>
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
    /// Represents the unit tests for the character input command class.
    /// </summary>
    [TestClass]
    public class InputCommand_Char_Tests
    {
        /// <summary>
        /// Represents a method for testing if parameters are null.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestIfParameterIsNull()
        {
            InputCommand_Char command = new InputCommand_Char(null);
        }

        /// <summary>
        /// Represents a method if execute reacts properly to null program.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestIfProgramInExecuteIsNull()
        {
            ILogger logger = new LoggerReplacementInstance();

            InputCommand_Char command = new InputCommand_Char(new BefungeProgram(new Stack<int>(), new string[] { "~" }, new Position(0, 0)));

            command.Execute(null, logger.GetUserCharInput(), logger);
        }

        /// <summary>
        /// Represents a method if execute reacts properly to wrong character.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestIfCharacterInExecuteIsWrong()
        {
            ILogger logger = new LoggerReplacementInstance();

            InputCommand_Char command = new InputCommand_Char(new BefungeProgram(new Stack<int>(), new string[] { "~" }, new Position(0, 0)));

            command.Execute(command.Program, 'Ä', logger);
        }

        /// <summary>
        /// Represents a method if execute reacts properly to null logger.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestIfLoggerInExecuteIsNull()
        {
            ILogger logger = new LoggerReplacementInstance();

            InputCommand_Char command = new InputCommand_Char(new BefungeProgram(new Stack<int>(), new string[] { "~" }, new Position(0, 0)));

            command.Execute(null, logger.GetUserCharInput(), null);
        }

        /// <summary>
        /// Represents a method for testing if the character input command is working properly.
        /// </summary>
        [TestMethod]
        public void TestIfInputCharIsCorrect()
        {
            ILogger logger = new LoggerReplacementInstance();

            InputCommand_Char command = new InputCommand_Char(new BefungeProgram(new Stack<int>(), new string[] { "~" }, new Position(0, 0)));

            command.Execute(command.Program, logger.GetUserCharInput(), logger);

            Assert.IsTrue(command.Program.Stack.Count == 1);
            Assert.IsTrue(command.Program.Stack.Peek() == 104);
        }
    }
}
