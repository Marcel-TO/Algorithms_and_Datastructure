//-----------------------------------------------------------------------
// <copyright file="LeftCommand_Tests.cs" company="FHWN">
//     Copyright (c) Marcel Turobin-Ort. All rights reserved.
// </copyright>
// <author>Marcel Turobin-Ort</author>
// <summary>Defines the test class for the left command class.</summary>
//-----------------------------------------------------------------------
namespace BefungeInterpreter_UnitTest.Commands
{
    using System;
    using System.Collections.Generic;
    using BefungeInterpreter.Commands;
    using BefungeInterpreter.Logic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Represents the unit tests for the down command class.
    /// </summary>
    [TestClass]
    public class LeftCommand_Tests
    {
        /// <summary>
        /// Represents a method for testing if parameters are null.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestIfParameterIsNull()
        {
            LeftCommand command = new LeftCommand(null);
        }

        /// <summary>
        /// Represents a method if execute reacts properly to null program.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestIfProgramInExecuteIsNull()
        {
            LeftCommand command = new LeftCommand(new BefungeProgram(new Stack<int>(), new string[] { "<" }, new Position(0, 0)));

            command.Execute(null);
        }

        /// <summary>
        /// Represents a method for testing if down command works properly.
        /// </summary>
        [TestMethod]
        public void TestIfLeftIsCorrect()
        {
            LeftCommand command = new LeftCommand(new BefungeProgram(new Stack<int>(), new string[] { "12345678" }, new Position(0, 0)));
            Assert.IsTrue(command.Program.Direction == Direction.Right);

            command.Execute(command.Program);
            Assert.IsTrue(command.Program.Direction == Direction.Left);
        }
    }
}
