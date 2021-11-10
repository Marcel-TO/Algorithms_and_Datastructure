namespace UnitTest.Commands
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using SplayTree.Commands;
    using SplayTree.Interfaces;
    using SplayTree.Trees;

    [TestClass]
    public class MaxCommand_Test
    {
        [TestMethod]
        public  void TestIfTreeIsEmpty()
        {
            ILogger logger = new ILogger();
            Executioner execute = new Executioner(logger);

            Splaytree splaytree = new Splaytree(new List<Node>());
            MaxCommand command = new MaxCommand(splaytree);

            Node max = command.Execute(execute);

            Assert.That(max == null);
        }

        [TestMethod]
        public  void TestIfMaxCorrect()
        {
            ILogger logger = new ILogger();
            Executioner execute = new Executioner(logger);

            Splaytree splaytree = new Splaytree(new List<Node>() {7,9,3,6,5});
            MaxCommand command = new MaxCommand(splaytree);

            Node max = command.Execute(execute);

            for (int i = 0; i < command.Nodes.Count; i++)
            {
                Assert.That(max.Value >= command.Nodes[i].Value);
            }
        }
    }
}