//-----------------------------------------------------------------------
// <copyright file="SwapCommand_Tests.cs" company="FHWN">
//     Copyright (c) Marcel Turobin-Ort. All rights reserved.
// </copyright>
// <author>Marcel Turobin-Ort</author>
// <summary>Defines the test class for the swap command class.</summary>
//-----------------------------------------------------------------------
namespace BefungeInterpreter_UnitTest.Commands
{
    using System;
    using System.Collections.Generic;
    using BefungeInterpreter.Commands;
    using BefungeInterpreter.Logic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Represents the unit tests for the swap command class.
    /// </summary>
    [TestClass]
    public class SwapCommand_Tests
    {
        /// <summary>
        /// Represents a method for testing if parameters are null.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestIfParameterIsNull()
        {
            SwapCommand command = new SwapCommand(null);
        }

        /// <summary>
        /// Represents a method if execute reacts properly to null program.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestIfProgramInExecuteIsNull()
        {
            SwapCommand command = new SwapCommand(new BefungeProgram(new Stack<int>(), new string[] { "\\" }, new Position(0, 0)));

            command.Execute(null);
        }

        /// <summary>
        /// Represents a method for testing if swap command works properly.
        /// </summary>
        [TestMethod]
        public void TestIfDuplicationIsCorrect()
        {
            SwapCommand command = new SwapCommand(new BefungeProgram(new Stack<int>(), new string[] { "\\" }, new Position(0, 0)));
            command.Program.StackPush(5);
            command.Program.StackPush(3);

            Assert.IsTrue(command.Program.ValueList[0] == 5);
            Assert.IsTrue(command.Program.ValueList[1] == 3);

            command.Execute(command.Program);

            Assert.IsTrue(command.Program.Stack.Pop() == 5);
            Assert.IsTrue(command.Program.Stack.Pop() == 3);
        }

        /// <summary>
        /// Represents a method for testing if the stack is empty.
        /// </summary>
        [TestMethod]
        public void TestIfStackIsEmpty()
        {
            SwapCommand command = new SwapCommand(new BefungeProgram(new Stack<int>(), new string[] { "\\" }, new Position(0, 0)));

            command.Execute(command.Program);

            Assert.IsTrue(command.Program.Stack.Pop() == 0);
            Assert.IsTrue(command.Program.Stack.Pop() == 0);
        }

        /// <summary>
        /// Represents a method for testing if stack doesn't have enough values.
        /// </summary>
        [TestMethod]
        public void TestIfStackIsNotEnough()
        {
            SwapCommand command = new SwapCommand(new BefungeProgram(new Stack<int>(), new string[] { "\\" }, new Position(0, 0)));
            command.Program.StackPush(3);

            command.Execute(command.Program);

            Assert.IsTrue(command.Program.Stack.Pop() == 0);
            Assert.IsTrue(command.Program.Stack.Pop() == 3);
        }
    }
}
