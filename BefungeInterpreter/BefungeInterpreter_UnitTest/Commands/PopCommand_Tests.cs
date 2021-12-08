//-----------------------------------------------------------------------
// <copyright file="PopCommand_Tests.cs" company="FHWN">
//     Copyright (c) Marcel Turobin-Ort. All rights reserved.
// </copyright>
// <author>Marcel Turobin-Ort</author>
// <summary>Defines the test class for the pop command class.</summary>
//-----------------------------------------------------------------------
namespace BefungeInterpreter_UnitTest.Commands
{
    using System;
    using System.Collections.Generic;
    using BefungeInterpreter.Commands;
    using BefungeInterpreter.Logic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Represents the unit tests for the pop command class.
    /// </summary>
    [TestClass]
    public class PopCommand_Tests
    {
        /// <summary>
        /// Represents a method for testing if parameters are null.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestIfParameterIsNull()
        {
            PopCommand command = new PopCommand(null);
        }

        /// <summary>
        /// Represents a method if execute reacts properly to null program.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestIfProgramInExecuteIsNull()
        {
            PopCommand command = new PopCommand(new BefungeProgram(new Stack<int>(), new string[] { "$" }, new Position(0, 0)));

            command.Execute(null);
        }

        /// <summary>
        /// Represents a method for testing if pop command works properly.
        /// </summary>
        [TestMethod]
        public void TestIfDuplicationIsCorrect()
        {
            PopCommand command = new PopCommand(new BefungeProgram(new Stack<int>(), new string[] { "$" }, new Position(0, 0)));
            command.Program.StackPush(3);
            Assert.IsTrue(command.Program.Stack.Count == 1);

            command.Execute(command.Program);

            Assert.IsTrue(command.Program.Stack.Count == 0);
        }

        /// <summary>
        /// Represents a method for testing if pop command reacts properly to no stack values.
        /// </summary>
        [TestMethod]
        public void TestIfStackIsEmpty()
        {
            PopCommand command = new PopCommand(new BefungeProgram(new Stack<int>(), new string[] { "$" }, new Position(0, 0)));
            Assert.IsTrue(command.Program.Stack.Count == 0);
            command.Execute(command.Program);
            Assert.IsTrue(command.Program.Stack.Count == 0);
        }
    }
}
