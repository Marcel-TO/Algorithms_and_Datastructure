//-----------------------------------------------------------------------
// <copyright file="Executioner_Tests.cs" company="FHWN">
//     Copyright (c) Marcel Turobin-Ort. All rights reserved.
// </copyright>
// <author>Marcel Turobin-Ort</author>
// <summary>Defines the test class for the execution class.</summary>
//-----------------------------------------------------------------------
namespace BefungeInterpreter_UnitTest.Logic
{
    using System;
    using BefungeInterpreter.Interfaces;
    using BefungeInterpreter.Logic;
    using BefungeInterpreter_UnitTests.TestInstances;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Represents the unit tests for the execution class.
    /// </summary>
    [TestClass]
    public class Executioner_Tests
    {
        /// <summary>
        /// Represents a method for testing if parameters are null.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestIfParameterIsNull()
        {
            Executioner execute = new Executioner(null);
        }

        /// <summary>
        /// Represents a method for testing if logger is not null.
        /// </summary>
        [TestMethod]
        public void TestIfLoggerIsNotNull()
        {
            ILogger logger = new LoggerReplacementInstance();

            Executioner execute = new Executioner(logger);

            Assert.IsNotNull(execute.Logger);
        }
    }
}
