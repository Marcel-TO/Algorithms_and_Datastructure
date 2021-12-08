//-----------------------------------------------------------------------
// <copyright file="SubtractCommand_Tests.cs" company="FHWN">
//     Copyright (c) Marcel Turobin-Ort. All rights reserved.
// </copyright>
// <author>Marcel Turobin-Ort</author>
// <summary>Defines the test class for the subtract command class.</summary>
//-----------------------------------------------------------------------
namespace BefungeInterpreter_UnitTest.Commands
{
    using System;
    using System.Collections.Generic;
    using BefungeInterpreter.Commands;
    using BefungeInterpreter.Logic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Represents the unit tests for the subtract command class.
    /// </summary>
    [TestClass]
    public class SubtractCommand_Tests
    {
        /// <summary>
        /// Represents a method for testing if parameters are null.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestIfParameterIsNull()
        {
            SubtractCommand command = new SubtractCommand(null);
        }

        /// <summary>
        /// Represents a method if execute reacts properly to null program.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestIfProgramInExecuteIsNull()
        {
            SubtractCommand command = new SubtractCommand(new BefungeProgram(new Stack<int>(), new string[] { "-" }, new Position(0, 0)));

            command.Execute(null);
        }

        /// <summary>
        /// Represents a method for testing if subtract command works properly.
        /// </summary>
        [TestMethod]
        public void TestIfAddIsCorrect()
        {
            SubtractCommand command = new SubtractCommand(new BefungeProgram(new Stack<int>(), new string[] { "-" }, new Position(0, 0)));

            command.Program.StackPush(5);
            command.Program.StackPush(2);
            Assert.IsTrue(command.Program.Stack.Count == 2);

            command.Execute(command.Program);

            Assert.IsTrue(command.Program.Stack.Count == 1);
            Assert.IsTrue(command.Program.Stack.Peek() == 3);
        }

        /// <summary>
        /// Represents a method for testing if the second value is bigger.
        /// </summary>
        [TestMethod]
        public void TestIfResultIsNegative()
        {
            SubtractCommand command = new SubtractCommand(new BefungeProgram(new Stack<int>(), new string[] { "-" }, new Position(0, 0)));

            command.Program.StackPush(2);
            command.Program.StackPush(4);
            Assert.IsTrue(command.Program.Stack.Count == 2);

            command.Execute(command.Program);

            Assert.IsTrue(command.Program.Stack.Count == 1);
            Assert.IsTrue(command.Program.Stack.Peek() == -2);
        }

        /// <summary>
        /// Represents a method for testing if subtract command reacts properly to no stack values.
        /// </summary>
        [TestMethod]
        public void TestIfStackIsEmpty()
        {
            SubtractCommand command = new SubtractCommand(new BefungeProgram(new Stack<int>(), new string[] { "-" }, new Position(0, 0)));

            command.Execute(command.Program);

            Assert.IsTrue(command.Program.Stack.Count == 1);
            Assert.IsTrue(command.Program.Stack.Peek() == 0);
        }

        /// <summary>
        /// Represents a method for testing if subtract command reacts properly if stack doesn't have enough values.
        /// </summary>
        [TestMethod]
        public void TestIfStackIsNotEnough()
        {
            SubtractCommand command = new SubtractCommand(new BefungeProgram(new Stack<int>(), new string[] { "-" }, new Position(0, 0)));
            command.Program.StackPush(3);

            command.Execute(command.Program);

            Assert.IsTrue(command.Program.Stack.Count == 1);
            Assert.IsTrue(command.Program.Stack.Peek() == -3);
        }

        /// <summary>
        /// Represents a method for testing if subtract command reacts properly if stack contains string values.
        /// </summary>
        [TestMethod]
        public void TestIfStackContainsStrings()
        {
            SubtractCommand command = new SubtractCommand(new BefungeProgram(new Stack<int>(), new string[] { "-" }, new Position(0, 0)));
            command.Program.StackPush(105);
            command.Program.StackPush(104);

            command.Execute(command.Program);

            Assert.IsTrue(command.Program.Stack.Count == 1);
            Assert.IsTrue(command.Program.Stack.Peek() == 1);
        }
    }
}
