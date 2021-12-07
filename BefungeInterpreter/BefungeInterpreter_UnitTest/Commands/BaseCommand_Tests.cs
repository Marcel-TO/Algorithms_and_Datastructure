//-----------------------------------------------------------------------
// <copyright file="BaseCommand_Tests.cs" company="FHWN">
//     Copyright (c) Marcel Turobin-Ort. All rights reserved.
// </copyright>
// <author>Marcel Turobin-Ort</author>
// <summary>Defines the test class for the abstract base command class.</summary>
//-----------------------------------------------------------------------
namespace BefungeInterpreter_UnitTest.Commands
{
    using System;
    using System.Collections.Generic;
    using BefungeInterpreter.Commands;
    using BefungeInterpreter.Logic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Represents the unit tests for the abstract base command class.
    /// </summary>
    [TestClass]
    public class BaseCommand_Tests
    {
        /// <summary>
        /// Represents a method for testing if parameters are null.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestIfParameterIsNull()
        {
            AddCommand command = new AddCommand(null);
        }

        /// <summary>
        /// Represents a method for testing if the command initializer is not null.
        /// </summary>
        [TestMethod]
        public void TestIfInitializerAreCorrect()
        {
            AddCommand command = new AddCommand(new BefungeProgram(new Stack<int>(), new string[] { " " }, new Position(0, 0)));

            Assert.IsNotNull(command);
            Assert.IsTrue(command.CommandInitializer == "+");
        }

        /// <summary>
        /// Represents a method for testing if the name of a command is correct.
        /// </summary>
        [TestMethod]
        public void TestIfNameIsCorrect()
        {
            BridgeCommand command = new BridgeCommand(new BefungeProgram(new Stack<int>(), new string[] { " " }, new Position(0, 0)));

            Assert.IsNotNull(command);
            Assert.IsTrue(command.Name == "bridge");
        }

        /// <summary>
        /// Represents a method for testing if the stack is null.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestIfStackIsNull()
        {
            DivideCommand command = new DivideCommand(new BefungeProgram(null, new string[] { " " }, new Position(0, 0)));
        }

        /// <summary>
        /// Represents a method for testing if the content is null.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestIfContentIsNull()
        {
            DownCommand command = new DownCommand(new BefungeProgram(new Stack<int>(), null, new Position(0, 0)));
        }

        /// <summary>
        /// Represents a method for testing if the position is null.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestIfPositionIsNull()
        {
            DuplicationCommand command = new DuplicationCommand(new BefungeProgram(new Stack<int>(), new string[] { " " }, null));
        }
    }
}
