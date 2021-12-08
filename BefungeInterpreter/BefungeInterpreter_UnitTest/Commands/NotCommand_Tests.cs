//-----------------------------------------------------------------------
// <copyright file="NotCommand_Tests.cs" company="FHWN">
//     Copyright (c) Marcel Turobin-Ort. All rights reserved.
// </copyright>
// <author>Marcel Turobin-Ort</author>
// <summary>Defines the test class for the not command class.</summary>
//-----------------------------------------------------------------------
namespace BefungeInterpreter_UnitTest.Commands
{
    using System;
    using System.Collections.Generic;
    using BefungeInterpreter.Commands;
    using BefungeInterpreter.Logic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Represents the unit tests for the not command class.
    /// </summary>
    [TestClass]
    public class NotCommand_Tests
    {
        /// <summary>
        /// Represents a method for testing if parameters are null.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestIfParameterIsNull()
        {
            NotCommand command = new NotCommand(null);
        }

        /// <summary>
        /// Represents a method if execute reacts properly to null program.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestIfProgramInExecuteIsNull()
        {
            NotCommand command = new NotCommand(new BefungeProgram(new Stack<int>(), new string[] { "!" }, new Position(0, 0)));

            command.Execute(null);
        }

        /// <summary>
        /// Represents a method for testing if not command works properly.
        /// </summary>
        [TestMethod]
        public void TestIfNotIsCorrect()
        {
            NotCommand command = new NotCommand(new BefungeProgram(new Stack<int>(), new string[] { "!" }, new Position(0, 0)));

            command.Program.StackPush(0);
            command.Execute(command.Program);
            Assert.IsTrue(command.Program.Stack.Pop() == 1);

            command.Program.StackPush(3);
            command.Execute(command.Program);
            Assert.IsTrue(command.Program.Stack.Peek() == 0);
        }

        /// <summary>
        /// Represents a method for testing if not command reacts properly to no stack values.
        /// </summary>
        [TestMethod]
        public void TestIfStackIsEmpty()
        {
            NotCommand command = new NotCommand(new BefungeProgram(new Stack<int>(), new string[] { "!" }, new Position(0, 0)));

            command.Execute(command.Program);

            Assert.IsTrue(command.Program.Stack.Count == 1);
            Assert.IsTrue(command.Program.Stack.Peek() == 1);
        }

        /// <summary>
        /// Represents a method for testing if not command reacts properly if stack contains string values.
        /// </summary>
        [TestMethod]
        public void TestIfStackContainsStrings()
        {
            NotCommand command = new NotCommand(new BefungeProgram(new Stack<int>(), new string[] { "!" }, new Position(0, 0)));
            command.Program.StackPush(104);

            command.Execute(command.Program);

            Assert.IsTrue(command.Program.Stack.Peek() == 0);
        }
    }
}
