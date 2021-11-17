//-----------------------------------------------------------------------
// <copyright file="SplayTree_int_Test.cs" company="FHWN">
//     Copyright (c) Marcel Turobin-Ort. All rights reserved.
// </copyright>
// <author>Marcel Turobin-Ort</author>
// <summary>Defines the class for testing the integer splay tree.</summary>
//-----------------------------------------------------------------------
namespace UnitTest.Trees
{
    using System;
    using System.Collections.Generic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using SplayTree.Logic;
    using SplayTree.Trees;

    /// <summary>
    /// Represents the unit tests of the splay tree class.
    /// </summary>
    [TestClass]
    public class SplayTree_int_Test
    {
        /// <summary>
        /// Represents a method for testing if the constructor is null.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestIfConstructorIsNull()
        {
            SplayTree_int splaytree = new SplayTree_int(null);
        }

        /// <summary>
        /// Represents a method for testing if the constructor is not null.
        /// </summary>
        [TestMethod]
        public void TestConstructor()
        {
            SplayTree_int splaytree = new SplayTree_int(new List<Node>());

            Assert.IsNotNull(splaytree);
        }

        /// <summary>
        /// Represents a method for testing if the command list is not null.
        /// </summary>
        [TestMethod]
        public void TestGetCommands()
        {
            SplayTree_int splaytree = new SplayTree_int(new List<Node>());

            Assert.IsNotNull(splaytree.Commands);
        }

        /// <summary>
        /// Represents a method for testing if the node getter is correct.
        /// </summary>
        [TestMethod]
        public void TestNodesGet()
        {
            SplayTree_int splaytree = new SplayTree_int(new List<Node>());

            Assert.IsNotNull(splaytree.Nodes);
        }

        /// <summary>
        /// Represents a method for testing if the node setter is correct.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestNodesSet()
        {
            SplayTree_int splaytree = new SplayTree_int(new List<Node>());

            splaytree.Nodes = null;
        }
    }
}
