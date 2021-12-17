//-----------------------------------------------------------------------
// <copyright file="DivideCommand_Tests.cs" company="FHWN">
//     Copyright (c) Marcel Turobin-Ort. All rights reserved.
// </copyright>
// <author>Marcel Turobin-Ort</author>
// <summary>Defines the test class for the divide command class.</summary>
//-----------------------------------------------------------------------
namespace BefungeInterpreter_UnitTest.Commands
{
    using System;
    using System.Collections.Generic;
    using BefungeInterpreter.Commands;
    using BefungeInterpreter.Logic;
    using BefungeInterpreter_UnitTests.TestInstances;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Represents the unit tests for the divide command class.
    /// </summary>
    [TestClass]
    public class DivideCommand_Tests
    {
        /// <summary>
        /// Represents a method for testing if parameters are null.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestIfParameterIsNull()
        {
            DivideCommand command = new DivideCommand(null);
        }

        /// <summary>
        /// Represents a method if execute reacts properly to null program.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestIfProgramInExecuteIsNull()
        {
            DivideCommand command = new DivideCommand(new BefungeProgram(new Stack<int>(), new string[] { "/" }, new Position(0, 0)));

            command.Execute(null, new LoggerReplacementInstance());
        }

        /// <summary>
        /// Represents a method if execute reacts properly to null logger.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestIfLoggerInExecuteIsNull()
        {
            DivideCommand command = new DivideCommand(new BefungeProgram(new Stack<int>(), new string[] { "/" }, new Position(0, 0)));

            command.Execute(command.Program, null);
        }

        /// <summary>
        /// Represents a method for testing if divide command works properly.
        /// </summary>
        [TestMethod]
        public void TestIfDivideIsCorrect()
        {
            DivideCommand command = new DivideCommand(new BefungeProgram(new Stack<int>(), new string[] { "/" }, new Position(0, 0)));

            command.Program.StackPush(8);
            command.Program.StackPush(4);
            Assert.IsTrue(command.Program.Stack.Count == 2);

            command.Execute(command.Program, new LoggerReplacementInstance());

            Assert.IsTrue(command.Program.Stack.Count == 1);
            Assert.IsTrue(command.Program.Stack.Peek() == 2);
        }

        ///// <summary>
        ///// Represents a method for testing if divide command reacts properly to no stack values.
        ///// </summary>
        //[TestMethod]
        //public void TestIfStackIsEmpty()
        //{
        //    DivideCommand command = new DivideCommand(new BefungeProgram(new Stack<int>(), new string[] { "/" }, new Position(0, 0)));

        //    command.Execute(command.Program, new LoggerReplacementInstance());

        //    Assert.IsTrue(command.Program.Stack.Count == 1);
        //    Assert.IsTrue(command.Program.Stack.Peek() == 0);
        //}

        /// <summary>
        /// Represents a method for testing if divide command reacts properly if stack doesn't have enough values.
        /// </summary>
        [TestMethod]
        public void TestIfStackIsNotEnough()
        {
            DivideCommand command = new DivideCommand(new BefungeProgram(new Stack<int>(), new string[] { "/" }, new Position(0, 0)));
            command.Program.StackPush(3);

            command.Execute(command.Program, new LoggerReplacementInstance());

            Assert.IsTrue(command.Program.Stack.Count == 1);
            Assert.IsTrue(command.Program.Stack.Peek() == 0);
        }

        /// <summary>
        /// Represents a method for testing if divide command reacts properly if stack contains string values.
        /// </summary>
        [TestMethod]
        public void TestIfStackContainsStrings()
        {
            DivideCommand command = new DivideCommand(new BefungeProgram(new Stack<int>(), new string[] { "/" }, new Position(0, 0)));
            command.Program.StackPush(104);
            command.Program.StackPush(5);

            command.Execute(command.Program, new LoggerReplacementInstance());

            Assert.IsTrue(command.Program.Stack.Count == 1);
            Assert.IsTrue(command.Program.Stack.Peek() == 20);
        }

        /// <summary>
        /// Represents a method for testing if divide command reacts properly to dividing by 0.
        /// </summary>
        [TestMethod]
        public void TestIfDivideByZeroIsCorrect()
        {
            DivideCommand command = new DivideCommand(new BefungeProgram(new Stack<int>(), new string[] { "/" }, new Position(0, 0)));
            command.Program.StackPush(5);
            command.Program.StackPush(0);

            command.Execute(command.Program, new LoggerReplacementInstance());

            Assert.IsTrue(command.Program.Stack.Count == 1);

            // It is 5 because the user gets asked what the result should be. In this case the replacement instance choses 5.
            Assert.IsTrue(command.Program.Stack.Peek() == 5);
        }
    }
}
