namespace UnitTest.Commands
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using SplayTree.Commands;
    using SplayTree.Interfaces;
    using SplayTree.Trees;

    [TestClass]
    public class MinCommand_Test
    {
        [TestMethod]
        public  void TestIfTreeIsEmpty()
        {
            ILogger logger = new ILogger();
            Executioner execute = new Executioner(logger);

            Splaytree splaytree = new Splaytree(new List<Node>());
            MinCommand command = new MinCommand(splaytree);

            Node min = command.Execute(execute);

            Assert.That(min == null);
        }

        [TestMethod]
        public  void TestIfMinCorrect()
        {
            ILogger logger = new ILogger();
            Executioner execute = new Executioner(logger);

            Splaytree splaytree = new Splaytree(new List<Node>() {7,9,3,6,5});
            MinCommand command = new MinCommand(splaytree);

            Node min = command.Execute(execute);

            for (int i = 0; i < command.Nodes.Count; i++)
            {
                Assert.That(min.Value <= command.Nodes[i].Value);
            }
        }
    }
}