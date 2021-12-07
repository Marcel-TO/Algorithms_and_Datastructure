//-----------------------------------------------------------------------
// <copyright file="BefungeProgramNotPossible.cs" company="FHWN">
//     Copyright (c) Marcel Turobin-Ort. All rights reserved.
// </copyright>
// <author>Marcel Turobin-Ort</author>
// <summary>Defines the exception indicating that the befunge program is not valid.</summary>
//-----------------------------------------------------------------------
namespace BefungeInterpreter.Execptions
{
    using System;
    using BefungeInterpreter.Logic;

    /// <summary>
    /// Represents the exception which is thrown when the <see cref="BefungeProgram"/> is not valid.
    /// </summary>
    public class BefungeProgramNotPossible : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BefungeProgramNotPossible"/> class.
        /// </summary>
        /// <param name="message">The message of the exception.</param>
        public BefungeProgramNotPossible(string message) : base(message)
        {
        }
    }
}
