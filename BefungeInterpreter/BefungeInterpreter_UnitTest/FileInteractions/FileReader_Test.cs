namespace BefungeInterpreter_UnitTests.FileInteractions
{
    using System;
    using System.IO;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using BefungeInterpreter.FileInteractions;
    using BefungeInterpreter.Logic;

    public class FileReader_Test
    {
        public void Constructor_Test()
        {
            FileReader reader = new FileReader();
            Assert.IsNotNull(factory);
        }

        public void ReadFile_Test_Correct()
        {
            string path = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..\..\ExamplePrograms\test.txt"));

            FileReader reader = new FileReader();

            string[] content = reader.ReadFile(path);

            Assert.IsNotNull(content);
        }

        public void ReadFile_Test_Null()
        {
            FileReader reader = new FileReader();

            string[] content = reader.ReadFile(null);

            Assert.IsNull(content);
        }

        public void ReadFile_Test_Wrong()
        {
            string path = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..\..\ExamplePrograms\doesNotExist.txt"));

            FileReader reader = new FileReader();

            string[] content = reader.ReadFile(path);

            Assert.IsNull(content);
        }
    }
}