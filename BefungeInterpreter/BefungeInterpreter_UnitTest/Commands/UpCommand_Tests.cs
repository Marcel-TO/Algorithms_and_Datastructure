//-----------------------------------------------------------------------
// <copyright file="UpCommand_Tests.cs" company="FHWN">
//     Copyright (c) Marcel Turobin-Ort. All rights reserved.
// </copyright>
// <author>Marcel Turobin-Ort</author>
// <summary>Defines the test class for the up command class.</summary>
//-----------------------------------------------------------------------
namespace BefungeInterpreter_UnitTest.Commands
{
    using System;
    using System.Collections.Generic;
    using BefungeInterpreter.Commands;
    using BefungeInterpreter.Logic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Represents the unit tests for the up command class.
    /// </summary>
    [TestClass]
    public class UpCommand_Tests
    {
        /// <summary>
        /// Represents a method for testing if parameters are null.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestIfParameterIsNull()
        {
            UpCommand command = new UpCommand(null);
        }

        /// <summary>
        /// Represents a method if execute reacts properly to null program.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestIfProgramInExecuteIsNull()
        {
            UpCommand command = new UpCommand(new BefungeProgram(new Stack<int>(), new string[] { "^" }, new Position(0, 0)));

            command.Execute(null);
        }

        /// <summary>
        /// Represents a method for testing if up command works properly.
        /// </summary>
        [TestMethod]
        public void TestIfDownIsCorrect()
        {
            UpCommand command = new UpCommand(new BefungeProgram(new Stack<int>(), new string[] { "^" }, new Position(0, 0)));
            Assert.IsTrue(command.Program.Direction == Direction.Right);

            command.Execute(command.Program);
            Assert.IsTrue(command.Program.Direction == Direction.Up);
        }
    }
}
