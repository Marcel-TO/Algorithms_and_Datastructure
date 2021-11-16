namespace UnitTest.Logic
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting; 
    using SplayTree;

    [TestClass]
    public class Program_Test
    {
        [TestMethod]
        public void TestIfProgramIsNull()
        {
            Program program = new Program();

            Assert.IsNotNull(program);
        }

        [TestMethod]
        public void TestMain()
        {
            Program program = new Program();
        }
    }
}
