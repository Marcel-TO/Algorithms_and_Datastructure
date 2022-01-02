//-----------------------------------------------------------------------
// <copyright file="RandomGenerator.cs" company="FHWN">
//     Copyright (c) Marcel Turobin-Ort. All rights reserved.
// </copyright>
// <author>Marcel Turobin-Ort</author>
// <summary>Defines the random number generator.</summary>
//-----------------------------------------------------------------------
namespace MazeGenerator_Model.Logic
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using MazeGenerator_Model.Interfaces;

    /// <summary>
    /// Represents the random number generator.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class RandomGenerator : IRandom
    {
        /// <summary>
        /// Represents the random generator.
        /// </summary>
        private Random random;

        /// <summary>
        /// Initializes a new instance of the <see cref="RandomGenerator"/> class.
        /// </summary>
        public RandomGenerator()
        {
            this.random = new Random();
        }

        /// <summary>
        /// Represents the method for creating a random number.
        /// </summary>
        /// <param name="min">The minimum number.</param>
        /// <param name="max">The maximum number.</param>
        /// <returns>The new random generated number.</returns>
        public int Random(int min, int max)
        {
            return this.random.Next(min, max);
        }
    }
}
