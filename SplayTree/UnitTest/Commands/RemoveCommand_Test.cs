namespace UnitTest.Commands
{
    using System.Collections.Generic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using SplayTree.Commands;
    using SplayTree.Exceptions;
    using SplayTree.Interfaces;
    using SplayTree.Logic;
    using SplayTree.Trees;

    [TestClass]
    public class RemoveCommand_Test
    {
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

         [TestMethod]
         public void TestIfNumberExists()
         {
             ConsoleLogger logger = new ConsoleLogger();
             Executioner execute = new Executioner(logger);

             List<Node> nodes = execute.GenerateTree(new List<int> {7,9,3,6,5});
             var sample = execute.GenerateTree(new List<int> { 7, 9, 3, 6, 5 });

             SplayTree_int splaytree = new SplayTree_int(nodes);
             RemoveCommand command = new RemoveCommand(splaytree);

             int count = command.Execute(execute, 3);

             Assert.IsTrue(command.Nodes.Count < sample.Count);
             Assert.IsTrue(count == 1);
         }

         [TestMethod]
         public void TestIfNumberDoesNotExist()
         {
             ConsoleLogger logger = new ConsoleLogger();
             Executioner execute = new Executioner(logger);

             List<Node> nodes = execute.GenerateTree(new List<int> {7,9,3,6,5});

             SplayTree_int splaytree = new SplayTree_int(nodes);
             RemoveCommand command = new RemoveCommand(splaytree);

             int count = command.Execute(execute, 10);

             Assert.IsTrue(count == 0);
         }

         [TestMethod]
         public void TestIfSortingCorrect()
         {
             ConsoleLogger logger = new ConsoleLogger();
             Executioner execute = new Executioner(logger);

             List<Node> nodes = execute.GenerateTree(new List<int> {7,9,3,6,5});

             SplayTree_int splaytree = new SplayTree_int(nodes);
             RemoveCommand command = new RemoveCommand(splaytree);

             int count = command.Execute(execute, 3);

             Assert.IsTrue(count == 1);
             Assert.IsTrue(command.Nodes[0].Value == 7);
             Assert.IsTrue(command.Nodes[1].Value == 9);
             Assert.IsTrue(command.Nodes[2].Value == 6);
             Assert.IsTrue(command.Nodes[3].Value == 5);
         }

         [TestMethod]
         public void TestIfSameNumbers()
         {
             ConsoleLogger logger = new ConsoleLogger();
             Executioner execute = new Executioner(logger);

             List<Node> nodes = execute.GenerateTree(new List<int> {4,4,4,4});

             SplayTree_int splaytree = new SplayTree_int(nodes);
             RemoveCommand command = new RemoveCommand(splaytree);

             int count= command.Execute(execute, 4);

             Assert.IsTrue(count == 4);
             Assert.IsTrue(command.Nodes.Count == 0);
         }
    }
}
