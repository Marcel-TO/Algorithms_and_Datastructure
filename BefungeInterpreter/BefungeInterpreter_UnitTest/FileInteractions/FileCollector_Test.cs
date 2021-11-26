namespace BefungeInterpreter_UnitTests.FileInteractions
{
    using System;
    using System.IO;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using BefungeInterpreter.FileInteractions;

    [TestClass]
    public class FileCollector_Tests
    {
        [TestMethod]
        [ExpectedException(ArgumentNullException)]
        public void Constructor_Test_Null()
        {
            FileCollector collector = new FileCollector(null);
        }

        [TestMethod]
        public void Constructor_Test_Correct()
        {
            LoggerReplacementInstance logger = new LoggerReplacementInstance();
            FileCollector collector = new FileCollector(logger);

            Assert.IsNotNull(logger);
            Assert.IsNotNull(collector);
        }

        [Testmethod]
        public void GetFiles_Test()
        {
            LoggerReplacementInstance logger = new LoggerReplacementInstance();
            FileCollector collector = new FileCollector(logger);

            string[] paths = collector.GetFiles();
            Assert.IsNotNull(paths);
        }
    }
}