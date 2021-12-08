//-----------------------------------------------------------------------
// <copyright file="RandomCommand_Tests.cs" company="FHWN">
//     Copyright (c) Marcel Turobin-Ort. All rights reserved.
// </copyright>
// <author>Marcel Turobin-Ort</author>
// <summary>Defines the test class for the random command class.</summary>
//-----------------------------------------------------------------------
namespace BefungeInterpreter_UnitTest.Commands
{
    using System;
    using System.Collections.Generic;
    using BefungeInterpreter.Commands;
    using BefungeInterpreter.Logic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Represents the unit tests for the random command class.
    /// </summary>
    [TestClass]
    public class RandomCommand_Tests
    {
        /// <summary>
        /// Represents a method for testing if parameters are null.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestIfParameterIsNull()
        {
            RandomCommand command = new RandomCommand(null);
        }

        /// <summary>
        /// Represents a method if execute reacts properly to null program.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestIfProgramInExecuteIsNull()
        {
            RandomCommand command = new RandomCommand(new BefungeProgram(new Stack<int>(), new string[] { "?" }, new Position(0, 0)));

            command.Execute(null);
        }

        /// <summary>
        /// Represents a method for testing if random command works properly.
        /// </summary>
        [TestMethod]
        public void TestIfDuplicationIsCorrect()
        {
            RandomCommand command = new RandomCommand(new BefungeProgram(new Stack<int>(), new string[] { "?" }, new Position(0, 0)));
            Assert.IsTrue(command.Program.Direction == Direction.Right);
            command.Execute(command.Program);

            // How to test random?
            Assert.IsFalse(command.Program.Direction == Direction.Right);
        }
    }
}
