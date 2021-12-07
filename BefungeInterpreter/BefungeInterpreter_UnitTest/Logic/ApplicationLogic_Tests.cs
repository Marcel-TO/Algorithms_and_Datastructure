namespace BefungeInterpreter_UnitTests.Logic
{
    using System;
    using System.Collections.Generic;
    using BefungeInterpreter.Factory;
    using BefungeInterpreter.FileInteractions;
    using BefungeInterpreter.Interfaces;
    using BefungeInterpreter.KeyboardWatcher;
    using BefungeInterpreter.Logic;
    using BefungeInterpreter_UnitTests.TestInstances;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class ApplicationLogic_Tests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestIfLoggerIsNull()
        {
            ApplicationLogic logic = new ApplicationLogic(null, new KeyboardWatcherReplacement());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestIfKeyboardWatcherIsNull()
        {
            ApplicationLogic logic = new ApplicationLogic(new LoggerReplacementInstance(), null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestIfConstructorIsNull()
        {
            ApplicationLogic logic = new ApplicationLogic(null, null);
        }

        [TestMethod]
        public void Start()
        {
            ApplicationLogic logic = new ApplicationLogic(new LoggerReplacementInstance(), new KeyboardWatcherReplacement());
            logic.Start();
        }
    }
}