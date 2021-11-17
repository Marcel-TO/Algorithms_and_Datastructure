//-----------------------------------------------------------------------
// <copyright file="ILogable.cs" company="FHWN">
//     Copyright (c) Marcel Turobin-Ort. All rights reserved.
// </copyright>
// <author>Marcel Turobin-Ort</author>
// <summary>Defines the interface for the logging visitor pattern.</summary>
//-----------------------------------------------------------------------
namespace SplayTree.Interfaces
{
    /// <summary>
    /// Represents the interface for the logging visitor pattern.
    /// </summary>
    public interface ILogable
    {
        /// <summary>
        /// Represents the logging method of the interface.
        /// </summary>
        /// <param name="logger">Represents the logging visitor pattern.</param>
        void Log(ILogger logger);
    }
}
