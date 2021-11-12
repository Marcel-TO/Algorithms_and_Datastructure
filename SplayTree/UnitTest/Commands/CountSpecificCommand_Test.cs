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
    public class CountSpecificCommand_Test
    {
        [TestMethod]
        public  void TestIfTreeIsEmpty()
        {
            ILogger logger = new ConsoleLogger();
            Executioner execute = new Executioner(logger);

            Splaytree splaytree = new Splaytree(new List<Node>());
            CountSpecificCommand command = new CountSpecificCommand(splaytree);

            int count = command.Execute(execute, 5);

            Assert.IsTrue(count == 0);
        }

        [TestMethod]
        public  void TestIfNumberDoesNotExist()
        {
            ConsoleLogger logger = new ConsoleLogger();
            Executioner execute = new Executioner(logger);

            Splaytree splaytree = new Splaytree(execute.GenerateTree(new List<int> {7,9,3,6,5}));
            CountSpecificCommand command = new CountSpecificCommand(splaytree);

            int count = command.Execute(execute, 8);

            Assert.IsTrue(count == 0);
        }

        [TestMethod]
        public  void TestIfCountingIsCorrect()
        {
            ConsoleLogger logger = new ConsoleLogger();
            Executioner execute = new Executioner(logger);

            Splaytree splaytree = new Splaytree(execute.GenerateTree(new List<int> {7,9,3,6,5}));
            CountSpecificCommand command = new CountSpecificCommand(splaytree);

            int count = command.Execute(execute, 7);

            Assert.IsTrue(count == 1);
        }

         [TestMethod]
        public  void TestIfMultipleNumbersCountingIsCorrect()
        {
            ConsoleLogger logger = new ConsoleLogger();
            Executioner execute = new Executioner(logger);

            Splaytree splaytree = new Splaytree(execute.GenerateTree(new List<int> {7,9,3,6,5}));
            CountSpecificCommand command = new CountSpecificCommand(splaytree);

            int count = command.Execute(execute, 3);

            Assert.IsTrue(count == 4);
        }
    }
}