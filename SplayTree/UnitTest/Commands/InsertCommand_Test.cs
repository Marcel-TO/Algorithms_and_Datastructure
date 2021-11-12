namespace UnitTest.Commands
{
    using System;
    using System.Collections.Generic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using SplayTree.Commands;
    using SplayTree.Interfaces;
    using SplayTree.Logic;
    using SplayTree.Trees;

    [TestClass]
    public class InsertCommand_Test
    {
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

        [TestMethod]
         public void TestNegativeInput()
         {
             ConsoleLogger logger = new ConsoleLogger();
             Executioner execute = new Executioner(logger);

             SplayTree_int splaytree = new SplayTree_int(new List<Node>());
             InsertCommand command = new InsertCommand(splaytree);

             command.Execute(execute, -5);

             Assert.IsTrue(command.Nodes.Count == 0);
         }

         [TestMethod]
         public void TestNumberTooBig()
         {
             ConsoleLogger logger = new ConsoleLogger();
             Executioner execute = new Executioner(logger);

             SplayTree_int splaytree = new SplayTree_int(new List<Node>());
             InsertCommand command = new InsertCommand(splaytree);

             command.Execute(execute, 10000000);

             Assert.IsTrue(command.Nodes.Count == 0);
         }

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
