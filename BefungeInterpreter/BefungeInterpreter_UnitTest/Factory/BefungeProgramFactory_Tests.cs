//-----------------------------------------------------------------------
// <copyright file="BefungeProgramFactory_Tests.cs" company="FHWN">
//     Copyright (c) Marcel Turobin-Ort. All rights reserved.
// </copyright>
// <author>Marcel Turobin-Ort</author>
// <summary>Defines the test class befunge program factory class.</summary>
//-----------------------------------------------------------------------
namespace BefungeInterpreter_UnitTests.Factory
{
    using System;
    using System.IO;
    using BefungeInterpreter.Factory;
    using BefungeInterpreter.Logic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Represents the unit tests for the program factory class.
    /// </summary>
    [TestClass]
    public class BefungeProgramFactory_Tests
    {
        /// <summary>
        /// Represents a method for testing if constructor is not null.
        /// </summary>
        [TestMethod]
        public void Constructor_Test()
        {
            BefungeProgramFactory factory = new BefungeProgramFactory();
            Assert.IsNotNull(factory);
        }

        /// <summary>
        /// Represents a method for testing if the program is correct.
        /// </summary>
        [TestMethod]
        public void CreateBefungeProgram()
        {
            string path = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..\..\ExamplePrograms\test.txt"));

            BefungeProgramFactory factory = new BefungeProgramFactory();
            BefungeProgram program = factory.CreateBefungeProgram(path);

            Assert.IsNotNull(program);
        }

        /// <summary>
        /// Represents a method for testing if the path is null.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CreateBefungeProgram_Null()
        {
            BefungeProgramFactory factory = new BefungeProgramFactory();
            BefungeProgram program = factory.CreateBefungeProgram(null);

            Assert.IsNotNull(program);
        }
    }
}