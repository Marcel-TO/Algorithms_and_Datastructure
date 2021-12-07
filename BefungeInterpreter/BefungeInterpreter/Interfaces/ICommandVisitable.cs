//-----------------------------------------------------------------------
// <copyright file="ICommandVisitable.cs" company="FHWN">
//     Copyright (c) Marcel Turobin-Ort. All rights reserved.
// </copyright>
// <author>Marcel Turobin-Ort</author>
// <summary>Defines the interface for the command visitor pattern.</summary>
//-----------------------------------------------------------------------
namespace BefungeInterpreter.Interfaces
{
    /// <summary>
    /// Represents the interface for the command visitor pattern.
    /// </summary>
    public interface ICommandVisitable
    {
        /// <summary>
        /// Represents accept method for the visitor pattern.
        /// </summary>
        /// <param name="visitor">The command visitor.</param>
        void Accept(ICommandVisitor visitor);
    }
}
