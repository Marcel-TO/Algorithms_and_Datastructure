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
    public class CountSpecificCommand_Test
    {
        [TestMethod]
        [ExpectedException(typeof(TreeIsEmptyException))]
        public  void TestIfTreeIsEmpty()
        {
            ILogger logger = new ConsoleLogger();

            SplayTree_int splaytree = new SplayTree_int(new List<Node>());
            CountSpecificCommand command = new CountSpecificCommand(splaytree);

            command.Execute(5);
        }

        [TestMethod]
        public  void TestIfNumberDoesNotExist()
        {
            ConsoleLogger logger = new ConsoleLogger();
            Executioner execute = new Executioner(logger);

            SplayTree_int splaytree = new SplayTree_int(execute.GenerateTree(new List<int> {7,9,3,6,5}));
            CountSpecificCommand command = new CountSpecificCommand(splaytree);

            int count = command.Execute(8);

            Assert.IsTrue(count == 0);
        }

        [TestMethod]
        public  void TestIfCountingIsCorrect()
        {
            ConsoleLogger logger = new ConsoleLogger();
            Executioner execute = new Executioner(logger);

            SplayTree_int splaytree = new SplayTree_int(execute.GenerateTree(new List<int> {7,9,3,6,5}));
            CountSpecificCommand command = new CountSpecificCommand(splaytree);

            int count = command.Execute(7);

            Assert.IsTrue(count == 1);
        }

         [TestMethod]
        public  void TestIfMultipleNumbersCountingIsCorrect()
        {
            ConsoleLogger logger = new ConsoleLogger();
            Executioner execute = new Executioner(logger);

            SplayTree_int splaytree = new SplayTree_int(execute.GenerateTree(new List<int> {7,3,3,3,3}));
            CountSpecificCommand command = new CountSpecificCommand(splaytree);

            int count = command.Execute(3);

            Assert.IsTrue(count == 4);
        }
    }
}