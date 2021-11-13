namespace UnitTest.Commands
{
    using System;
    using System.Collections.Generic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using SplayTree.Commands;
    using SplayTree.Interfaces;
    using SplayTree.Logic;
    using SplayTree.Trees;

    [TestClass]
    public class BaseCommand_Test
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestIfSplayTreeIsNull()
        {
            ClearCommand command = new ClearCommand(null);
        }

        [TestMethod]
        public void TestIfInitializerIsCorrect()
        {
            ClearCommand command = new ClearCommand(new SplayTree_int(new List<Node>()));

            Assert.IsNotNull(command.Initializer);
            Assert.IsTrue(command.Initializer == "fn");
        }

        [TestMethod]
        public void TestIfGetNameIsCorrect()
        {
            ClearCommand command = new ClearCommand(new SplayTree_int(new List<Node>()));

            Assert.IsNotNull(command.Name);
            Assert.IsTrue(command.Name == "clear");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestIfNodesNull()
        {
            ClearCommand command = new ClearCommand(new SplayTree_int(null));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestIfSetNodesIsCorrect()
        {
            ClearCommand command = new ClearCommand(new SplayTree_int(new List<Node>()));

            command.Nodes = null;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestIfSetNameIsCorrect()
        {
            ClearCommand command = new ClearCommand(new SplayTree_int(new List<Node>()));

            command.Nodes = null;
        }
    }
}
