//-----------------------------------------------------------------------
// <copyright file="ApplicationLogic_Tests.cs" company="FHWN">
//     Copyright (c) Marcel Turobin-Ort. All rights reserved.
// </copyright>
// <author>Marcel Turobin-Ort</author>
// <summary>Defines the test class for the application logic class.</summary>
//-----------------------------------------------------------------------
namespace SnakesAndLadders_UnitTests.Logic
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using SnakesAndLadders.Logic;
    using SnakesAndLadders_UnitTests.ReplacementInstances;

    /// <summary>
    /// Represents the unit tests for the application logic class.
    /// </summary>
    [TestClass]
    public class ApplicationLogic_Tests
    {
        /// <summary>
        /// Represents a method for testing if logger is null.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestIfLoggerIsNull()
        {
            ApplicationLogic logic = new ApplicationLogic(null, new KeyReplacementInstance());
        }

        /// <summary>
        /// Represents a method for testing if keyboard watcher is null.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestIfKeyboardWatcherIsNull()
        {
            ApplicationLogic logic = new ApplicationLogic(new LoggerReplacementInstance(), null);
        }

        /// <summary>
        /// Represents a method for testing if constructor is null.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestIfConstructorIsNull()
        {
            ApplicationLogic logic = new ApplicationLogic(null, null);
        }

        /// <summary>
        /// Represents a method for testing if run method is working.
        /// </summary>
        [TestMethod]
        public void Start()
        {
            ApplicationLogic logic = new ApplicationLogic(new LoggerReplacementInstance(), new KeyReplacementInstance());
            logic.Run();
        }
    }
}
