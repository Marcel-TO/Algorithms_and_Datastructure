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
    public class RemoveCommand_Test
    {
        /*
         * remove if list is 0
         * remove wrong  number
         * remove correct
         */

         [TestMethod]
         public void TestIfListIsEmpty()
         {
            ILogger logger = new ConsoleLogger();
             Executioner execute = new Executioner(logger);

             Splaytree splaytree = new Splaytree(new List<Node>());
             RemoveCommand command = new RemoveCommand(splaytree);

             bool isExecuted = command.Execute(execute, 3);

             Assert.IsFalse(isExecuted);
         }

         [TestMethod]
         public void TestIfNumberExists()
         {
             ConsoleLogger logger = new ConsoleLogger();
             Executioner execute = new Executioner(logger);

             List<Node> nodes = execute.GenerateTree(new List<int> {7,9,3,6,5});
             var sample = nodes;

             Splaytree splaytree = new Splaytree(nodes);
            RemoveCommand command = new RemoveCommand(splaytree);

             bool isExecuted = command.Execute(execute, 3);

             Assert.IsTrue(command.Nodes.Count < sample.Count);
         }

         [TestMethod]
         public void TestIfNumberDoesNotExist()
         {
             ConsoleLogger logger = new ConsoleLogger();
             Executioner execute = new Executioner(logger);

             List<Node> nodes = execute.GenerateTree(new List<int> {7,9,3,6,5});
             var sample = nodes;

             Splaytree splaytree = new Splaytree(nodes);
            RemoveCommand command = new RemoveCommand(splaytree);

             bool isExecuted = command.Execute(execute, 10);

             Assert.IsFalse(isExecuted);
         }

         [TestMethod]
         public void TestIfSortingCorrect()
         {
             ConsoleLogger logger = new ConsoleLogger();
             Executioner execute = new Executioner(logger);

             List<Node> nodes = execute.GenerateTree(new List<int> {7,9,3,6,5});
             var sample = nodes;

             Splaytree splaytree = new Splaytree(nodes);
            RemoveCommand command = new RemoveCommand(splaytree);

             bool isExecuted = command.Execute(execute, 3);

             Assert.IsTrue(isExecuted);
             Assert.IsTrue(command.Nodes[0].Value == 5);
             Assert.IsTrue(command.Nodes[1].Value == 6);
             Assert.IsTrue(command.Nodes[2].Value == 7);
             Assert.IsTrue(command.Nodes[3].Value == 9);
         }

         [TestMethod]
         public void TestIfSameNumbers()
         {
             ConsoleLogger logger = new ConsoleLogger();
             Executioner execute = new Executioner(logger);

             List<Node> nodes = execute.GenerateTree(new List<int> {4,4,4,4});
             var sample = nodes;

             Splaytree splaytree = new Splaytree(nodes);
             RemoveCommand command = new RemoveCommand(splaytree);

             bool isExecuted = command.Execute(execute, 4);

             Assert.IsTrue(isExecuted);
             Assert.IsTrue(command.Nodes.Count == 3);
         }
    }
}
