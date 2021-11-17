//-----------------------------------------------------------------------
// <copyright file="ICommandVisitable.cs" company="FHWN">
//     Copyright (c) Marcel Turobin-Ort. All rights reserved.
// </copyright>
// <author>Marcel Turobin-Ort</author>
// <summary>Defines the interface for the command visitor pattern.</summary>
//-----------------------------------------------------------------------
namespace SplayTree.Interfaces
{
    /// <summary>
    /// Represents the interface for the command visitor pattern.
    /// </summary>
    public interface ICommandVisitable
    {
        /// <summary>
        /// Represents the accept method for the command.
        /// </summary>
        void Accept(ICommandVisitor visitor);
    }
}