//-----------------------------------------------------------------------
// <copyright file="ChaoCipher_Tests.cs" company="FHWN">
//     Copyright (c) Marcel Turobin-Ort. All rights reserved.
// </copyright>
// <author>Marcel Turobin-Ort</author>
// <summary>Defines the class for testing the chaos cipher encryption.</summary>
//-----------------------------------------------------------------------
namespace Encryption_UnitTests.Logic
{
    using System;
    using Encryption.Logic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Represents the unit tests for the chaos cipher encryption.
    /// </summary>
    [TestClass]
    public class ChaoCipher_Tests
    {
        /// <summary>
        /// Represents a method for testing if the first parameter is null.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestIfParameter1IsNull()
        {
            ChaoCipher cipher = new ChaoCipher(null, "PTLNBQDEOYSFAVZKGJRIHWXUMC");
        }

        /// <summary>
        /// Represents a method for testing if the second parameter is null.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestIfParameter2IsNull()
        {
            ChaoCipher cipher = new ChaoCipher("HXUCZVAMDSLKPEFJRIGTWOBNYQ", null);
        }

        /// <summary>
        /// Represents a method for testing if the first parameter is out of range.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestIfParameter1IsOutOfRange()
        {
            ChaoCipher cipher = new ChaoCipher("test", "PTLNBQDEOYSFAVZKGJRIHWXUMC");
        }

        /// <summary>
        /// Represents a method for testing if the second parameter is out of range.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestIfParameter1IOutOfRange()
        {
            ChaoCipher cipher = new ChaoCipher("HXUCZVAMDSLKPEFJRIGTWOBNYQ", "test");
        }

        /// <summary>
        /// Represents a method for testing if the first parameter is wrong.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestIfParameter1IsWrong()
        {
            ChaoCipher cipher = new ChaoCipher("#", "PTLNBQDEOYSFAVZKGJRIHWXUMC");
        }

        /// <summary>
        /// Represents a method for testing if the second parameter is wrong.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestIfParameter2IsWrong()
        {
            ChaoCipher cipher = new ChaoCipher("HXUCZVAMDSLKPEFJRIGTWOBNYQ", "#+");
        }

        /// <summary>
        /// Represents a method for testing if decrypt parameter is null.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestIfDecryptParameterIsNull()
        {
            ChaoCipher cipher = new ChaoCipher("HXUCZVAMDSLKPEFJRIGTWOBNYQ", "PTLNBQDEOYSFAVZKGJRIHWXUMC");
            cipher.Decrypt(null);
        }

        /// <summary>
        /// Represents a method for testing if encrypt parameter is null.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestIfEncryptParameterIsNull()
        {
            ChaoCipher cipher = new ChaoCipher("HXUCZVAMDSLKPEFJRIGTWOBNYQ", "PTLNBQDEOYSFAVZKGJRIHWXUMC");
            cipher.Encrypt(null);
        }

        /// <summary>
        /// Represents a method for testing if encrypt works properly.
        /// </summary>
        [TestMethod]
        public void TestIfEncryptWorks()
        {
            ChaoCipher cipher = new ChaoCipher("HXUCZVAMDSLKPEFJRIGTWOBNYQ", "PTLNBQDEOYSFAVZKGJRIHWXUMC");
            string encrypted = cipher.Encrypt("testmessage");

            Assert.IsTrue(encrypted == "IVYIEVYYDRV");
        }

        /// <summary>
        /// Represents a method for testing if decrypt works properly.
        /// </summary>
        [TestMethod]
        public void TestIfDecryptWorks()
        {
            ChaoCipher cipher = new ChaoCipher("HXUCZVAMDSLKPEFJRIGTWOBNYQ", "PTLNBQDEOYSFAVZKGJRIHWXUMC");
            string decrypted = cipher.Decrypt("IVYIEVYYDRV");

            Assert.IsTrue(decrypted == "TESTMESSAGE");
        }
    }
}
