//-----------------------------------------------------------------------
// <copyright file="IfCommand_V_Tests.cs" company="FHWN">
//     Copyright (c) Marcel Turobin-Ort. All rights reserved.
// </copyright>
// <author>Marcel Turobin-Ort</author>
// <summary>Defines the test class for the vertical if command class.</summary>
//-----------------------------------------------------------------------
namespace BefungeInterpreter_UnitTest.Commands
{
    using System;
    using System.Collections.Generic;
    using BefungeInterpreter.Commands;
    using BefungeInterpreter.Logic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Represents the unit tests for the vertical if command class.
    /// </summary>
    [TestClass]
    public class IfCommand_V_Tests
    {
        /// <summary>
        /// Represents a method for testing if parameters are null.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestIfParameterIsNull()
        {
            IfCommand_V command = new IfCommand_V(null);
        }

        /// <summary>
        /// Represents a method if execute reacts properly to null program.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestIfProgramInExecuteIsNull()
        {
            IfCommand_V command = new IfCommand_V(new BefungeProgram(new Stack<int>(), new string[] { "|" }, new Position(0, 0)));

            command.Execute(null);
        }

        /// <summary>
        /// Represents a method for testing if horizontal if command works properly.
        /// </summary>
        [TestMethod]
        public void TestILeftIsCorrect()
        {
            IfCommand_V command = new IfCommand_V(new BefungeProgram(new Stack<int>(), new string[] { "|" }, new Position(0, 0)));
            command.Program.StackPush(1);
            Assert.IsTrue(command.Program.Direction == Direction.Right);

            command.Execute(command.Program);
            Assert.IsTrue(command.Program.Direction == Direction.Up);
        }

        /// <summary>
        /// Represents a method for testing if horizontal if command works properly.
        /// </summary>
        [TestMethod]
        public void TestIRightIsCorrect()
        {
            IfCommand_V command = new IfCommand_V(new BefungeProgram(new Stack<int>(), new string[] { "|" }, new Position(0, 0)));
            command.Program.StackPush(0);
            Assert.IsTrue(command.Program.Direction == Direction.Right);

            command.Execute(command.Program);
            Assert.IsTrue(command.Program.Direction == Direction.Down);
        }

        /// <summary>
        /// Represents a method for testing if stack is empty.
        /// </summary>
        [TestMethod]
        public void TestIfStackIsEmpty()
        {
            IfCommand_V command = new IfCommand_V(new BefungeProgram(new Stack<int>(), new string[] { "|" }, new Position(0, 0)));

            command.Execute(command.Program);
            Assert.IsTrue(command.Program.Direction == Direction.Down);
        }

        /// <summary>
        /// Represents a method for testing if command reacts properly to string values.
        /// </summary>
        [TestMethod]
        public void TestIfStackContainsStringValues()
        {
            IfCommand_V command = new IfCommand_V(new BefungeProgram(new Stack<int>(), new string[] { "|" }, new Position(0, 0)));
            command.Program.StackPush(104);
            Assert.IsTrue(command.Program.Direction == Direction.Right);

            command.Execute(command.Program);
            Assert.IsTrue(command.Program.Direction == Direction.Up);
        }
    }
}
