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
    public class MinCommand_Test
    {
        [TestMethod]
        public  void TestIfTreeIsEmpty()
        {
            ILogger logger = new ConsoleLogger();
            Executioner execute = new Executioner(logger);

            Splaytree splaytree = new Splaytree(new List<Node>());
            MinCommand command = new MinCommand(splaytree);

            int min = command.Execute(execute);

            Assert.IsTrue(min == 0); // Vllt Exception abfangen?
        }

        [TestMethod]
        public  void TestIfMinCorrect()
        {
            ConsoleLogger logger = new ConsoleLogger();
            Executioner execute = new Executioner(logger);

            Splaytree splaytree = new Splaytree(execute.GenerateTree(new List<int> {7,9,3,6,5}));
            MinCommand command = new MinCommand(splaytree);

            int min = command.Execute(execute);

            for (int i = 0; i < command.Nodes.Count; i++)
            {
                Assert.IsTrue(min <= command.Nodes[i].Value);
            }
        }
    }
}