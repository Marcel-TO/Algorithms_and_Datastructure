//-----------------------------------------------------------------------
// <copyright file="MultiplyCommand_Tests.cs" company="FHWN">
//     Copyright (c) Marcel Turobin-Ort. All rights reserved.
// </copyright>
// <author>Marcel Turobin-Ort</author>
// <summary>Defines the test class for the multiplication command class.</summary>
//-----------------------------------------------------------------------
namespace BefungeInterpreter_UnitTest.Commands
{
    using System;
    using System.Collections.Generic;
    using BefungeInterpreter.Commands;
    using BefungeInterpreter.Logic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Represents the unit tests for the multiplication command class.
    /// </summary>
    [TestClass]
    public class MultiplyCommand_Tests
    {
        /// <summary>
        /// Represents a method for testing if parameters are null.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestIfParameterIsNull()
        {
            MultiplyCommand command = new MultiplyCommand(null);
        }

        /// <summary>
        /// Represents a method if execute reacts properly to null program.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestIfProgramInExecuteIsNull()
        {
            MultiplyCommand command = new MultiplyCommand(new BefungeProgram(new Stack<int>(), new string[] { "*" }, new Position(0, 0)));

            command.Execute(null);
        }

        /// <summary>
        /// Represents a method for testing if multiplication command works properly.
        /// </summary>
        [TestMethod]
        public void TestIfMultiplicationIsCorrect()
        {
            MultiplyCommand command = new MultiplyCommand(new BefungeProgram(new Stack<int>(), new string[] { "*" }, new Position(0, 0)));

            command.Program.StackPush(8);
            command.Program.StackPush(4);
            Assert.IsTrue(command.Program.Stack.Count == 2);

            command.Execute(command.Program);

            Assert.IsTrue(command.Program.Stack.Count == 1);
            Assert.IsTrue(command.Program.Stack.Peek() == 32);
        }

        /// <summary>
        /// Represents a method for testing if multiply command reacts properly to no stack values.
        /// </summary>
        [TestMethod]
        public void TestIfStackIsEmpty()
        {
            MultiplyCommand command = new MultiplyCommand(new BefungeProgram(new Stack<int>(), new string[] { "*" }, new Position(0, 0)));

            command.Execute(command.Program);

            Assert.IsTrue(command.Program.Stack.Count == 1);
            Assert.IsTrue(command.Program.Stack.Peek() == 0);
        }

        /// <summary>
        /// Represents a method for testing if multiply command reacts properly if stack doesn't have enough values.
        /// </summary>
        [TestMethod]
        public void TestIfStackIsNotEnough()
        {
            MultiplyCommand command = new MultiplyCommand(new BefungeProgram(new Stack<int>(), new string[] { "*" }, new Position(0, 0)));
            command.Program.StackPush(3);

            command.Execute(command.Program);

            Assert.IsTrue(command.Program.Stack.Count == 1);
            Assert.IsTrue(command.Program.Stack.Peek() == 0);
        }

        /// <summary>
        /// Represents a method for testing if multiply command reacts properly if stack contains string values.
        /// </summary>
        [TestMethod]
        public void TestIfStackContainsStrings()
        {
            MultiplyCommand command = new MultiplyCommand(new BefungeProgram(new Stack<int>(), new string[] { "*" }, new Position(0, 0)));
            command.Program.StackPush(104);
            command.Program.StackPush(105);

            command.Execute(command.Program);

            Assert.IsTrue(command.Program.Stack.Count == 1);
            Assert.IsTrue(command.Program.Stack.Peek() == 10920);
        }
    }
}
