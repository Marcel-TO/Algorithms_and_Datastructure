//-----------------------------------------------------------------------
// <copyright file="Interpreter_Tests.cs" company="FHWN">
//     Copyright (c) Marcel Turobin-Ort. All rights reserved.
// </copyright>
// <author>Marcel Turobin-Ort</author>
// <summary>Defines the test class for the interpreter class.</summary>
//-----------------------------------------------------------------------
namespace BefungeInterpreter_UnitTest.Logic
{
    using System;
    using System.IO;
    using BefungeInterpreter.Factory;
    using BefungeInterpreter.Interfaces;
    using BefungeInterpreter.Logic;
    using BefungeInterpreter_UnitTests.TestInstances;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Represents the unit tests for the interpreter class.
    /// </summary>
    [TestClass]
    public class Interpreter_Tests
    {
        /// <summary>
        /// Represents a method for testing if logger is null.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestIfLoggerIsNull()
        {
            Interpreter interpreter = new Interpreter(null, new Executioner(new LoggerReplacementInstance()));
        }

        /// <summary>
        /// Represents a method for testing if visitor is null.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestIfVisitorIsNull()
        {
            Interpreter interpreter = new Interpreter(new LoggerReplacementInstance(), null);
        }

        /// <summary>
        /// Represents a method for testing if get for the keyboard property works properly.
        /// </summary>
        [TestMethod]
        public void TestIfKeyboardWatcherGetWorks()
        {
            ILogger logger = new LoggerReplacementInstance();

            Interpreter interpreter = new Interpreter(logger, new Executioner(logger));

            Assert.IsNotNull(interpreter.KeyboardWatcher);
        }

        /// <summary>
        /// Represents a method for testing if set for the keyboard property works properly if null.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestIfKeyboardWatcherSetWorks()
        {
            ILogger logger = new LoggerReplacementInstance();

            Interpreter interpreter = new Interpreter(logger, new Executioner(logger));
            interpreter.KeyboardWatcher = new KeyboardWatcherReplacement();

            interpreter.KeyboardWatcher = null;
        }

        /// <summary>
        /// Represents a method for testing if keyboard watcher works properly.
        /// </summary>
        [TestMethod]
        public void TestIfKeyboardWatcherWorks()
        {
            ILogger logger = new LoggerReplacementInstance();

            Interpreter interpreter = new Interpreter(logger, new Executioner(logger));
            interpreter.KeyboardWatcher = new KeyboardWatcherReplacement();

            interpreter.KeyboardWatcher.Start();
        }

        /// <summary>
        /// Represents a method for testing if method works properly.
        /// </summary>
        [TestMethod]
        public void TestIfRunBefungeMethodWorks()
        {
            ILogger logger = new LoggerReplacementInstance();

            Interpreter interpreter = new Interpreter(logger, new Executioner(logger));
            interpreter.KeyboardWatcher = new KeyboardWatcherReplacement();

            BefungeProgramFactory factory = new BefungeProgramFactory();
            BefungeProgram program = factory.CreateBefungeProgram(Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..\..\ExamplePrograms\hello.txt")));

            interpreter.RunBefungeProgram(program);
        }
    }
}
