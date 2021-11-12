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
    public class ContainsCommand_Test
    {
        [TestMethod]
        [ExpectedException(typeof(TreeIsEmptyException))]
        public  void TestIfTreeIsEmpty()
        {
            ILogger logger = new ConsoleLogger();

            SplayTree_int splaytree = new SplayTree_int(new List<Node>());
            ContainsCommand command = new ContainsCommand(splaytree);

            bool contains = command.Execute(3);
        }

        [TestMethod]
        public  void TestIfTreeContainsNumber()
        {
            ILogger logger = new ConsoleLogger();
            Executioner execute = new Executioner(logger);

            SplayTree_int splaytree = new SplayTree_int(execute.GenerateTree(new List<int> {7,9,3,6,5}));
            ContainsCommand command = new ContainsCommand(splaytree);

            bool contains = command.Execute(3);

            Assert.IsTrue(contains);
        }

        [TestMethod]
        public  void TestIfNumberDoesNotExist()
        {
            ILogger logger = new ConsoleLogger();
            Executioner execute = new Executioner(logger);

            SplayTree_int splaytree = new SplayTree_int(execute.GenerateTree(new List<int> {7,9,3,6,5}));
            ContainsCommand command = new ContainsCommand(splaytree);

            bool contains = command.Execute(8);

            Assert.IsFalse(contains);
        }
    }
}