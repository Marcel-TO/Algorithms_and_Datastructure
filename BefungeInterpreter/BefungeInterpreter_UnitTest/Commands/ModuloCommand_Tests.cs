﻿//-----------------------------------------------------------------------
// <copyright file="ModuloCommand_Tests.cs" company="FHWN">
//     Copyright (c) Marcel Turobin-Ort. All rights reserved.
// </copyright>
// <author>Marcel Turobin-Ort</author>
// <summary>Defines the test class for the modulo command class.</summary>
//-----------------------------------------------------------------------
namespace BefungeInterpreter_UnitTest.Commands
{
    using System;
    using System.Collections.Generic;
    using BefungeInterpreter.Commands;
    using BefungeInterpreter.Logic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Represents the unit tests for the modulo command class.
    /// </summary>
    [TestClass]
    public class ModuloCommand_Tests
    {
        /// <summary>
        /// Represents a method for testing if parameters are null.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestIfParameterIsNull()
        {
            ModuloCommand command = new ModuloCommand(null);
        }

        /// <summary>
        /// Represents a method if execute reacts properly to null program.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestIfProgramInExecuteIsNull()
        {
            ModuloCommand command = new ModuloCommand(new BefungeProgram(new Stack<int>(), new string[] { "&" }, new Position(0, 0)));

            command.Execute(null);
        }

        /// <summary>
        /// Represents a method for testing if modulo command works properly.
        /// </summary>
        [TestMethod]
        public void TestIfModuloIsCorrect()
        {
            ModuloCommand command = new ModuloCommand(new BefungeProgram(new Stack<int>(), new string[] { "%" }, new Position(0, 0)));

            command.Program.StackPush(2);
            command.Program.StackPush(3);
            Assert.IsTrue(command.Program.Stack.Count == 2);

            command.Execute(command.Program);

            Assert.IsTrue(command.Program.Stack.Count == 1);
            Assert.IsTrue(command.Program.Stack.Peek() == 2);
        }

        /// <summary>
        /// Represents a method for testing if modulo command reacts properly to no stack values.
        /// </summary>
        [TestMethod]
        public void TestIfStackIsEmpty()
        {
            ModuloCommand command = new ModuloCommand(new BefungeProgram(new Stack<int>(), new string[] { "%" }, new Position(0, 0)));

            command.Execute(command.Program);

            Assert.IsTrue(command.Program.Stack.Count == 1);
            Assert.IsTrue(command.Program.Stack.Peek() == 0);
        }

        /// <summary>
        /// Represents a method for testing if modulo command reacts properly if stack doesn't have enough values.
        /// </summary>
        [TestMethod]
        public void TestIfStackIsNotEnough()
        {
            ModuloCommand command = new ModuloCommand(new BefungeProgram(new Stack<int>(), new string[] { "%" }, new Position(0, 0)));
            command.Program.StackPush(3);

            command.Execute(command.Program);

            Assert.IsTrue(command.Program.Stack.Count == 1);
            Assert.IsTrue(command.Program.Stack.Peek() == 0);
        }

        /// <summary>
        /// Represents a method for testing if modulo command reacts properly if stack contains string values.
        /// </summary>
        [TestMethod]
        public void TestIfStackContainsStrings()
        {
            ModuloCommand command = new ModuloCommand(new BefungeProgram(new Stack<int>(), new string[] { "%" }, new Position(0, 0)));
            command.Program.StackPush(105);
            command.Program.StackPush(102);

            command.Execute(command.Program);

            Assert.IsTrue(command.Program.Stack.Count == 1);
            Assert.IsTrue(command.Program.Stack.Peek() == 3);
        }
    }
}
