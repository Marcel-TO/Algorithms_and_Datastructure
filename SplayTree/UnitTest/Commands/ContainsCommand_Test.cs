//-----------------------------------------------------------------------
// <copyright file="ContainsCommand_Test.cs" company="FHWN">
//     Copyright (c) Marcel Turobin-Ort. All rights reserved.
// </copyright>
// <author>Marcel Turobin-Ort</author>
// <summary>Defines the test class for the contians command.</summary>
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
    using UnitTest.Replacements;

    /// <summary>
    /// Represents the unit tests for the contains command.
    /// </summary>
    [TestClass]
    public class ContainsCommand_Test
    {
        /// <summary>
        /// Represents a method for testing if the tree is empty.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(TreeIsEmptyException))]
        public void TestIfTreeIsEmpty()
        {
            ILogger logger = new ConsoleLoggerTestInstance();

            SplayTree_int splaytree = new SplayTree_int(new List<Node>());
            ContainsCommand command = new ContainsCommand(splaytree);

            bool contains = command.Execute(3);
        }

        /// <summary>
        /// Represents a method for testing if the tree contains the number is correct.
        /// </summary>
        [TestMethod]
        public void TestIfTreeContainsNumber()
        {
            ILogger logger = new ConsoleLoggerTestInstance();
            Executioner execute = new Executioner(logger);

            SplayTree_int splaytree = new SplayTree_int(execute.GenerateTree(new List<int> { 7, 9, 3, 6, 5 }));
            ContainsCommand command = new ContainsCommand(splaytree);

            bool contains = command.Execute(3);

            Assert.IsTrue(contains);
        }

        /// <summary>
        /// Represents a method for testing if the command works correct when the number does not exist in the tree.
        /// </summary>
        [TestMethod]
        public void TestIfNumberDoesNotExist()
        {
            ILogger logger = new ConsoleLoggerTestInstance();
            Executioner execute = new Executioner(logger);

            SplayTree_int splaytree = new SplayTree_int(execute.GenerateTree(new List<int> { 7, 9, 3, 6, 5 }));
            ContainsCommand command = new ContainsCommand(splaytree);

            bool contains = command.Execute(8);

            Assert.IsFalse(contains);
        }
    }
}