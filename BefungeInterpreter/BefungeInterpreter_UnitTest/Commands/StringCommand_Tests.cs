//-----------------------------------------------------------------------
// <copyright file="StringCommand_Tests.cs" company="FHWN">
//     Copyright (c) Marcel Turobin-Ort. All rights reserved.
// </copyright>
// <author>Marcel Turobin-Ort</author>
// <summary>Defines the test class for the string command class.</summary>
//-----------------------------------------------------------------------
namespace BefungeInterpreter_UnitTest.Commands
{
    using System;
    using System.Collections.Generic;
    using BefungeInterpreter.Commands;
    using BefungeInterpreter.Logic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Represents the unit tests for the string command class.
    /// </summary>
    [TestClass]
    public class StringCommand_Tests
    {
        /// <summary>
        /// Represents a method for testing if parameters are null.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestIfParameterIsNull()
        {
            StringCommand command = new StringCommand(null);
        }

        /// <summary>
        /// Represents a method if execute reacts properly to null program.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestIfProgramInExecuteIsNull()
        {
            StringCommand command = new StringCommand(new BefungeProgram(new Stack<int>(), new string[] { "\"" }, new Position(0, 0)));

            command.Execute(null);
        }

        /// <summary>
        /// Represents a method for testing if string command works properly.
        /// </summary>
        [TestMethod]
        public void TestIfDuplicationIsCorrect()
        {
            StringCommand command = new StringCommand(new BefungeProgram(new Stack<int>(), new string[] { "\"" }, new Position(0, 0)));
            Assert.IsFalse(command.Program.IsStringFormat);

            command.Execute(command.Program);
            Assert.IsTrue(command.Program.IsStringFormat);

            command.Execute(command.Program);
            Assert.IsFalse(command.Program.IsStringFormat);
        }
    }
}
