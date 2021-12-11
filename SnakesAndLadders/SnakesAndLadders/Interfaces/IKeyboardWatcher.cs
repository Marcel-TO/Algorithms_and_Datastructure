//-----------------------------------------------------------------------
// <copyright file="IKeyboardWatcher.cs" company="FHWN">
//     Copyright (c) Marcel Turobin-Ort. All rights reserved.
// </copyright>
// <author>Marcel Turobin-Ort</author>
// <summary>Defines the interface for user input purpose.</summary>
//-----------------------------------------------------------------------
namespace SnakesAndLadders.Interfaces
{
    using System;

    /// <summary>
    /// Represents the interface of the keyboard watcher for user input.
    /// </summary>
    public interface IKeyboardWatcher
    {
        /// <summary>
        /// Represents the method for awaiting user input.
        /// </summary>
        /// <returns>The input from user.</returns>
        string ReadLine();

        /// <summary>
        /// Represents the method for awaiting if key gets pressed.
        /// </summary>
        /// <returns>The pressed key from user.</returns>
        ConsoleKeyInfo Continue();
    }
}
