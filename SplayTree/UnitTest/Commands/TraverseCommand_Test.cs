//-----------------------------------------------------------------------
// <copyright file="TraverseCommand_Test.cs" company="FHWN">
//     Copyright (c) Marcel Turobin-Ort. All rights reserved.
// </copyright>
// <author>Marcel Turobin-Ort</author>
// <summary>Defines the test class for the traverse command.</summary>
//-----------------------------------------------------------------------
namespace UnitTest.Commands
{
    using System.Collections.Generic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using SplayTree.Commands;
    using SplayTree.Exceptions;
    using SplayTree.Interfaces;
    using SplayTree.Logic;
    using SplayTree.Trees;

    /// <summary>
    /// Represents the unit tests for the traverse command.
    /// </summary>
    [TestClass]
    public class TraverseCommand_Test
    {
        /// <summary>
        /// Represents a method for testing if the tree is empty.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(TreeIsEmptyException))]
        public void TestIfTreeIsEmpty()
        {
            ILogger logger = new ConsoleLogger();
            Executioner execute = new Executioner(logger);

            SplayTree_int splaytree = new SplayTree_int(new List<Node>());
            TraverseCommand command = new TraverseCommand(splaytree);

            command.Execute(execute, TraverseOrder.inOrder);
        }

        /// <summary>
        /// Represents a method for testing if the traversal of nodes is correct.
        /// </summary>
        [TestMethod]
        public void TestIfCorrectInput()
        {
            ConsoleLogger logger = new ConsoleLogger();
            Executioner execute = new Executioner(logger);

            SplayTree_int splaytree = new SplayTree_int(execute.GenerateTree(new List<int> { 7, 9, 3, 6, 5 }));
            TraverseCommand command = new TraverseCommand(splaytree);
            List<Node> testSample = command.Nodes;

            List<Node> nodes = command.Execute(execute, TraverseOrder.inOrder);

            Assert.IsTrue(nodes != testSample);
        }

        /// <summary>
        /// Represents a method for testing if the pre-order traversal is correct.
        /// </summary>
        [TestMethod]
        public void TestIfPreOrderIsCorrect()
        {
            ConsoleLogger logger = new ConsoleLogger();
            Executioner execute = new Executioner(logger);

            SplayTree_int splaytree = new SplayTree_int(execute.GenerateTree(new List<int> { 7, 9, 3, 6, 5 }));
            TraverseCommand command = new TraverseCommand(splaytree);

            List<Node> nodes = command.Execute(execute, TraverseOrder.preOrder);

            Assert.IsTrue(nodes[0].Value == 7);
            Assert.IsTrue(nodes[1].Value == 3);
            Assert.IsTrue(nodes[2].Value == 6);
            Assert.IsTrue(nodes[3].Value == 5);
            Assert.IsTrue(nodes[4].Value == 9);
        }

        /// <summary>
        /// Represents a method for testing if the in-order traversal is correct.
        /// </summary>
        [TestMethod]
        public void TestIfInOrderIsCorrect()
        {
            ConsoleLogger logger = new ConsoleLogger();
            Executioner execute = new Executioner(logger);

            SplayTree_int splaytree = new SplayTree_int(execute.GenerateTree(new List<int> { 7, 9, 3, 6, 5 }));
            TraverseCommand command = new TraverseCommand(splaytree);

            List<Node> nodes = command.Execute(execute, TraverseOrder.inOrder);

            Assert.IsTrue(nodes[0].Value == 3);
            Assert.IsTrue(nodes[1].Value == 5);
            Assert.IsTrue(nodes[2].Value == 6);
            Assert.IsTrue(nodes[3].Value == 7);
            Assert.IsTrue(nodes[4].Value == 9);
        }

        /// <summary>
        /// Represents a method for testing if the post-order traversal is correct.
        /// </summary>
        [TestMethod]
        public void TestIfPostOrderIsCorrect()
        {
            ConsoleLogger logger = new ConsoleLogger();
            Executioner execute = new Executioner(logger);

            SplayTree_int splaytree = new SplayTree_int(execute.GenerateTree(new List<int> { 5, 3, 6, 7, 9 }));
            TraverseCommand command = new TraverseCommand(splaytree);

            List<Node> nodes = command.Execute(execute, TraverseOrder.postOrder);

            Assert.IsTrue(nodes[0].Value == 3);
            Assert.IsTrue(nodes[1].Value == 9);
            Assert.IsTrue(nodes[2].Value == 7);
            Assert.IsTrue(nodes[3].Value == 6);
            Assert.IsTrue(nodes[4].Value == 5);
        }
    }
}