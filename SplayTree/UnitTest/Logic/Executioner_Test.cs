//-----------------------------------------------------------------------
// <copyright file="Executioner_Test.cs" company="FHWN">
//     Copyright (c) Marcel Turobin-Ort. All rights reserved.
// </copyright>
// <author>Marcel Turobin-Ort</author>
// <summary>Defines the test class for the execution visitor pattern.</summary>
//-----------------------------------------------------------------------
namespace UnitTest.Logic
{
    using System;
    using System.Collections.Generic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using SplayTree.Commands;
    using SplayTree.Interfaces;
    using SplayTree.Logic;
    using SplayTree.Trees;
    using UnitTest.Replacements;

    /// <summary>
    /// Represents the unit tests for the executioner class.
    /// </summary>
    [TestClass]
    public class Executioner_Test
    {
        /// <summary>
        /// Represents a method for testing if the constructor is null.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestIfConstructorIsNull()
        {
            Executioner execute = new Executioner(null);
        }

        /// <summary>
        /// Represents a method for testing if the method <see cref="SplayTree.Logic.Executioner.CreateNode"/> property is null.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestFindAttachmentNode_Null()
        {
            ILogger logger = new ConsoleLoggerTestInstance();
            Executioner execute = new Executioner(logger);

            execute.FindAttachmentNode(null, 0);
        }

        /// <summary>
        /// Represents a method for testing if the method <see cref="SplayTree.Logic.Executioner.CreateNode"/> property is negative.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestFindAttachmentNode_NegativeValue()
        {
            ILogger logger = new ConsoleLoggerTestInstance();
            Executioner execute = new Executioner(logger);

            execute.FindAttachmentNode(new Node(3), -2);
        }

        /// <summary>
        /// Represents a method for testing if the method <see cref="SplayTree.Logic.Executioner.CreateNode"/> is correct.
        /// </summary>
        [TestMethod]
        public void TestFindAttachmentNode()
        {
            ILogger logger = new ConsoleLoggerTestInstance();
            Executioner execute = new Executioner(logger);

            Assert.IsNotNull(execute.FindAttachmentNode(new Node(4), 2));
        }

        /// <summary>
        /// Represents a method for testing if the method <see cref="SplayTree.Logic.Executioner.CreateNode"/> property is null.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestSortTree_Null()
        {
            ILogger logger = new ConsoleLoggerTestInstance();
            Executioner execute = new Executioner(logger);

            execute.SortTree(null, null, null, null);
        }

        /// <summary>
        /// Represents a method for testing if the sort tree is correct.
        /// </summary>
        [TestMethod]
        public void TestSortTree()
        {
            ILogger logger = new ConsoleLoggerTestInstance();
            Executioner execute = new Executioner(logger);

            Node root = new Node(5) { Position = new Position(0, 0) };
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

        /// <summary>
        /// Represents a method for testing if the method <see cref="SplayTree.Logic.Executioner.AddNode(Node, Node, List{Node})"/> properties are null.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestAddNode_Null()
        {
            ILogger logger = new ConsoleLoggerTestInstance();
            Executioner execute = new Executioner(logger);

            execute.AddNode(null, null, null);
        }

        /// <summary>
        /// Represents a method for testing if the method <see cref="SplayTree.Logic.Executioner.AddNode(Node, Node, List{Node})"/> is correct.
        /// </summary>
        [TestMethod]
        public void TestAddNode()
        {
            ILogger logger = new ConsoleLoggerTestInstance();
            Executioner execute = new Executioner(logger);

            Node root = new Node(3) { Position = new Position(0, 0) };
            Node newNode = new Node(4);
            List<Node> nodes = new List<Node>() { root };

            Assert.IsNotNull(execute.AddNode(newNode, root, nodes));
            Assert.IsTrue(nodes.Count == 2);
        }

        /// <summary>
        /// Represents a method for testing if the method <see cref="SplayTree.Logic.Executioner.CreateNode"/> property is null.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestCreateNode_Null()
        {
            ILogger logger = new ConsoleLoggerTestInstance();
            Executioner execute = new Executioner(logger);

            execute.CreateNode(0, null);
        }

        /// <summary>
        /// Represents a method for testing if the method <see cref="SplayTree.Logic.Executioner.CreateNode"/> property is negative.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestCreateNode_NegativeValue()
        {
            ILogger logger = new ConsoleLoggerTestInstance();
            Executioner execute = new Executioner(logger);

            execute.CreateNode(-3, new Node(4));
        }

        /// <summary>
        /// Represents a method for testing if the method <see cref="SplayTree.Logic.Executioner.CreateNode"/> is correct.
        /// </summary>
        [TestMethod]
        public void TestCreateNode()
        {
            ILogger logger = new ConsoleLoggerTestInstance();
            Executioner execute = new Executioner(logger);

            Node parent = new Node(4) { Position = new Position(0, 0) };

            var result = execute.CreateNode(3, parent);

            Assert.IsNotNull(result);
            Assert.IsTrue(result.Item2 == parent);
            Assert.IsTrue(result.Item1.Value == 3);
        }

        /// <summary>
        /// Represents a method for testing if the method <see cref="SplayTree.Logic.Executioner.RemoveNodes"/> property is null.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestRemoveNode_Null()
        {
            ILogger logger = new ConsoleLoggerTestInstance();
            Executioner execute = new Executioner(logger);

            execute.RemoveNodes(null, 0);
        }

        /// <summary>
        /// Represents a method for testing if the method <see cref="SplayTree.Logic.Executioner.CreateNode"/> property is negative.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestRemoveNodes_NegativeValue()
        {
            ILogger logger = new ConsoleLoggerTestInstance();
            Executioner execute = new Executioner(logger);

            List<Node> nodes = new List<Node>()
            {
                new Node(7),
                new Node(9)
            };

            execute.RemoveNodes(nodes, -3);
        }

        /// <summary>
        /// Represents a method for testing if the method <see cref="SplayTree.Logic.Executioner.RemoveNodes"/> reacts properly to wrong input.
        /// </summary>
        [TestMethod]
        public void TestRemoveNodes_Wrong()
        {
            ILogger logger = new ConsoleLoggerTestInstance();
            Executioner execute = new Executioner(logger);

            List<Node> nodes = new List<Node>()
            {
                new Node(7),
                new Node(9)
            };

            int count = execute.RemoveNodes(nodes, 10);

            Assert.IsTrue(count == 0);
        }

        /// <summary>
        /// Represents a method for testing if the method <see cref="SplayTree.Logic.Executioner.RemoveNodes"/> is correct.
        /// </summary>
        [TestMethod]
        public void TestRemoveNodes()
        {
            ILogger logger = new ConsoleLoggerTestInstance();
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

        /// <summary>
        /// Represents a method for testing if the method <see cref="SplayTree.Logic.Executioner.FindRemovedNode"/> property is null.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestFindRemovedNode_Null()
        {
            ILogger logger = new ConsoleLoggerTestInstance();
            Executioner execute = new Executioner(logger);

            execute.FindRemovedNode(null, 0);
        }

        /// <summary>
        /// Represents a method for testing if the method <see cref="SplayTree.Logic.Executioner.FindRemovedNode"/> property is negative.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestFindRemovedNode_NegativeValue()
        {
            ILogger logger = new ConsoleLoggerTestInstance();
            Executioner execute = new Executioner(logger);

            Node root = new Node(3) { Position = new Position(0, 0) };
            Node child = new Node(4, root);
            root.BiggerNode = child;

            List<Node> nodes = new List<Node>() { root, child };

            execute.FindRemovedNode(nodes, -3);
        }

        /// <summary>
        /// Represents a method for testing if the method <see cref="SplayTree.Logic.Executioner.FindRemovedNode"/> reacts properly to wrong input.
        /// </summary>
        [TestMethod]
        public void TestFindRemovedNode_Wrong()
        {
            ILogger logger = new ConsoleLoggerTestInstance();
            Executioner execute = new Executioner(logger);

            Node root = new Node(3) { Position = new Position(0, 0) };
            Node child = new Node(4, root);
            root.BiggerNode = child;

            List<Node> nodes = new List<Node>() { root, child };

            int count = execute.FindRemovedNode(nodes, 10);

            Assert.IsTrue(count == 0);
        }

        /// <summary>
        /// Represents a method for testing if the method <see cref="SplayTree.Logic.Executioner.FindRemovedNode"/> is correct.
        /// </summary>
        [TestMethod]
        public void TestFindRemovedNode()
        {
            ILogger logger = new ConsoleLoggerTestInstance();
            Executioner execute = new Executioner(logger);

            Node root = new Node(3) { Position = new Position(0, 0) };
            Node child = new Node(4, root);
            root.BiggerNode = child;

            List<Node> nodes = new List<Node>() { root, child };

            int count = execute.FindRemovedNode(nodes, 4);

            Assert.IsTrue(count == 1);
            Assert.IsTrue(nodes.Count == 1);
        }

        /// <summary>
        /// Represents a method for testing if the method <see cref="SplayTree.Logic.Executioner.GenerateTree"/> is null.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestGenerateTree_Null()
        {
            ILogger logger = new ConsoleLoggerTestInstance();
            Executioner execute = new Executioner(logger);

            execute.GenerateTree(null);
        }

        /// <summary>
        /// Represents a method for testing if the method <see cref="SplayTree.Logic.Executioner.GenerateTree"/> is correct.
        /// </summary>
        [TestMethod]
        public void TestGenerateTree()
        {
            ILogger logger = new ConsoleLoggerTestInstance();
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

        /// <summary>
        /// Represents a method for testing if the method <see cref="SplayTree.Logic.Executioner.ExtractValues"/> property is null.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestExtractValues_Null()
        {
            ILogger logger = new ConsoleLoggerTestInstance();
            Executioner execute = new Executioner(logger);

            execute.ExtractValues(null);
        }

        /// <summary>
        /// Represents a method for testing if the method <see cref="SplayTree.Logic.Executioner.ExtractValues"/> is correct.
        /// </summary>
        [TestMethod]
        public void TestExtractVaues()
        {
            ILogger logger = new ConsoleLoggerTestInstance();
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

        /// <summary>
        /// Represents a method for testing if the visitor pattern of the clear command is correct.
        /// </summary>
        [TestMethod]
        public void TestVisitClearCommand()
        {
            ILogger logger = new ConsoleLoggerTestInstance();
            Executioner execute = new Executioner(logger);

            List<int> values = new List<int>() { 5, 3, 6, 7, 9 };

            List<Node> nodes = execute.GenerateTree(values);
            SplayTree_int splaytree = new SplayTree_int(nodes);
            ClearCommand command = new ClearCommand(splaytree);

            execute.Visit(command);
        }

        /// <summary>
        /// Represents a method for testing if the visitor pattern of the contains command is correct.
        /// </summary>
        [TestMethod]
        public void TestVisitContainsCommand()
        {
            ILogger logger = new ConsoleLoggerTestInstance();
            Executioner execute = new Executioner(logger);

            List<int> values = new List<int>() { 5, 3, 6, 7, 9 };

            List<Node> nodes = execute.GenerateTree(values);
            SplayTree_int splaytree = new SplayTree_int(nodes);
            ContainsCommand command = new ContainsCommand(splaytree);

            execute.Visit(command);
        }

        /// <summary>
        /// Represents a method for testing if the visitor pattern of the count command is correct.
        /// </summary>
        [TestMethod]
        public void TestVisitCountCommand()
        {
            ILogger logger = new ConsoleLoggerTestInstance();
            Executioner execute = new Executioner(logger);

            List<int> values = new List<int>() { 5, 3, 6, 7, 9 };

            List<Node> nodes = execute.GenerateTree(values);
            SplayTree_int splaytree = new SplayTree_int(nodes);
            CountCommand command = new CountCommand(splaytree);

            execute.Visit(command);
        }

        /// <summary>
        /// Represents a method for testing if the visitor pattern of the count specific command is correct.
        /// </summary>
        [TestMethod]
        public void TestVisitCountSpecificCommand()
        {
            ILogger logger = new ConsoleLoggerTestInstance();
            Executioner execute = new Executioner(logger);

            List<int> values = new List<int>() { 5, 3, 6, 7, 9 };

            List<Node> nodes = execute.GenerateTree(values);
            SplayTree_int splaytree = new SplayTree_int(nodes);
            CountSpecificCommand command = new CountSpecificCommand(splaytree);

            execute.Visit(command);
        }

        /// <summary>
        /// Represents a method for testing if the visitor pattern of the display command is correct.
        /// </summary>
        [TestMethod]
        public void TestVisitDisplayCommand()
        {
            ILogger logger = new ConsoleLoggerTestInstance();
            Executioner execute = new Executioner(logger);

            List<int> values = new List<int>() { 5, 3, 6, 7, 9 };

            List<Node> nodes = execute.GenerateTree(values);
            SplayTree_int splaytree = new SplayTree_int(nodes);
            DisplayCommand command = new DisplayCommand(splaytree);

            execute.Visit(command);
        }

        /// <summary>
        /// Represents a method for testing if the visitor pattern of the insert command is correct.
        /// </summary>
        [TestMethod]
        public void TestVisitInsertCommand()
        {
            ILogger logger = new ConsoleLoggerTestInstance();
            Executioner execute = new Executioner(logger);

            List<int> values = new List<int>() { 5, 3, 6, 7, 9 };

            List<Node> nodes = execute.GenerateTree(values);
            SplayTree_int splaytree = new SplayTree_int(nodes);
            InsertCommand command = new InsertCommand(splaytree);

            execute.Visit(command);
        }

        /// <summary>
        /// Represents a method for testing if the visitor pattern of the maximum command is correct.
        /// </summary>
        [TestMethod]
        public void TestVisitMaxCommand()
        {
            ILogger logger = new ConsoleLoggerTestInstance();
            Executioner execute = new Executioner(logger);

            List<int> values = new List<int>() { 5, 3, 6, 7, 9 };

            List<Node> nodes = execute.GenerateTree(values);
            SplayTree_int splaytree = new SplayTree_int(nodes);
            MaxCommand command = new MaxCommand(splaytree);

            execute.Visit(command);
        }

        /// <summary>
        /// Represents a method for testing if the visitor pattern of the minimum command is correct.
        /// </summary>
        [TestMethod]
        public void TestVisitMinCommand()
        {
            ILogger logger = new ConsoleLoggerTestInstance();
            Executioner execute = new Executioner(logger);

            List<int> values = new List<int>() { 5, 3, 6, 7, 9 };

            List<Node> nodes = execute.GenerateTree(values);
            SplayTree_int splaytree = new SplayTree_int(nodes);
            MinCommand command = new MinCommand(splaytree);

            execute.Visit(command);
        }

        /// <summary>
        /// Represents a method for testing if the visitor pattern of the remove command is correct.
        /// </summary>
        [TestMethod]
        public void TestVisitRemoveCommand()
        {
            ILogger logger = new ConsoleLoggerTestInstance();
            Executioner execute = new Executioner(logger);

            List<int> values = new List<int>() { 5, 3, 6, 7, 9 };

            List<Node> nodes = execute.GenerateTree(values);
            SplayTree_int splaytree = new SplayTree_int(nodes);
            RemoveCommand command = new RemoveCommand(splaytree);

            execute.Visit(command);
        }

        /// <summary>
        /// Represents a method for testing if the visitor pattern of the traverse command is correct.
        /// </summary>
        [TestMethod]
        public void TestVisitTraverseCommand()
        {
            ILogger logger = new ConsoleLoggerTestInstance();
            Executioner execute = new Executioner(logger);

            List<int> values = new List<int>() { 5, 3, 6, 7, 9 };

            List<Node> nodes = execute.GenerateTree(values);
            SplayTree_int splaytree = new SplayTree_int(nodes);
            TraverseCommand command = new TraverseCommand(splaytree);

            execute.Visit(command);
        }
    }
}
