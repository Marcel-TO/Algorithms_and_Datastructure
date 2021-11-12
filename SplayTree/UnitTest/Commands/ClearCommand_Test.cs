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
    public class ClearCommand_Test
    {
        [TestMethod]
        public  void TestIfTreeIsEmpty()
        {
            ILogger logger = new ConsoleLogger();
            Executioner execute = new Executioner(logger);

            Splaytree splaytree = new Splaytree(new List<Node>());
            ClearCommand command = new ClearCommand(splaytree);

            bool isExecuted = command.Execute(execute);

            Assert.IsFalse(isExecuted);
        }

        [TestMethod]
        public  void TestIfTreeGetsCleared()
        {
            ConsoleLogger logger = new ConsoleLogger();
            Executioner execute = new Executioner(logger);

            Splaytree splaytree = new Splaytree(execute.GenerateTree(new List<int> {7,9,3,6,5}));
            ClearCommand command = new ClearCommand(splaytree);

            bool isExecuted = command.Execute(execute);

            Assert.IsTrue(isExecuted);
        }
    }
}