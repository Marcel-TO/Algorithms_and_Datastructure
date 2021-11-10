namespace UnitTest.Commands
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using SplayTree.Commands;
    using SplayTree.Interfaces;
    using SplayTree.Trees;

    [TestClass]
    public class CountSpecificCommand_Test
    {
        [TestMethod]
        public  void TestIfTreeIsEmpty()
        {
            ILogger logger = new ILogger();
            Executioner execute = new Executioner(logger);

            Splaytree splaytree = new Splaytree(new List<Node>());
            CountSpecificCommand command = new CountSpecificCommand(splaytree);

            int count = command.Execute(execute, 5);

            Assert.That(count == 0);
        }

        [TestMethod]
        public  void TestIfNumberDoesNotExist()
        {
            ILogger logger = new ILogger();
            Executioner execute = new Executioner(logger);

            Splaytree splaytree = new Splaytree(new List<Node>() {7,9,3,6,5});
            CountSpecificCommand command = new CountSpecificCommand(splaytree);

            int count = command.Execute(execute, 8);

            Assert.That(count == 0);
        }

        [TestMethod]
        public  void TestIfCountingIsCorrect()
        {
            ILogger logger = new ILogger();
            Executioner execute = new Executioner(logger);

            Splaytree splaytree = new Splaytree(new List<Node>() {7,9,3,6,5});
            CountSpecificCommand command = new CountSpecificCommand(splaytree);

            int count = command.Execute(execute, 7);

            Assert.That(count == 1);
        }

         [TestMethod]
        public  void TestIfMultipleNumbersCountingIsCorrect()
        {
            ILogger logger = new ILogger();
            Executioner execute = new Executioner(logger);

            Splaytree splaytree = new Splaytree(new List<Node>() {7,3,3,3,3});
            CountSpecificCommand command = new CountSpecificCommand(splaytree);

            int count = command.Execute(execute, 3);

            Assert.That(count == 4);
        }
    }
}