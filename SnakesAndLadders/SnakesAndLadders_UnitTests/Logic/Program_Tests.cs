//-----------------------------------------------------------------------
// <copyright file="Program_Tests.cs" company="FHWN">
//     Copyright (c) Marcel Turobin-Ort. All rights reserved.
// </copyright>
// <author>Marcel Turobin-Ort</author>
// <summary>Defines the test class for the program class.</summary>
//-----------------------------------------------------------------------
namespace SnakesAndLadders_UnitTests.Logic
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using SnakesAndLadders.Logic;

    /// <summary>
    /// Represents the unit tests for the program class.
    /// </summary>
    [TestClass]
    public class Program_Tests
    {
        /// <summary>
        /// Represents a method for testing if the program is null.
        /// </summary>
        [TestMethod]
        public void TestIfProgramIsNull()
        {
            Program program = new Program();

            Assert.IsNotNull(program);
        }
    }
}
