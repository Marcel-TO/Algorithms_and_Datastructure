namespace UnitTest.Trees
{
    using System;
    using System.Collections.Generic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using SplayTree.Logic;
    using SplayTree.Trees;

    [TestClass]
    public class SplayTree_int_Test
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestIfConstructorIsNull()
        {
            SplayTree_int splaytree = new SplayTree_int(null);
        }

        [TestMethod]
        public void TestConstructor()
        {
            SplayTree_int splaytree = new SplayTree_int(new List<Node>());

            Assert.IsNotNull(splaytree);
        }

        [TestMethod]
        public void TestGetCommands()
        {
            SplayTree_int splaytree = new SplayTree_int(new List<Node>());

            Assert.IsNotNull(splaytree.Commands);
        }

        [TestMethod]
        public void TestNodesGet()
        {
            SplayTree_int splaytree = new SplayTree_int(new List<Node>());

            Assert.IsNotNull(splaytree.Nodes);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestNodesSet()
        {
            SplayTree_int splaytree = new SplayTree_int(new List<Node>());

            splaytree.Nodes = null;
        }
    }
}
