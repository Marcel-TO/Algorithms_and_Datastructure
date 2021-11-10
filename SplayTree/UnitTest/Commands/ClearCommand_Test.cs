namespace UnitTest.Commands
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using SplayTree.Commands;
    using SplayTree.Interfaces;
    using SplayTree.Trees;

    [TestClass]
    public class ClearCommand_Test
    {
        [TestMethod]
        public  void TestIfTreeIsEmpty()
        {
            ILogger logger = new ILogger();
            Executioner execute = new Executioner(logger);

            Splaytree splaytree = new Splaytree(new List<Node>());
            ClearCommand command = new ClearCommand(splaytree);

            bool isExecuted = command.Execute(execute);

            Assert.IsFalse(isExecuted);
        }

        [TestMethod]
        public  void TestIfTreeGetsCleared()
        {
            ILogger logger = new ILogger();
            Executioner execute = new Executioner(logger);

            Splaytree splaytree = new Splaytree(new List<Node>() {7,9,3,6,5});
            ClearCommand command = new ClearCommand(splaytree);

            bool isExecuted = command.Execute(execute);

            Assert.IsTrue(isExecuted);
            Assert.That(count == 5);
        }
    }
}