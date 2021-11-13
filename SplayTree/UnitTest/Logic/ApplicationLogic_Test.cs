namespace UnitTest.Logic
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using SplayTree.Commands;
    using SplayTree.Logic;

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
            ApplicationLogic logic = new ApplicationLogic();

            Assert.IsNotNull(logic.Execute);
            Assert.IsNotNull(logic.Logger);
            Assert.IsNotNull(logic.Nodes);
            Assert.IsNotNull(logic.Splaytree);
            Assert.IsNotNull(logic.KeyboardWatcher);
        }
    }
}
