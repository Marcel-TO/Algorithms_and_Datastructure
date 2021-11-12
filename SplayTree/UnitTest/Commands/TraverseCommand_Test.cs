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

        // Siehe ->https://www.geeksforgeeks.org/tree-traversals-inorder-preorder-and-postorder/


        [TestMethod]
        [ExpectedException(typeof(TreeIsEmptyException))]
        public void TestIfTreeIsEmpty()
        {
            ILogger logger = new ConsoleLogger();
            Executioner execute = new Executioner(logger);

            SplayTree_int splaytree = new SplayTree_int(new List<Node>());
            TraverseCommand command = new TraverseCommand(splaytree);

            List<Node> nodes = command.Execute(execute, TraverseOrder.inOrder);
        }

        //[TestMethod]
        //public void TestIfInputIsNull()
        //{
        //    ConsoleLogger logger = new ConsoleLogger();
        //    Executioner execute = new Executioner(logger);

        //    Splaytree splaytree = new Splaytree(execute.GenerateTree(new List<int> {7,9,3,6,5}));
        //    TraverseCommand command = new TraverseCommand(splaytree);

        //    List<Node> nodes = command.Execute(execute, null);

        //    Assert.IsTrue(nodes == null);
        //}

        //[TestMethod]
        //public void TestIfWrongInput()
        //{
        //    ConsoleLogger logger = new ConsoleLogger();
        //    Executioner execute = new Executioner(logger);

        //    Splaytree splaytree = new Splaytree(execute.GenerateTree(new List<int> {7,9,3,6,5}));
        //    TraverseCommand command = new TraverseCommand(splaytree);

        //    List<Node> nodes = command.Execute(execute, "noclue-order");

        //    Assert.IsTrue(nodes.Count == 0);
        //}

        [TestMethod]
        public void TestIfCorrectInput()
        {
            ConsoleLogger logger = new ConsoleLogger();
            Executioner execute = new Executioner(logger);

            SplayTree_int splaytree = new SplayTree_int(execute.GenerateTree(new List<int> {7,9,3,6,5}));
            TraverseCommand command = new TraverseCommand(splaytree);
            List<Node> testSample = command.Nodes;

            List<Node> nodes = command.Execute(execute, TraverseOrder.inOrder);

            Assert.IsTrue(nodes != testSample);
        }

        [TestMethod]
        public void TestIfPreOrderIsCorrect()
        {
            ConsoleLogger logger = new ConsoleLogger();
            Executioner execute = new Executioner(logger);

            SplayTree_int splaytree = new SplayTree_int(execute.GenerateTree(new List<int> {7,9,3,6,5}));
            TraverseCommand command = new TraverseCommand(splaytree);

            List<Node> nodes = command.Execute(execute, TraverseOrder.preOrder);

            Assert.IsTrue(nodes[0].Value == 5);
            Assert.IsTrue(nodes[1].Value == 3);
            Assert.IsTrue(nodes[2].Value == 6);
            Assert.IsTrue(nodes[3].Value == 7);
            Assert.IsTrue(nodes[4].Value == 9);
        }

        [TestMethod]
        public void TestIfInOrderIsCorrect()
        {
            ConsoleLogger logger = new ConsoleLogger();
            Executioner execute = new Executioner(logger);

            SplayTree_int splaytree = new SplayTree_int(execute.GenerateTree(new List<int> {7,9,3,6,5}));
            TraverseCommand command = new TraverseCommand(splaytree);

            List<Node> nodes = command.Execute(execute, TraverseOrder.inOrder);

            Assert.IsTrue(nodes[0].Value == 3);
            Assert.IsTrue(nodes[1].Value == 5);
            Assert.IsTrue(nodes[2].Value == 6);
            Assert.IsTrue(nodes[3].Value == 7);
            Assert.IsTrue(nodes[4].Value == 9);
        }

        [TestMethod]
        public void TestIfPostOrderIsCorrect()
        {
            ConsoleLogger logger = new ConsoleLogger();
            Executioner execute = new Executioner(logger);

            SplayTree_int splaytree = new SplayTree_int(execute.GenerateTree(new List<int> {7,9,3,6,5}));
            TraverseCommand command = new TraverseCommand(splaytree);

            List<Node> nodes = command.Execute(execute, TraverseOrder.postOrder);

            Assert.IsTrue(nodes[0].Value == 9);
            Assert.IsTrue(nodes[1].Value == 7);
            Assert.IsTrue(nodes[2].Value == 3);
            Assert.IsTrue(nodes[3].Value == 6);
            Assert.IsTrue(nodes[4].Value == 5);
        }
    }
}