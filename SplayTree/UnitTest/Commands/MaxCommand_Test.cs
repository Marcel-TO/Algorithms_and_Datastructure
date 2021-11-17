//-----------------------------------------------------------------------
// <copyright file="MaxCommand_Test.cs" company="FHWN">
//     Copyright (c) Marcel Turobin-Ort. All rights reserved.
// </copyright>
// <author>Marcel Turobin-Ort</author>
// <summary>Defines the test class for the maximum command.</summary>
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
    /// Represents the unit tests for the maximum command.
    /// </summary>
    [TestClass]
    public class MaxCommand_Test
    {
        /// <summary>
        /// Represents a method for testing if the tree is empty.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(TreeIsEmptyException))]
        public void TestIfTreeIsEmpty()
        {
            ILogger logger = new ConsoleLogger();

            SplayTree_int splaytree = new SplayTree_int(new List<Node>());
            MaxCommand command = new MaxCommand(splaytree);

            command.Execute();
        }

        /// <summary>
        /// Represents a method for testing if the maximum value is correct.
        /// </summary>
        [TestMethod]
        public void TestIfMaxCorrect()
        {
            ConsoleLogger logger = new ConsoleLogger();
            Executioner execute = new Executioner(logger);

            SplayTree_int splaytree = new SplayTree_int(execute.GenerateTree(new List<int> { 7, 9, 3, 6, 5 }));
            MaxCommand command = new MaxCommand(splaytree);

            int max = command.Execute();

            for (int i = 0; i < command.Nodes.Count; i++)
            {
                Assert.IsTrue(max >= command.Nodes[i].Value);
            }
        }
    }
}