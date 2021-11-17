//-----------------------------------------------------------------------
// <copyright file="CountSpecificCommand_Test.cs" company="FHWN">
//     Copyright (c) Marcel Turobin-Ort. All rights reserved.
// </copyright>
// <author>Marcel Turobin-Ort</author>
// <summary>Defines the test class for the count specific command.</summary>
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
    /// Represents the unit tests for the count specific command.
    /// </summary>
    [TestClass]
    public class CountSpecificCommand_Test
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
            CountSpecificCommand command = new CountSpecificCommand(splaytree);

            command.Execute(5);
        }

        /// <summary>
        /// Represents a method for testing if number does not exist.
        /// </summary>
        [TestMethod]
        public void TestIfNumberDoesNotExist()
        {
            ConsoleLogger logger = new ConsoleLogger();
            Executioner execute = new Executioner(logger);

            SplayTree_int splaytree = new SplayTree_int(execute.GenerateTree(new List<int> { 7, 9, 3, 6, 5 }));
            CountSpecificCommand command = new CountSpecificCommand(splaytree);

            int count = command.Execute(8);

            Assert.IsTrue(count == 0);
        }

        /// <summary>
        /// Represents a method for testing if count specific works correctly.
        /// </summary>
        [TestMethod]
        public void TestIfCountingIsCorrect()
        {
            ConsoleLogger logger = new ConsoleLogger();
            Executioner execute = new Executioner(logger);

            SplayTree_int splaytree = new SplayTree_int(execute.GenerateTree(new List<int> { 7, 9, 3, 6, 5 }));
            CountSpecificCommand command = new CountSpecificCommand(splaytree);

            int count = command.Execute(7);

            Assert.IsTrue(count == 1);
        }

        /// <summary>
        /// Represents a method for testing if multiple numbers get counted correctly.
        /// </summary>
         [TestMethod]
        public void TestIfMultipleNumbersCountingIsCorrect()
        {
            ConsoleLogger logger = new ConsoleLogger();
            Executioner execute = new Executioner(logger);

            SplayTree_int splaytree = new SplayTree_int(execute.GenerateTree(new List<int> { 7, 3, 3, 3, 3 }));
            CountSpecificCommand command = new CountSpecificCommand(splaytree);

            int count = command.Execute(3);

            Assert.IsTrue(count == 4);
        }
    }
}