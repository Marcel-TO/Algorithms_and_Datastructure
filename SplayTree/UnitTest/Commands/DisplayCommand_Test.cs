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
    public class DisplayCommand_Test
    {
        [TestMethod]
        [ExpectedException(typeof(TreeIsEmptyException))]
        public  void TestIfTreeIsEmpty()
        {
            SplayTree_int splaytree = new SplayTree_int(new List<Node>());
            DisplayCommand command = new DisplayCommand(splaytree);

            command.Execute();
        }

        [TestMethod]
        public  void TestIfCommandGetsExecuted()
        {
            ILogger logger = new ConsoleLogger();
            Executioner execute = new Executioner(logger);

            SplayTree_int splaytree = new SplayTree_int(execute.GenerateTree(new List<int> {7,9,3,6,5}));
            DisplayCommand command = new DisplayCommand(splaytree);

            command.Execute();
        }
    }
}