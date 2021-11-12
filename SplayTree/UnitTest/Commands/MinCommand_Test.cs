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
    public class MinCommand_Test
    {
        [TestMethod]
        [ExpectedException(typeof(TreeIsEmptyException))]
        public  void TestIfTreeIsEmpty()
        {
            ILogger logger = new ConsoleLogger();

            SplayTree_int splaytree = new SplayTree_int(new List<Node>());
            MinCommand command = new MinCommand(splaytree);

            int min = command.Execute();
        }

        [TestMethod]
        public  void TestIfMinCorrect()
        {
            ConsoleLogger logger = new ConsoleLogger();
            Executioner execute = new Executioner(logger);

            SplayTree_int splaytree = new SplayTree_int(execute.GenerateTree(new List<int> {7,9,3,6,5}));
            MinCommand command = new MinCommand(splaytree);

            int min = command.Execute();

            for (int i = 0; i < command.Nodes.Count; i++)
            {
                Assert.IsTrue(min <= command.Nodes[i].Value);
            }
        }
    }
}