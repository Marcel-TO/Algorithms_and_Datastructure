//-----------------------------------------------------------------------
// <copyright file="DuplicationCommand_Tests.cs" company="FHWN">
//     Copyright (c) Marcel Turobin-Ort. All rights reserved.
// </copyright>
// <author>Marcel Turobin-Ort</author>
// <summary>Defines the test class for the duplication command class.</summary>
//-----------------------------------------------------------------------
namespace BefungeInterpreter_UnitTest.Commands
{
    using System;
    using System.Collections.Generic;
    using BefungeInterpreter.Commands;
    using BefungeInterpreter.Logic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Represents the unit tests for the down command class.
    /// </summary>
    [TestClass]
    public class DuplicationCommand_Tests
    {
        /// <summary>
        /// Represents a method for testing if parameters are null.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestIfParameterIsNull()
        {
            DuplicationCommand command = new DuplicationCommand(null);
        }

        /// <summary>
        /// Represents a method if execute reacts properly to null program.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestIfProgramInExecuteIsNull()
        {
            DuplicationCommand command = new DuplicationCommand(new BefungeProgram(new Stack<int>(), new string[] { ":" }, new Position(0, 0)));

            command.Execute(null);
        }

        /// <summary>
        /// Represents a method for testing if duplication command works properly.
        /// </summary>
        [TestMethod]
        public void TestIfDuplicationIsCorrect()
        {
            DuplicationCommand command = new DuplicationCommand(new BefungeProgram(new Stack<int>(), new string[] { ":" }, new Position(0, 0)));
            command.Program.StackPush(4);
            Assert.IsTrue(command.Program.Stack.Count == 1);

            command.Execute(command.Program);

            Assert.IsTrue(command.Program.Stack.Count == 2);
            Assert.IsTrue(command.Program.Stack.Pop() == 4);
            Assert.IsTrue(command.Program.Stack.Pop() == 4);
        }

        /// <summary>
        /// Represents a method for testing if stack is empty.
        /// </summary>
        [TestMethod]
        public void TestIfStackIsEmpty()
        {
            DuplicationCommand command = new DuplicationCommand(new BefungeProgram(new Stack<int>(), new string[] { ":" }, new Position(0, 0)));

            command.Execute(command.Program);

            Assert.IsTrue(command.Program.Stack.Count == 2);
            Assert.IsTrue(command.Program.Stack.Pop() == 0);
            Assert.IsTrue(command.Program.Stack.Pop() == 0);
        }

        /// <summary>
        /// Represents a method for testing if string values are working properly.
        /// </summary>
        [TestMethod]
        public void TestIfStackContainsString()
        {
            DuplicationCommand command = new DuplicationCommand(new BefungeProgram(new Stack<int>(), new string[] { ":" }, new Position(0, 0)));
            command.Program.StackPush(104);

            command.Execute(command.Program);

            Assert.IsTrue(command.Program.Stack.Count == 2);
            Assert.IsTrue(command.Program.Stack.Pop() == 104);
            Assert.IsTrue(command.Program.Stack.Pop() == 104);
        }
    }
}
