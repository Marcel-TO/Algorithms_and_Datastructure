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
    public class CountCommand_Test
    {
        [TestMethod]
        public  void TestIfTreeIsEmpty()
        {
            ILogger logger = new ConsoleLogger();
            Executioner execute = new Executioner(logger);

            Splaytree splaytree = new Splaytree(new List<Node>());
            CountCommand command = new CountCommand(splaytree);

            int count = command.Execute(execute);

            Assert.IsTrue(count == 0);
        }

        [TestMethod]
        public  void TestIfCountingIsCorrect()
        {
            ILogger logger = new ConsoleLogger();
            Executioner execute = new Executioner(logger);

            Splaytree splaytree = new Splaytree(execute.GenerateTree(new List<int> {7,9,3,6,5}));
            CountCommand command = new CountCommand(splaytree);

            int count = command.Execute(execute);

            Assert.IsTrue(count == 5);
        }
    }
}