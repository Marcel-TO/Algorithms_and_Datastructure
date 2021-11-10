namespace UnitTest.Commands
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

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
             ILogger logger = new ILogger();
             Executioner execute = new Executioner(logger);

             Splaytree splaytree = new Splaytree(new List<Node>());
             InsertCommand command = new InsertCommand(splaytree);

             bool isExecuted = command.Execute(execute, 3);

             Assert.IsFalse(isExecuted);
         }

         [TestMethod]
         public void TestIfNumberExists()
         {
             ILogger logger = new ILogger();
             Executioner execute = new Executioner(logger);

             List<Node> nodes = new List<Node>() {7,9,3,6,5};
             var sample = nodes;

             Splaytree splaytree = new Splaytree(nodes);
             InsertCommand command = new InsertCommand(splaytree);

             bool isExecuted = command.Execute(execute, 3);

             Assert.That(command.Nodes.Count < sample.Count);
         }

         [TestMethod]
         public void TestIfNumberDoesNotExist()
         {
             ILogger logger = new ILogger();
             Executioner execute = new Executioner(logger);

             List<Node> nodes = new List<Node>() {7,9,3,6,5};
             var sample = nodes;

             Splaytree splaytree = new Splaytree(nodes);
             InsertCommand command = new InsertCommand(splaytree);

             bool isExecuted = command.Execute(execute, 10);

             Assert.IsFalse(isExecuted);
         }

         [TestMethod]
         public void TestIfSortingCorrect()
         {
             ILogger logger = new ILogger();
             Executioner execute = new Executioner(logger);

             List<Node> nodes = new List<Node>() {7,9,3,6,5};
             var sample = nodes;

             Splaytree splaytree = new Splaytree(nodes);
             InsertCommand command = new InsertCommand(splaytree);

             bool isExecuted = command.Execute(execute, 3);

             Assert.IsTrue(isExecuted);
             Assert.That(command.Nodes[0].Value == 5);
             Assert.That(command.Nodes[1].Value == 6);
             Assert.That(command.Nodes[2].Value == 7);
             Assert.That(command.Nodes[3].Value == 9);
         }

         [TestMethod]
         public void TestIfSameNumbers()
         {
             ILogger logger = new ILogger();
             Executioner execute = new Executioner(logger);

             List<Node> nodes = new List<Node>() {4,4,4,4};
             var sample = nodes;

             Splaytree splaytree = new Splaytree(nodes);
             InsertCommand command = new InsertCommand(splaytree);

             bool isExecuted = command.Execute(execute, 4);

             Assert.IsTrue(isExecuted);
             Assert.That(command.Nodes.Count == 3);
         }
    }
}
