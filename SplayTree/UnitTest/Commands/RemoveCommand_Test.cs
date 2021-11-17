//-----------------------------------------------------------------------
// <copyright file="RemoveCommand_Test.cs" company="FHWN">
//     Copyright (c) Marcel Turobin-Ort. All rights reserved.
// </copyright>
// <author>Marcel Turobin-Ort</author>
// <summary>Defines the test class for the remove command.</summary>
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
    /// Represents the unit tests for the remove command.
    /// </summary>
    [TestClass]
    public class RemoveCommand_Test
    {
        /// <summary>
        /// Represents a method for testing if the tree is empty.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(TreeIsEmptyException))]
        public void TestIfListIsEmpty()
        {
            ILogger logger = new ConsoleLogger();
            Executioner execute = new Executioner(logger);

            SplayTree_int splaytree = new SplayTree_int(new List<Node>());
            RemoveCommand command = new RemoveCommand(splaytree);

            command.Execute(execute, 3);
        }

        /// <summary>
        /// Represents a method for testing if the value exists.
        /// </summary>
         [TestMethod]
        public void TestIfNumberExists()
        {
            ConsoleLogger logger = new ConsoleLogger();
            Executioner execute = new Executioner(logger);

            List<Node> nodes = execute.GenerateTree(new List<int> { 7, 9, 3, 6, 5 });
            var sample = execute.GenerateTree(new List<int> { 7, 9, 3, 6, 5 });

            SplayTree_int splaytree = new SplayTree_int(nodes);
            RemoveCommand command = new RemoveCommand(splaytree);

            int count = command.Execute(execute, 3);

            Assert.IsTrue(command.Nodes.Count < sample.Count);
            Assert.IsTrue(count == 1);
        }

        /// <summary>
        /// Represents a method for testing if the value does not exist.
        /// </summary>
         [TestMethod]
         public void TestIfNumberDoesNotExist()
         {
             ConsoleLogger logger = new ConsoleLogger();
             Executioner execute = new Executioner(logger);

            List<Node> nodes = execute.GenerateTree(new List<int> { 7, 9, 3, 6, 5 });

             SplayTree_int splaytree = new SplayTree_int(nodes);
             RemoveCommand command = new RemoveCommand(splaytree);

             int count = command.Execute(execute, 10);

             Assert.IsTrue(count == 0);
         }

        /// <summary>
        /// Represents a method for testing if the sorting algorithm is correct after removing a node.
        /// </summary>
         [TestMethod]
         public void TestIfSortingCorrect()
         {
             ConsoleLogger logger = new ConsoleLogger();
             Executioner execute = new Executioner(logger);

            List<Node> nodes = execute.GenerateTree(new List<int> { 7, 9, 3, 6, 5 });

             SplayTree_int splaytree = new SplayTree_int(nodes);
             RemoveCommand command = new RemoveCommand(splaytree);

             int count = command.Execute(execute, 3);

             Assert.IsTrue(count == 1);
             Assert.IsTrue(command.Nodes[0].Value == 7);
             Assert.IsTrue(command.Nodes[1].Value == 9);
             Assert.IsTrue(command.Nodes[2].Value == 6);
             Assert.IsTrue(command.Nodes[3].Value == 5);
         }

        /// <summary>
        /// Represents a method for testing if the removal of multiple nodes is correct.
        /// </summary>
         [TestMethod]
         public void TestIfSameNumbers()
         {
             ConsoleLogger logger = new ConsoleLogger();
             Executioner execute = new Executioner(logger);

            List<Node> nodes = execute.GenerateTree(new List<int> { 4, 4, 4, 4 });

             SplayTree_int splaytree = new SplayTree_int(nodes);
             RemoveCommand command = new RemoveCommand(splaytree);

             int count = command.Execute(execute, 4);

             Assert.IsTrue(count == 4);
             Assert.IsTrue(command.Nodes.Count == 0);
         }
    }
}
