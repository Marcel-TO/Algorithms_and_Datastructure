//-----------------------------------------------------------------------
// <copyright file="Field_Tests.cs" company="FHWN">
//     Copyright (c) Marcel Turobin-Ort. All rights reserved.
// </copyright>
// <author>Marcel Turobin-Ort</author>
// <summary>Defines the test class for the field class.</summary>
//-----------------------------------------------------------------------
namespace SnakesAndLadders_UnitTests.GameObjects
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using SnakesAndLadders.GameObjects;

    /// <summary>
    /// Represents the unit tests for the field class.
    /// </summary>
    [TestClass]
    public class Field_Tests
    {
        /// <summary>
        /// Represents a method for testing if the parameter is negative.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestIfSizeIsNegative()
        {
            Field field = new Field(-100);
        }

        /// <summary>
        /// Represents a method for testing if the get from pointer works.
        /// </summary>
        [TestMethod]
        public void TestIfPointerGetWorks()
        {
            Field field = new Field(5);
            Assert.IsTrue(field.Pointer == 5);
        }

        /// <summary>
        /// Represents a method for testing if the set from pointer works.
        /// </summary>
        [TestMethod]
        public void TestIfPointerSetWorks()
        {
            Field field = new Field(5);
            field.Pointer = 3;
            Assert.IsTrue(field.Pointer == 3);
        }

        /// <summary>
        /// Represents a method for testing if the get from is special works.
        /// </summary>
        [TestMethod]
        public void TestIfIsSpecialGetWorks()
        {
            Field field = new Field(5);
            Assert.IsFalse(field.IsSpecial);
        }

        /// <summary>
        /// Represents a method for testing if the get from is special works.
        /// </summary>
        [TestMethod]
        public void TestIfIsSpecialSetWorks()
        {
            Field field = new Field(5);
            field.IsSpecial = true;
            Assert.IsTrue(field.IsSpecial);
        }
    }
}
