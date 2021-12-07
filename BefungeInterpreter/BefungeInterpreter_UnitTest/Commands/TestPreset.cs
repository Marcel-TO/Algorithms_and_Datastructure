//-----------------------------------------------------------------------
// <copyright file="TestPreset.cs" company="FHWN">
//     Copyright (c) Marcel Turobin-Ort. All rights reserved.
// </copyright>
// <author>Marcel Turobin-Ort</author>
// <summary>Defines the test class for the down command class.</summary>
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
    public class TestPreset
    {
        /// <summary>
        /// Represents a method for testing if parameters are null.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestIfParameterIsNull()
        {
            BridgeCommand command = new BridgeCommand(null);
        }

        /// <summary>
        /// Represents a method for testing if add command works properly.
        /// </summary>
        [TestMethod]
        public void TestIfDuplicationIsCorrect()
        {
            AddCommand command = new AddCommand(new BefungeProgram(new Stack<int>(), new string[] { "+" }, new Position(0, 0)));
        }
    }
}
