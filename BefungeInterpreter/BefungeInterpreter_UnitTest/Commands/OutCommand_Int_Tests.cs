//-----------------------------------------------------------------------
// <copyright file="OutCommand_Int_Tests.cs" company="FHWN">
//     Copyright (c) Marcel Turobin-Ort. All rights reserved.
// </copyright>
// <author>Marcel Turobin-Ort</author>
// <summary>Defines the test class for the integer output command class.</summary>
//-----------------------------------------------------------------------
namespace BefungeInterpreter_UnitTest.Commands
{
    using System;
    using System.Collections.Generic;
    using BefungeInterpreter.Commands;
    using BefungeInterpreter.Logic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Represents the unit tests for the integer output command class.
    /// </summary>
    [TestClass]
    public class OutCommand_Int_Tests
    {
        /// <summary>
        /// Represents a method for testing if parameters are null.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestIfParameterIsNull()
        {
            OutCommand_Int command = new OutCommand_Int(null);
        }

        /// <summary>
        /// Represents a method if execute reacts properly to null program.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestIfProgramInExecuteIsNull()
        {
            OutCommand_Int command = new OutCommand_Int(new BefungeProgram(new Stack<int>(), new string[] { "." }, new Position(0, 0)));

            command.Execute(null);
        }

        /// <summary>
        /// Represents a method for testing if character output command works properly.
        /// </summary>
        [TestMethod]
        public void TestIfOutputIntIsCorrect()
        {
            OutCommand_Int command = new OutCommand_Int(new BefungeProgram(new Stack<int>(), new string[] { "." }, new Position(0, 0)));
            Assert.IsTrue(command.Program.Output.Count == 0);

            command.Program.StackPush(4);
            command.Execute(command.Program);

            Assert.IsTrue(command.Program.Output.Count == 1);
            Assert.IsTrue(command.Program.Output[command.Program.Output.Count - 1] == "4");
        }

        /// <summary>
        /// Represents a method for testing if output command reacts properly to no stack values.
        /// </summary>
        [TestMethod]
        public void TestIfStackIsEmpty()
        {
            OutCommand_Int command = new OutCommand_Int(new BefungeProgram(new Stack<int>(), new string[] { "." }, new Position(0, 0)));

            command.Execute(command.Program);

            Assert.IsTrue(command.Program.Output.Count == 1);
            Assert.IsTrue(command.Program.Output[command.Program.Output.Count - 1] == "0");
        }
    }
}
