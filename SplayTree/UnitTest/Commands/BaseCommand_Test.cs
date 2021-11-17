//-----------------------------------------------------------------------
// <copyright file="BaseCommand_Test.cs" company="FHWN">
//     Copyright (c) Marcel Turobin-Ort. All rights reserved.
// </copyright>
// <author>Marcel Turobin-Ort</author>
// <summary>Defines the test class for the abstract base command class.</summary>
//-----------------------------------------------------------------------
namespace UnitTest.Commands
{
    using System;
    using System.Collections.Generic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using SplayTree.Commands;
    using SplayTree.Logic;
    using SplayTree.Trees;

    /// <summary>
    /// Represents the unit tests for the abstract base command class.
    /// </summary>
    [TestClass]
    public class BaseCommand_Test
    {
        /// <summary>
        /// Represents a method for testing if splay tree is null.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestIfSplayTreeIsNull()
        {
            ClearCommand command = new ClearCommand(null);
        }

        /// <summary>
        /// Represents a method for testing if the command initializer is correct.
        /// </summary>
        [TestMethod]
        public void TestIfInitializerIsCorrect()
        {
            ClearCommand command = new ClearCommand(new SplayTree_int(new List<Node>()));

            Assert.IsNotNull(command.Initializer);
            Assert.IsTrue(command.Initializer == "fn");
        }

        /// <summary>
        /// Represents a method for testing if get name is correct.
        /// </summary>
        [TestMethod]
        public void TestIfGetNameIsCorrect()
        {
            ClearCommand command = new ClearCommand(new SplayTree_int(new List<Node>()));

            Assert.IsNotNull(command.Name);
            Assert.IsTrue(command.Name == "clear");
        }

        /// <summary>
        /// Represents a method for testing if nodes are null.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestIfNodesNull()
        {
            ClearCommand command = new ClearCommand(new SplayTree_int(null));
        }

        /// <summary>
        /// Represents a method for testing if set nodes is correct.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestIfSetNodesIsCorrect()
        {
            ClearCommand command = new ClearCommand(new SplayTree_int(new List<Node>()));

            command.Nodes = null;
        }
    }
}
