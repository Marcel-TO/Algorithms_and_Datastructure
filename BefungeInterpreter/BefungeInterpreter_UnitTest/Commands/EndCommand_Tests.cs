//-----------------------------------------------------------------------
// <copyright file="EndCommand_Tests.cs" company="FHWN">
//     Copyright (c) Marcel Turobin-Ort. All rights reserved.
// </copyright>
// <author>Marcel Turobin-Ort</author>
// <summary>Defines the test class for the end command class.</summary>
//-----------------------------------------------------------------------
namespace BefungeInterpreter_UnitTest.Commands
{
    using System;
    using System.Collections.Generic;
    using BefungeInterpreter.Commands;
    using BefungeInterpreter.Logic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Represents the unit tests for the end command class.
    /// </summary>
    [TestClass]
    public class EndCommand_Tests
    {
        /// <summary>
        /// Represents a method for testing if parameters are null.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestIfParameterIsNull()
        {
            EndCommand command = new EndCommand(null);
        }

        /// <summary>
        /// Represents a method if execute reacts properly to null program.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestIfProgramInExecuteIsNull()
        {
            EndCommand command = new EndCommand(new BefungeProgram(new Stack<int>(), new string[] { "@" }, new Position(0, 0)));

            command.Execute(null);
        }

        /// <summary>
        /// Represents am method for testing if end command works properly.
        /// </summary>
        [TestMethod]
        public void TestIfEndIsCorrect()
        {
            EndCommand command = new EndCommand(new BefungeProgram(new Stack<int>(), new string[] { "@" }, new Position(0, 0)));
            Assert.IsFalse(command.Program.IsInterpreted);

            command.Execute(command.Program);
            Assert.IsTrue(command.Program.IsInterpreted);
        }
    }
}
