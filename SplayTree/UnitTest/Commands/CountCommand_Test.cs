namespace UnitTest.Commands
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using SplayTree.Commands;
    using SplayTree.Interfaces;
    using SplayTree.Trees;

    [TestClass]
    public class CountCommand_Test
    {
        [TestMethod]
        public  void TestIfTreeIsEmpty()
        {
            ILogger logger = new ILogger();
            Executioner execute = new Executioner(logger);

            Splaytree splaytree = new Splaytree(new List<Node>());
            CountCommand command = new CountCommand(splaytree);

            int count = command.Execute(execute);

            Assert.That(count == 0);
        }

        [TestMethod]
        public  void TestIfCountingIsCorrect()
        {
            ILogger logger = new ILogger();
            Executioner execute = new Executioner(logger);

            Splaytree splaytree = new Splaytree(new List<Node>() {7,9,3,6,5});
            CountCommand command = new CountCommand(splaytree);

            int count = command.Execute(execute);

            Assert.That(count == 5);
        }
    }
}