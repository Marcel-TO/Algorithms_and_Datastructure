//-----------------------------------------------------------------------
// <copyright file="CountCommand_Test.cs" company="FHWN">
//     Copyright (c) Marcel Turobin-Ort. All rights reserved.
// </copyright>
// <author>Marcel Turobin-Ort</author>
// <summary>Defines the test class for the count command.</summary>
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
    /// Represents the unit tests for the count command.
    /// </summary>
    [TestClass]
    public class CountCommand_Test
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
            CountCommand command = new CountCommand(splaytree);

            int count = command.Execute();
        }

        /// <summary>
        /// Represents a method for testing if count is correct.
        /// </summary>
        [TestMethod]
        public void TestIfCountingIsCorrect()
        {
            ILogger logger = new ConsoleLoggerTestInstance();
            Executioner execute = new Executioner(logger);

            SplayTree_int splaytree = new SplayTree_int(execute.GenerateTree(new List<int> { 7, 9, 3, 6, 5 }));
            CountCommand command = new CountCommand(splaytree);

            int count = command.Execute();

            Assert.IsTrue(count == 5);
        }
    }
}