namespace BefungeInterpreter_UnitTests.Factory
{
    using System;
    using System.IO;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using BefungeInterpreter.Factory;
    using BefungeInterpreter.Logic;

    [TestClass]
    public class BefungeProgramFactory_Tests
    {
        [TestMethod]
        public void Constructor_Test()
        {
            BefungeProgramFactory factory = new BefungeProgramFactory();
            Assert.IsNotNull(factory);
        }

        [TestMethod]
        public void CreateBefungeProgram()
        {
            string path = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..\..\ExamplePrograms\test.txt"));

            BefungeProgramFactory factory = new BefungeProgramFactory();
            BefungeProgram program = factory.CreateBefungeProgram(path);

            Assert.IsNotNull(program);
        }
    }
}