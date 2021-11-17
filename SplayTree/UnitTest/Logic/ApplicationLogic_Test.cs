//-----------------------------------------------------------------------
// <copyright file="ApplicationLogic_Test.cs" company="FHWN">
//     Copyright (c) Marcel Turobin-Ort. All rights reserved.
// </copyright>
// <author>Marcel Turobin-Ort</author>
// <summary>Defines the test class for the application logic.</summary>
//-----------------------------------------------------------------------
namespace UnitTest.Logic
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using SplayTree.Logic;
    using UnitTest.Replacements;

    /// <summary>
    /// Represents the unit tests for the application logic.
    /// </summary>
    [TestClass]
    public class ApplicationLogic_Test
    {
        /// <summary>
        /// Represents a method for testing all properties.
        /// </summary>
        [TestMethod]
        public void TestProperties()
        {
            ApplicationLogic logic = new ApplicationLogic(new ConsoleLoggerTestInstance(), new KeyboardWatcherTestInstance());

            Assert.IsNotNull(logic.Execute);
            Assert.IsNotNull(logic.Logger);
            Assert.IsNotNull(logic.Nodes);
            Assert.IsNotNull(logic.Splaytree);
            Assert.IsNotNull(logic.KeyboardWatcher);
        }

        /// <summary>
        /// Represents a method for testing if the start method is working.
        /// </summary>
        [TestMethod]
        public void TestStartMethod()
        {
            ApplicationLogic logic = new ApplicationLogic(new ConsoleLoggerTestInstance(), new KeyboardWatcherTestInstance());

            logic.Start();
        }

        /// <summary>
        /// Represents a method for testing if the console logger is null.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestConsoleLogger_Null()
        {
            ApplicationLogic logic = new ApplicationLogic(null, new KeyboardWatcherTestInstance());
        }

        /// <summary>
        /// Represents a method for testing if the keyboard watcher is null.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestKeyboardWatcher_Null()
        {
            ApplicationLogic logic = new ApplicationLogic(new ConsoleLoggerTestInstance(), null);
        }
    }
}
