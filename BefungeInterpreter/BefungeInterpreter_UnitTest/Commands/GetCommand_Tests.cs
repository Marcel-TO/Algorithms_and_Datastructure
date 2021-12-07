//-----------------------------------------------------------------------
// <copyright file="GetCommand_Tests.cs" company="FHWN">
//     Copyright (c) Marcel Turobin-Ort. All rights reserved.
// </copyright>
// <author>Marcel Turobin-Ort</author>
// <summary>Defines the test class for the get command class.</summary>
//-----------------------------------------------------------------------
namespace BefungeInterpreter_UnitTest.Commands
{
    using System;
    using System.Collections.Generic;
    using BefungeInterpreter.Commands;
    using BefungeInterpreter.Logic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Represents the unit tests for the get command class.
    /// </summary>
    [TestClass]
    public class GetCommand_Tests
    {
        /// <summary>
        /// Represents a method for testing if parameters are null.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestIfParameterIsNull()
        {
            GetCommand command = new GetCommand(null);
        }

        /// <summary>
        /// Represents a method if execute reacts properly to null program.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestIfProgramInExecuteIsNull()
        {
            GetCommand command = new GetCommand(new BefungeProgram(new Stack<int>(), new string[] { "g" }, new Position(0, 0)));

            command.Execute(null);
        }

        /// <summary>
        /// Represents a method for testing if get command works properly.
        /// </summary>
        [TestMethod]
        public void TestIfGetIsCorrect()
        {
            GetCommand command = new GetCommand(new BefungeProgram(new Stack<int>(), new string[] { "30g,@" }, new Position(0, 0)));
            command.Program.StackPush(3);
            command.Program.StackPush(0);

            command.Execute(command.Program);

            Assert.IsTrue(command.Program.Stack.Count == 1);
            Assert.IsTrue(command.Program.Stack.Peek() == 44);
        }

        /// <summary>
        /// Represents a method for testing if stack is empty.
        /// </summary>
        [TestMethod]
        public void TestIfStackIsEmpty()
        {
            GetCommand command = new GetCommand(new BefungeProgram(new Stack<int>(), new string[] { "g" }, new Position(0, 0)));

            command.Execute(command.Program);

            Assert.IsTrue(command.Program.Stack.Count == 1);
            Assert.IsTrue(command.Program.Stack.Peek() == 103);
        }

        /// <summary>
        /// Represents a method for testing if stack doesn't have enough values.
        /// </summary>
        [TestMethod]
        public void TestIfStackIsNotEnough()
        {
            GetCommand command = new GetCommand(new BefungeProgram(new Stack<int>(), new string[] { "g" }, new Position(0, 0)));
            command.Program.StackPush(0);

            command.Execute(command.Program);

            Assert.IsTrue(command.Program.Stack.Count == 1);
            Assert.IsTrue(command.Program.Stack.Peek() == 103);
        }

        /// <summary>
        /// Represents a method for testing if values are out of range.
        /// </summary>
        public void TestIfStackValuesAreOutOfRange()
        {
            GetCommand command = new GetCommand(new BefungeProgram(new Stack<int>(), new string[] { "4g" }, new Position(0, 0)));
            command.Program.StackPush(4);

            command.Execute(command.Program);

            Assert.IsTrue(command.Program.Stack.Count == 1);
            Assert.IsTrue(command.Program.Stack.Peek() == 32);
        }
    }
}
