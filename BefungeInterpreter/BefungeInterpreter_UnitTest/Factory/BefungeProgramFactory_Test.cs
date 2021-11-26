namespace BefungeInterpreter_UnitTests.Factory
{
    using System;
    using System.IO;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using BefungeInterpreter.Factory;
    using BefungeInterpreter.Logic;

    public class BefungeProgramFactory_Test
    {
        public void Constructor_Test()
        {
            BefungeProgramFactory factory = new BefungeProgramFactory();
            Assert.IsNotNull(factory);
        }

        public void CreateBefungeProgram()
        {
            string path = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..\..\ExamplePrograms\test.txt"));

            BefungeProgramFactory factory = new BefungeProgramFactory();
            BefungeProgram program = factory.CreateBefungeProgram(path);

            Assert.IsNotNull(program);
        }
    }
}