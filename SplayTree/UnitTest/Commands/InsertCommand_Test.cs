namespace UnitTest.Commands
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using SplayTree.Commands;
    using SplayTree.Interfaces;
    using SplayTree.Trees;

    [TestClass]
    public class InsertCommand_Test
    {
         [TestMethod]
         public void TestNumberCorrect()
         {
             ILogger logger = new ILogger();
             Executioner execute = new Executioner(logger);

             Splaytree splaytree = new Splaytree(new List<Node>());
             InsertCommand command = new InsertCommand(splaytree);

             command.Execute(execute, 3);

             Assert.That(command.Nodes.Count != 0);
         }

        [TestMethod]
         public void TestNegativeInput()
         {
             ILogger logger = new ILogger();
             Executioner execute = new Executioner(logger);

             Splaytree splaytree = new Splaytree(new List<Node>());
             InsertCommand command = new InsertCommand(splaytree);

             command.Execute(execute, -5);

             Assert.That(command.Nodes.Count == 0);
         }

         [TestMethod]
         public void TestNumberTooBig()
         {
             ILogger logger = new ILogger();
             Executioner execute = new Executioner(logger);

             Splaytree splaytree = new Splaytree(new List<Node>());
             InsertCommand command = new InsertCommand(splaytree);

             command.Execute(execute, 10000000);

             Assert.That(command.Nodes.Count == 0);
         }

         [TestMethod]
         public void TestCorrectSorting()
         {
             ILogger logger = new ILogger();
             Executioner execute = new Executioner(logger);

             Splaytree splaytree = new Splaytree(new List<Node>());
             InsertCommand command = new InsertCommand(splaytree);

             command.Execute(execute, 7);
             command.Execute(execute, 9);
             command.Execute(execute, 3);
             command.Execute(execute, 6);
             command.Execute(execute, 5);

            // Check if list of nodes got changed.
             Assert.That(command.Nodes.Count != 0);

             // Check if root node is last insert.
             Assert.That(command.Nodes[0].Value == 5);
             // Check other nodes of correct sorting.
             Assert.That(command.Nodes[1].Value == 3);
             Assert.That(command.Nodes[2].Value == 6);
             Assert.That(command.Nodes[3].Value == 7);
             Assert.That(command.Nodes[4].Value == 9);
         }

         [TestMethod]
         public void TestCorrectPositionsOfNodes()
         {
             ILogger logger = new ILogger();
             Executioner execute = new Executioner(logger);

             Splaytree splaytree = new Splaytree(new List<Node>());
             InsertCommand command = new InsertCommand(splaytree);

             command.Execute(execute, 5);
             command.Execute(execute, 9);
             command.Execute(execute, 7);

             // Check if root node has correct position.
             Assert.That(command.Nodes[0].Positon.X == 0);
             Assert.That(command.Nodes[0].Positon.Y == 0);

             Assert.That(command.Nodes[1].Positon.X == -1);
             Assert.That(command.Nodes[1].Positon.Y == 1);

             Assert.That(command.Nodes[2].Positon.X == 1);
             Assert.That(command.Nodes[2].Positon.Y == 1);
         }

         [TestMethod]
         public void TestCorrectChildNodes()
         {
             ILogger logger = new ILogger();
             Executioner execute = new Executioner(logger);

             Splaytree splaytree = new Splaytree(new List<Node>());
             InsertCommand command = new InsertCommand(splaytree);

             command.Execute(execute, 5);
             command.Execute(execute, 9);
             command.Execute(execute, 7);

             // Check if root node contains correct child nodes.
             Assert.That(command.Nodes[0].LesserNode == command.Nodes[1]);
             Assert.That(command.Nodes[0].BiggerNode == command.Nodes[2]);
         }

         [TestMethod]
         public void TestCorrectParentNode()
         {
             ILogger logger = new ILogger();
             Executioner execute = new Executioner(logger);

             Splaytree splaytree = new Splaytree(new List<Node>());
             InsertCommand command = new InsertCommand(splaytree);

             command.Execute(execute, 5);
             command.Execute(execute, 9);
             command.Execute(execute, 7);

             // Check if root node contains correct child nodes.
             Assert.That(command.Nodes[1].ParentNode == command.Nodes[0]);
             Assert.That(command.Nodes[2].ParentNode == command.Nodes[0]);
         }
    }
}
