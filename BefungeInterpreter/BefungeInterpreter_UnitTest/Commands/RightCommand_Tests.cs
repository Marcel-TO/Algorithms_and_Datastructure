//-----------------------------------------------------------------------
// <copyright file="RightCommand_Tests.cs" company="FHWN">
//     Copyright (c) Marcel Turobin-Ort. All rights reserved.
// </copyright>
// <author>Marcel Turobin-Ort</author>
// <summary>Defines the test class for the right command class.</summary>
//-----------------------------------------------------------------------
namespace BefungeInterpreter_UnitTest.Commands
{
    using System;
    using System.Collections.Generic;
    using BefungeInterpreter.Commands;
    using BefungeInterpreter.Logic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Represents the unit tests for the right command class.
    /// </summary>
    [TestClass]
    public class RightCommand_Tests
    {
        /// <summary>
        /// Represents a method for testing if parameters are null.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestIfParameterIsNull()
        {
            RightCommand command = new RightCommand(null);
        }

        /// <summary>
        /// Represents a method if execute reacts properly to null program.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestIfProgramInExecuteIsNull()
        {
            RightCommand command = new RightCommand(new BefungeProgram(new Stack<int>(), new string[] { ">" }, new Position(0, 0)));

            command.Execute(null);
        }

        /// <summary>
        /// Represents a method for testing if right command works properly.
        /// </summary>
        [TestMethod]
        public void TestIfDownIsCorrect()
        {
            RightCommand command = new RightCommand(new BefungeProgram(new Stack<int>(), new string[] { ">" }, new Position(0, 0)));
            command.Program.Direction = Direction.Up;
            Assert.IsTrue(command.Program.Direction == Direction.Up);

            command.Execute(command.Program);
            Assert.IsTrue(command.Program.Direction == Direction.Right);
        }
    }
}
