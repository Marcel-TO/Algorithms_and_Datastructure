namespace UnitTest.Logic
{
    using System;
    using System.Reflection;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using SplayTree.Commands;
    using SplayTree.Logic;
    using UnitTest.Replacements;

    [TestClass]
    public class ApplicationLogic_Test
    {
        /*
         * Fehlt:
         * 
         * ExecuteCommand
         * KeyPressed Event
         * Start()
         * Index GET SET
         * Execute SET
         * SETs in gerenal
         */

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

        [TestMethod]
        public void TestStartMethod()
        {
            ApplicationLogic logic = new ApplicationLogic(new ConsoleLoggerTestInstance(), new KeyboardWatcherTestInstance());

            logic.Start();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestConsoleLogger_Null()
        {
            ApplicationLogic logic = new ApplicationLogic(null, new KeyboardWatcherTestInstance());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestKeyboardWatcher_Null()
        {
            ApplicationLogic logic = new ApplicationLogic(new ConsoleLoggerTestInstance(), null);
        }
    }
}
