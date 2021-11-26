namespace BefungeInterpreter_UnitTests.Logic
{
    using System;
    using System.Collections.Generic;
    using BefungeInterpreter.Factory;
    using BefungeInterpreter.FileInteractions;
    using BefungeInterpreter.Interfaces;
    using BefungeInterpreter.KeyboardWatcher;

    [TestClass]
    public class ApplicationLogic_Tests
    {
        [TestMethod]
        [ExpectedException(ArgumentNullException)]
        public void TestIfLoggerIsNull()
        {
            ApplicationLogic logic = new ApplicationLogic(null, new KeyboardWatcherReplacement());
        }

        [TestMethod]
        [ExpectedException(ArgumentNullException)]
        public void TestIfKeyboardWatcherIsNull()
        {
            ApplicationLogic logic = new ApplicationLogic(new LoggerReplacementInstance(), null);
        }

        [TestMethod]
        [ExpectedException(ArgumentNullException)]
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