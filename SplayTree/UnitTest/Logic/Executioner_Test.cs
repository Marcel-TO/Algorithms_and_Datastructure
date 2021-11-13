namespace UnitTest.Logic
{
    using System;
    using System.Collections.Generic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using SplayTree.Commands;
    using SplayTree.Interfaces;
    using SplayTree.Logic;

    [TestClass]
    public class Executioner_Test
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestIfConstructorIsNull()
        {
            Executioner execute = new Executioner(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestFindAttachmentNode_Null()
        {
            ILogger logger = new ConsoleLogger();
            Executioner execute = new Executioner(logger);

            execute.FindAttachmentNode(null, 0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestFindAttachmentNode_NegativeValue()
        {
            ILogger logger = new ConsoleLogger();
            Executioner execute = new Executioner(logger);

            execute.FindAttachmentNode(new Node(3), -2);
        }

        [TestMethod]
        public void TestFindAttachmentNode()
        {
            ILogger logger = new ConsoleLogger();
            Executioner execute = new Executioner(logger);

            Assert.IsNotNull(execute.FindAttachmentNode(new Node(4), 2));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestSortTree_Null()
        {
            ILogger logger = new ConsoleLogger();
            Executioner execute = new Executioner(logger);

            execute.SortTree(null, null, null, null);
        }

        [TestMethod]
        public void TestSortTree()
        {
            ILogger logger = new ConsoleLogger();
            Executioner execute = new Executioner(logger);

            Node root = new Node(5) { Position = new Position(0,0)};
            Node attachment = new Node(6);

            List<Node> sortedL = new List<Node>()
            {
                new Node(3)
            };

            List<Node> sortedR = new List<Node>()
            {
                new Node(7),
                new Node(9)
            };

            Assert.IsNotNull(execute.SortTree(root, attachment, sortedL, sortedR));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestAddNode_Null()
        {
            ILogger logger = new ConsoleLogger();
            Executioner execute = new Executioner(logger);

            execute.AddNode(null, null, null);
        }

        [TestMethod]
        public void TestAddNode()
        {
            ILogger logger = new ConsoleLogger();
            Executioner execute = new Executioner(logger);

            Node root = new Node(3) { Position = new Position(0, 0) };
            Node newNode = new Node(4);
            List<Node> nodes = new List<Node>() { root };

            Assert.IsNotNull(execute.AddNode(newNode, root, nodes));
            Assert.IsTrue(nodes.Count == 2);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestCreateNode_Null()
        {
            ILogger logger = new ConsoleLogger();
            Executioner execute = new Executioner(logger);

            execute.CreateNode(0, null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestCreateNode_NegativeValue()
        {
            ILogger logger = new ConsoleLogger();
            Executioner execute = new Executioner(logger);

            execute.CreateNode(-3, new Node(4));
        }

        [TestMethod]
        public void TestCreateNode()
        {
            ILogger logger = new ConsoleLogger();
            Executioner execute = new Executioner(logger);

            Node parent = new Node(4) { Position = new Position(0, 0) };

            var result = execute.CreateNode(3, parent);

            Assert.IsNotNull(result);
            Assert.IsTrue(result.Item2 == parent);
            Assert.IsTrue(result.Item1.Value == 3);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestRemoveNode_Null()
        {
            ILogger logger = new ConsoleLogger();
            Executioner execute = new Executioner(logger);

            execute.RemoveNodes(null, 0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestRemoveNodes_NegativeValue()
        {
            ILogger logger = new ConsoleLogger();
            Executioner execute = new Executioner(logger);

            List<Node> nodes = new List<Node>()
            {
                new Node(7),
                new Node(9)
            };

            execute.RemoveNodes(nodes, -3);
        }

        [TestMethod]
        public void TestRemoveNodes_Wrong()
        {
            ILogger logger = new ConsoleLogger();
            Executioner execute = new Executioner(logger);

            List<Node> nodes = new List<Node>()
            {
                new Node(7),
                new Node(9)
            };

            int count = execute.RemoveNodes(nodes, 10);

            Assert.IsTrue(count == 0);
        }

        [TestMethod]
        public void TestRemoveNodes()
        {
            ILogger logger = new ConsoleLogger();
            Executioner execute = new Executioner(logger);

            List<Node> nodes = new List<Node>()
            {
                new Node(7),
                new Node(9)
            };

            int count = execute.RemoveNodes(nodes, 9);

            Assert.IsTrue(count == 1);
            Assert.IsTrue(nodes.Count == 1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestFindRemovedNode_Null()
        {
            ILogger logger = new ConsoleLogger();
            Executioner execute = new Executioner(logger);

            execute.FindRemovedNode(null, 0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestFindRemovedNode_NegativeValue()
        {
            ILogger logger = new ConsoleLogger();
            Executioner execute = new Executioner(logger);

            Node root = new Node(3) { Position = new Position(0, 0) };
            Node child = new Node(4, root);
            root.BiggerNode = child;

            List<Node> nodes = new List<Node>() { root, child };

            execute.FindRemovedNode(nodes, -3);
        }

        [TestMethod]
        public void TestFindRemovedNode_Wrong()
        {
            ILogger logger = new ConsoleLogger();
            Executioner execute = new Executioner(logger);

            Node root = new Node(3) { Position = new Position(0, 0) };
            Node child = new Node(4, root);
            root.BiggerNode = child;

            List<Node> nodes = new List<Node>() { root, child };

            int count = execute.FindRemovedNode(nodes, 10);

            Assert.IsTrue(count == 0);
        }

        [TestMethod]
        public void TestFindRemovedNode()
        {
            ILogger logger = new ConsoleLogger();
            Executioner execute = new Executioner(logger);

            Node root = new Node(3) { Position = new Position(0, 0) };
            Node child = new Node(4, root);
            root.BiggerNode = child;

            List<Node> nodes = new List<Node>() { root, child };

            int count = execute.FindRemovedNode(nodes, 4);

            Assert.IsTrue(count == 1);
            Assert.IsTrue(nodes.Count == 1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestGenerateTree_Null()
        {
            ILogger logger = new ConsoleLogger();
            Executioner execute = new Executioner(logger);

            execute.GenerateTree(null);
        }

        [TestMethod]
        public void TestGenerateTree()
        {
            ILogger logger = new ConsoleLogger();
            Executioner execute = new Executioner(logger);

            List<int> values = new List<int>() { 5, 3, 6, 7, 9 };

            List<Node> nodes = execute.GenerateTree(values);
            Assert.IsNotNull(nodes);
            Assert.IsTrue(nodes[0].Value == 5);
            Assert.IsTrue(nodes[1].Value == 3);
            Assert.IsTrue(nodes[2].Value == 6);
            Assert.IsTrue(nodes[3].Value == 7);
            Assert.IsTrue(nodes[4].Value == 9);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestExtractValues_Null()
        {
            ILogger logger = new ConsoleLogger();
            Executioner execute = new Executioner(logger);

            execute.ExtractValues(null);
        }

        [TestMethod]
        public void TestExtractVaues()
        {
            ILogger logger = new ConsoleLogger();
            Executioner execute = new Executioner(logger);

            List<Node> nodes = new List<Node>()
            {
                new Node(5),
                new Node(3),
                new Node(9)
            };

            List<int> values = execute.ExtractValues(nodes);

            Assert.IsNotNull(values);
            Assert.IsTrue(values[0] == 5);
            Assert.IsTrue(values[1] == 3);
            Assert.IsTrue(values[2] == 9);
        }
    }
}
