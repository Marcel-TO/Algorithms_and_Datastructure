//-----------------------------------------------------------------------
// <copyright file="DisplayCommand_Test.cs" company="FHWN">
//     Copyright (c) Marcel Turobin-Ort. All rights reserved.
// </copyright>
// <author>Marcel Turobin-Ort</author>
// <summary>Defines the test class for the display command.</summary>
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
    /// Represents the unit tests for the display command class.
    /// </summary>
    [TestClass]
    public class DisplayCommand_Test
    {
        /// <summary>
        /// Represents a method for testing if the tree is empty.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(TreeIsEmptyException))]
        public void TestIfTreeIsEmpty()
        {
            SplayTree_int splaytree = new SplayTree_int(new List<Node>());
            DisplayCommand command = new DisplayCommand(splaytree);

            command.Execute();
        }

        /// <summary>
        /// Represents a method for testing if command gets executed.
        /// </summary>
        [TestMethod]
        public void TestIfCommandGetsExecuted()
        {
            ILogger logger = new ConsoleLoggerTestInstance();
            Executioner execute = new Executioner(logger);

            SplayTree_int splaytree = new SplayTree_int(execute.GenerateTree(new List<int> { 7, 9, 3, 6, 5 }));
            DisplayCommand command = new DisplayCommand(splaytree);

            command.Execute();
        }
    }
}