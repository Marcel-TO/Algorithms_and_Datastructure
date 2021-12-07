//-----------------------------------------------------------------------
// <copyright file="GreaterCommand_Tests.cs" company="FHWN">
//     Copyright (c) Marcel Turobin-Ort. All rights reserved.
// </copyright>
// <author>Marcel Turobin-Ort</author>
// <summary>Defines the test class for the greater command class.</summary>
//-----------------------------------------------------------------------
namespace BefungeInterpreter_UnitTest.Commands
{
    using System;
    using System.Collections.Generic;
    using BefungeInterpreter.Commands;
    using BefungeInterpreter.Logic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Represents the unit tests for the greater command class.
    /// </summary>
    [TestClass]
    public class GreaterCommand_Tests
    {
        /// <summary>
        /// Represents a method for testing if parameters are null.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestIfParameterIsNull()
        {
            GreaterCommand command = new GreaterCommand(null);
        }

        /// <summary>
        /// Represents a method if execute reacts properly to null program.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestIfProgramInExecuteIsNull()
        {
            GreaterCommand command = new GreaterCommand(new BefungeProgram(new Stack<int>(), new string[] { "`" }, new Position(0, 0)));

            command.Execute(null);
        }

        /// <summary>
        /// Represents a method for testing if greater command works properly.
        /// </summary>
        [TestMethod]
        public void TestIfGreaterIsCorrect()
        {
            GreaterCommand command = new GreaterCommand(new BefungeProgram(new Stack<int>(), new string[] { "`" }, new Position(0, 0)));
            command.Program.StackPush(4);
            command.Program.StackPush(3);

            command.Execute(command.Program);

            // Returns 1 because value 1 is greater than value 2.
            Assert.IsTrue(command.Program.Stack.Count == 1);
            Assert.IsTrue(command.Program.Stack.Peek() == 1);

            command.Program.StackPush(3);
            
            command.Execute(command.Program);

            // Returns 0 because value 2 is greater than value 1.
            Assert.IsTrue(command.Program.Stack.Peek() == 0);
        }

        /// <summary>
        /// Represents a method for testing if stack is empty.
        /// </summary>
        [TestMethod]
        public void TestIfStackIsEmpty()
        {
            GreaterCommand command = new GreaterCommand(new BefungeProgram(new Stack<int>(), new string[] { "`" }, new Position(0, 0)));

            command.Execute(command.Program);

            Assert.IsTrue(command.Program.Stack.Count == 1);
            Assert.IsTrue(command.Program.Stack.Peek() == 0);
        }

        /// <summary>
        /// Represents a method for testing if stack doesn't have enough values.
        /// </summary>
        [TestMethod]
        public void TestIfStackIsNotEnough()
        {
            GreaterCommand command = new GreaterCommand(new BefungeProgram(new Stack<int>(), new string[] { "`" }, new Position(0, 0)));
            command.Program.StackPush(104);

            command.Execute(command.Program);

            Assert.IsTrue(command.Program.Stack.Count == 1);
            Assert.IsTrue(command.Program.Stack.Pop() == 0);
        }
    }
}
