namespace UnitTest.Commands
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using SplayTree.Commands;
    using SplayTree.Interfaces;
    using SplayTree.Trees;

    [TestClass]
    public class TraverseCommand_Test
    {
        /*
        *   Null input
        *   wrong input
        *   correct input
        *   pre-order
        *   in-order
        +   post-order
        */

        // Siehe -> https://www.geeksforgeeks.org/tree-traversals-inorder-preorder-and-postorder/


        [TestMethod]
        public void TestIfTreeIsEmpty()
        {
            ILogger logger = new ILogger();
            Executioner execute = new Executioner(logger);

            Splaytree splaytree = new Splaytree(new List<Node>());
            TraverseCommand command = new TraverseCommand(splaytree);

            List<Node> nodes = command.Execute(execute, "in-order");

            Assert.That(nodes.Count == 0);
        }

        [TestMethod]
        public void TestIfInputIsNull()
        {
            ILogger logger = new ILogger();
            Executioner execute = new Executioner(logger);

            Splaytree splaytree = new Splaytree(new List<Node>() {7,9,3,6,5});
            TraverseCommand command = new TraverseCommand(splaytree);

            List<Node> nodes = command.Execute(execute, null);

            Assert.That(nodes == null);
        }

        [TestMethod]
        public void TestIfWrongInput()
        {
            ILogger logger = new ILogger();
            Executioner execute = new Executioner(logger);

            Splaytree splaytree = new Splaytree(new List<Node>() {7,9,3,6,5});
            TraverseCommand command = new TraverseCommand(splaytree);

            List<Node> nodes = command.Execute(execute, "noclue-order");

            Assert.That(nodes.Count == null);
        }

        [TestMethod]
        public void TestIfCorrectInput()
        {
            ILogger logger = new ILogger();
            Executioner execute = new Executioner(logger);

            Splaytree splaytree = new Splaytree(new List<Node>() {7,9,3,6,5});
            TraverseCommand command = new TraverseCommand(splaytree);
            List<Node> testSample = command.Nodes;

            List<Node> nodes = command.Execute(execute, "in-order");

            Assert.That(nodes != testSample);
        }

        [TestMethod]
        public void TestIfPreOrderIsCorrect()
        {
            ILogger logger = new ILogger();
            Executioner execute = new Executioner(logger);

            Splaytree splaytree = new Splaytree(new List<Node>() {7,9,3,6,5});
            TraverseCommand command = new TraverseCommand(splaytree);

            List<Node> nodes = command.Execute(execute, "pre-order");

            Assert.That(nodes[0].Value == 5);
            Assert.That(nodes[1].Value == 3);
            Assert.That(nodes[2].Value == 6);
            Assert.That(nodes[3].Value == 7);
            Assert.That(nodes[4].Value == 9);
        }

        [TestMethod]
        public void TestIfInOrderIsCorrect()
        {
            ILogger logger = new ILogger();
            Executioner execute = new Executioner(logger);

            Splaytree splaytree = new Splaytree(new List<Node>() {7,9,3,6,5});
            TraverseCommand command = new TraverseCommand(splaytree);

            List<Node> nodes = command.Execute(execute, "in-order");

            Assert.That(nodes[0].Value == 3);
            Assert.That(nodes[1].Value == 5);
            Assert.That(nodes[2].Value == 6);
            Assert.That(nodes[3].Value == 7);
            Assert.That(nodes[4].Value == 9);
        }

        [TestMethod]
        public void TestIfPostOrderIsCorrect()
        {
            ILogger logger = new ILogger();
            Executioner execute = new Executioner(logger);

            Splaytree splaytree = new Splaytree(new List<Node>() {7,9,3,6,5});
            TraverseCommand command = new TraverseCommand(splaytree);

            List<Node> nodes = command.Execute(execute, "post-order");

            Assert.That(nodes[0].Value == 9);
            Assert.That(nodes[1].Value == 7);
            Assert.That(nodes[2].Value == 3);
            Assert.That(nodes[3].Value == 6);
            Assert.That(nodes[4].Value == 5);
        }
    }
}