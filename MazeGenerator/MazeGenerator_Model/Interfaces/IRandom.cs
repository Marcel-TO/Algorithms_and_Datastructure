//-----------------------------------------------------------------------
// <copyright file="IRandom.cs" company="FHWN">
//     Copyright (c) Marcel Turobin-Ort. All rights reserved.
// </copyright>
// <author>Marcel Turobin-Ort</author>
// <summary>Defines the random number generator interface.</summary>
//-----------------------------------------------------------------------
namespace MazeGenerator_Model.Interfaces
{
    /// <summary>
    /// Represents the random number generator interface.
    /// </summary>
    public interface IRandom
    {
        /// <summary>
        /// Represents the random number generator.
        /// </summary>
        /// <param name="min">The minimum number.</param>
        /// <param name="max">The maximum number.</param>
        /// <returns>The new generated number.</returns>
        int Random(int min, int max);
    }
}
