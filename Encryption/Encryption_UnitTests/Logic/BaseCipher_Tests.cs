//-----------------------------------------------------------------------
// <copyright file="BaseCipher_Tests.cs" company="FHWN">
//     Copyright (c) Marcel Turobin-Ort. All rights reserved.
// </copyright>
// <author>Marcel Turobin-Ort</author>
// <summary>Defines the class for testing the base cipher encryption.</summary>
//-----------------------------------------------------------------------
namespace Encryption_UnitTests.Logic
{
    using Encryption.Logic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Represents the unit tests for the abstract base cipher encryption.
    /// </summary>
    [TestClass]
    public class BaseCipher_Tests
    {
        /// <summary>
        /// Represents a method for testing if get from name works properly.
        /// </summary>
        [TestMethod]
        public void TestIfNameGetWorks()
        {
            AutokeyCipher cipher = new AutokeyCipher("test");
            Assert.IsTrue(cipher.Name == "Autokey cipher");
        }
    }
}
