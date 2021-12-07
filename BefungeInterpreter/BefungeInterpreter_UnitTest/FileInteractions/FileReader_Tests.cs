//-----------------------------------------------------------------------
// <copyright file="FileReader_Tests.cs" company="FHWN">
//     Copyright (c) Marcel Turobin-Ort. All rights reserved.
// </copyright>
// <author>Marcel Turobin-Ort</author>
// <summary>Defines the test class for reading all files.</summary>
//-----------------------------------------------------------------------
namespace BefungeInterpreter_UnitTests.FileInteractions
{
    using System;
    using System.IO;
    using BefungeInterpreter.FileInteractions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Represents the unit tests for the file reader class.
    /// </summary>
    [TestClass]
    public class FileReader_Tests
    {
        /// <summary>
        /// Represents a method for testing if constructor is correct.
        /// </summary>
        [TestMethod]
        public void Constructor_Test()
        {
            FileReader reader = new FileReader();
            Assert.IsNotNull(reader);
        }

        /// <summary>
        /// Represents a method for testing if reading a file is correct.
        /// </summary>
        [TestMethod]
        public void ReadFile_Test_Correct()
        {
            string path = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..\..\ExamplePrograms\test.txt"));

            FileReader reader = new FileReader();
            string[] content = reader.ReadFile(path);

            Assert.IsNotNull(content);
        }

        /// <summary>
        /// Represents a method for testing if the path is null.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ReadFile_Test_Null()
        {
            FileReader reader = new FileReader();

            string[] content = reader.ReadFile(null);
        }

        /// <summary>
        /// Represents a method for testing if path is wrong.
        /// </summary>
        [TestMethod]
        public void ReadFile_Test_Wrong()
        {
            string path = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..\..\ExamplePrograms\doesNotExist.txt"));

            FileReader reader = new FileReader();

            string[] content = reader.ReadFile(path);

            Assert.IsNull(content);
        }
    }
}