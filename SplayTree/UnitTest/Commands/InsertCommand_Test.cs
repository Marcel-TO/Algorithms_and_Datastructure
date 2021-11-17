//-----------------------------------------------------------------------
// <copyright file="InsertCommand_Test.cs" company="FHWN">
//     Copyright (c) Marcel Turobin-Ort. All rights reserved.
// </copyright>
// <author>Marcel Turobin-Ort</author>
// <summary>Defines the test class for the display command.</summary>
//-----------------------------------------------------------------------
namespace UnitTest.Commands
{
    using System;
    using System.Collections.Generic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using SplayTree.Commands;
    using SplayTree.Interfaces;
    using SplayTree.Logic;
    using SplayTree.Trees;

    /// <summary>
    /// Represents the unit tests for the insert command.
    /// </summary>
    [TestClass]
    public class InsertCommand_Test
    {
        /// <summary>
        /// Represents a method for testing if the number is correct.
        /// </summary>
         [TestMethod]
         public void TestNumberCorrect()
         {
             ILogger logger = new ConsoleLogger();
             Executioner execute = new Executioner(logger);

             SplayTree_int splaytree = new SplayTree_int(new List<Node>());
             InsertCommand command = new InsertCommand(splaytree);

             command.Execute(execute, 3);

             Assert.IsTrue(command.Nodes.Count != 0);
         }

        /// <summary>
        /// Represents a method for testing if the command reacts properly to negative input.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestNegativeInput()
        {
             ConsoleLogger logger = new ConsoleLogger();
             Executioner execute = new Executioner(logger);

             SplayTree_int splaytree = new SplayTree_int(new List<Node>());
             InsertCommand command = new InsertCommand(splaytree);

             command.Execute(execute, -5);
        }

        /// <summary>
        /// Represents a method for testing if the command sorts correctly.
        /// </summary>
         [TestMethod]
         public void TestCorrectSorting()
         {
             ConsoleLogger logger = new ConsoleLogger();
             Executioner execute = new Executioner(logger);

             SplayTree_int splaytree = new SplayTree_int(new List<Node>());
             InsertCommand command = new InsertCommand(splaytree);

             command.Execute(execute, 7);
             command.Execute(execute, 9);
             command.Execute(execute, 3);
             command.Execute(execute, 6);
             command.Execute(execute, 5);

            // Check if list of nodes got changed.
             Assert.IsTrue(command.Nodes.Count != 0);

             // Check if root node is last insert.
             Assert.IsTrue(command.Nodes[0].Value == 5);

             // Check other nodes of correct sorting.
             Assert.IsTrue(command.Nodes[1].Value == 3);
             Assert.IsTrue(command.Nodes[2].Value == 6);
             Assert.IsTrue(command.Nodes[3].Value == 7);
             Assert.IsTrue(command.Nodes[4].Value == 9);
         }

        /// <summary>
        /// Represents a method for testing if the position of nodes is correct.
        /// </summary>
         [TestMethod]
         public void TestCorrectPositionsOfNodes()
         {
             ConsoleLogger logger = new ConsoleLogger();
             Executioner execute = new Executioner(logger);

             SplayTree_int splaytree = new SplayTree_int(new List<Node>());
             InsertCommand command = new InsertCommand(splaytree);

             command.Execute(execute, 5);
             command.Execute(execute, 9);
             command.Execute(execute, 7);

             // Check if root node has correct position.
             Assert.IsTrue(command.Nodes[0].Position.X == 0);
             Assert.IsTrue(command.Nodes[0].Position.Y == 0);

             Assert.IsTrue(command.Nodes[1].Position.X == -1);
             Assert.IsTrue(command.Nodes[1].Position.Y == 1);

             Assert.IsTrue(command.Nodes[2].Position.X == 1);
             Assert.IsTrue(command.Nodes[2].Position.Y == 1);
         }

        /// <summary>
        /// Represents a method for testing if the child node is correct.
        /// </summary>
         [TestMethod]
         public void TestCorrectChildNodes()
         {
             ConsoleLogger logger = new ConsoleLogger();
             Executioner execute = new Executioner(logger);

             SplayTree_int splaytree = new SplayTree_int(new List<Node>());
             InsertCommand command = new InsertCommand(splaytree);

             command.Execute(execute, 5);
             command.Execute(execute, 9);
             command.Execute(execute, 7);

             // Check if root node contains correct child nodes.
             Assert.IsTrue(command.Nodes[0].LesserNode == command.Nodes[1]);
             Assert.IsTrue(command.Nodes[0].BiggerNode == command.Nodes[2]);
         }

         /// <summary>
         /// Represents a method for testing if the parent node is correct.
         /// </summary>
         [TestMethod]
         public void TestCorrectParentNode()
         {
             ConsoleLogger logger = new ConsoleLogger();
             Executioner execute = new Executioner(logger);

             SplayTree_int splaytree = new SplayTree_int(new List<Node>());
             InsertCommand command = new InsertCommand(splaytree);

             command.Execute(execute, 5);
             command.Execute(execute, 9);
             command.Execute(execute, 7);

             // Check if root node contains correct child nodes.
             Assert.IsTrue(command.Nodes[1].ParentNode == command.Nodes[0]);
             Assert.IsTrue(command.Nodes[2].ParentNode == command.Nodes[0]);
         }
    }
}
