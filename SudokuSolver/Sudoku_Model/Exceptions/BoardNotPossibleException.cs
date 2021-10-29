//-----------------------------------------------------------------------
// <copyright file="BoardNotPossibleException.cs" company="FHWN">
//     Copyright (c) Marcel Turobin-Ort. All rights reserved.
// </copyright>
// <author>Marcel Turobin-Ort</author>
// <summary> Defines the exception that occurs if the board was not possible to create.</summary>
//-----------------------------------------------------------------------
namespace Sudoku_Model.Exceptions
{
    using System;

    /// <summary>
    /// Represents the exception which is thrown if the board would not be valid.
    /// </summary>
    public class BoardNotPossibleException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BoardNotPossibleException"/> class.
        /// </summary>
        /// <param name="message">The message of the exception.</param>
        public BoardNotPossibleException(string message) : base(message)
        {
        }
    }
}
