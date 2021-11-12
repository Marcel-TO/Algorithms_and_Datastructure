namespace UnitTest.Commands
{
    using System;
    using System.Collections.Generic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using SplayTree.Commands;
    using SplayTree.Exceptions;
    using SplayTree.Interfaces;
    using SplayTree.Logic;
    using SplayTree.Trees;

    [TestClass]
    public class CountCommand_Test
    {
        [TestMethod]
        [ExpectedException(typeof(TreeIsEmptyException))]
        public  void TestIfTreeIsEmpty()
        {
            ILogger logger = new ConsoleLogger();

            SplayTree_int splaytree = new SplayTree_int(new List<Node>());
            CountCommand command = new CountCommand(splaytree);

            int count = command.Execute();
        }

        [TestMethod]
        public  void TestIfCountingIsCorrect()
        {
            ILogger logger = new ConsoleLogger();
            Executioner execute = new Executioner(logger);

            SplayTree_int splaytree = new SplayTree_int(execute.GenerateTree(new List<int> {7,9,3,6,5}));
            CountCommand command = new CountCommand(splaytree);

            int count = command.Execute();

            Assert.IsTrue(count == 5);
        }
    }
}