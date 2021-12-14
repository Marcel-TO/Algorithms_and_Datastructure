//-----------------------------------------------------------------------
// <copyright file="AutokeyCipher_Tests.cs" company="FHWN">
//     Copyright (c) Marcel Turobin-Ort. All rights reserved.
// </copyright>
// <author>Marcel Turobin-Ort</author>
// <summary>Defines the class for testing the auto key cipher encryption.</summary>
//-----------------------------------------------------------------------
namespace Encryption_UnitTests.Logic
{
    using System;
    using Encryption.Logic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Represents the unit tests for the auto key cipher encryption.
    /// </summary>
    [TestClass]
    public class AutokeyCipher_Tests
    {
        /// <summary>
        /// Represents a method for testing if parameter is null.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestIfParameterIsNull()
        {
            AutokeyCipher cipher = new AutokeyCipher(null);
        }

        /// <summary>
        /// Represents a method for testing if decrypt parameter is null.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestIfDecryptParameterIsNull()
        {
            AutokeyCipher cipher = new AutokeyCipher("test");
            cipher.Decrypt(null);
        }

        /// <summary>
        /// Represents a method for testing if encrypt parameter is null.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestIfEncryptParameterIsNull()
        {
            AutokeyCipher cipher = new AutokeyCipher("test");
            cipher.Encrypt(null);
        }

        /// <summary>
        /// Represents a method for testing if encrypt works properly.
        /// </summary>
        [TestMethod]
        public void TestIfEncryptWorks()
        {
            AutokeyCipher cipher = new AutokeyCipher("test");
            string encrypted = cipher.Encrypt("testmessage");

            Assert.IsTrue(encrypted == "MIKMFIKLMKW");
        }

        /// <summary>
        /// Represents a method for testing if decrypt works properly.
        /// </summary>
        [TestMethod]
        public void TestIfDecryptWorks()
        {
            AutokeyCipher cipher = new AutokeyCipher("test");
            string decrypted = cipher.Decrypt("MIKMFIKLMKW");

            Assert.IsTrue(decrypted == "TESTMESSAGE");
        }
    }
}
