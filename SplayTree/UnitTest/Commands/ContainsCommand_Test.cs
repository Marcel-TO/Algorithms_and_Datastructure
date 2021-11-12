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
    public class ContainsCommand_Test
    {
        [TestMethod]
        public  void TestIfTreeIsEmpty()
        {
            ILogger logger = new ConsoleLogger();
            Executioner execute = new Executioner(logger);

            Splaytree splaytree = new Splaytree(new List<Node>());
            ContainsCommand command = new ContainsCommand(splaytree);

            bool contains = command.Execute(execute, 3);

            Assert.IsFalse(contains);
        }

        [TestMethod]
        public  void TestIfTreeContainsNumber()
        {
            ILogger logger = new ConsoleLogger();
            Executioner execute = new Executioner(logger);

            Splaytree splaytree = new Splaytree(execute.GenerateTree(new List<int> {7,9,3,6,5}));
            ContainsCommand command = new ContainsCommand(splaytree);

            bool contains = command.Execute(execute, 3);

            Assert.IsTrue(contains);
        }

        [TestMethod]
        public  void TestIfNumberDoesNotExist()
        {
            ILogger logger = new ConsoleLogger();
            Executioner execute = new Executioner(logger);

            Splaytree splaytree = new Splaytree(execute.GenerateTree(new List<int> {7,9,3,6,5}));
            ContainsCommand command = new ContainsCommand(splaytree);

            bool contains = command.Execute(execute, 8);

            Assert.IsFalse(contains);
        }
    }
}