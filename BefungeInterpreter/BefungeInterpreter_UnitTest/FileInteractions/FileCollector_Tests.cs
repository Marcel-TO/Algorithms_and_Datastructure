//-----------------------------------------------------------------------
// <copyright file="FileCollector_Tests.cs" company="FHWN">
//     Copyright (c) Marcel Turobin-Ort. All rights reserved.
// </copyright>
// <author>Marcel Turobin-Ort</author>
// <summary>Defines the test class for collecting all files.</summary>
//-----------------------------------------------------------------------
namespace BefungeInterpreter_UnitTests.FileInteractions
{
    using System;
    using BefungeInterpreter.FileInteractions;
    using BefungeInterpreter_UnitTests.TestInstances;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Represents the unit tests for the file collector class.
    /// </summary>
    [TestClass]
    public class FileCollector_Tests
    {
        /// <summary>
        /// Represents a method for testing if constructor is null.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Constructor_Test_Null()
        {
            FileCollector collector = new FileCollector(null);
        }

        /// <summary>
        /// Represents a method for testing if constructor is not null.
        /// </summary>
        [TestMethod]
        public void Constructor_Test_Correct()
        {
            LoggerReplacementInstance logger = new LoggerReplacementInstance();
            FileCollector collector = new FileCollector(logger);

            Assert.IsNotNull(logger);
            Assert.IsNotNull(collector);
        }

        /// <summary>
        /// Represents a method for testing if the getting files are correct.
        /// </summary>
        [TestMethod]
        public void GetFiles_Test()
        {
            LoggerReplacementInstance logger = new LoggerReplacementInstance();
            FileCollector collector = new FileCollector(logger);

            string[] paths = collector.GetFiles();
            Assert.IsNotNull(paths);
        }
    }
}