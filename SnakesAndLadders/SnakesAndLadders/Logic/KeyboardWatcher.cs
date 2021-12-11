//-----------------------------------------------------------------------
// <copyright file="KeyboardWatcher.cs" company="FHWN">
//     Copyright (c) Marcel Turobin-Ort. All rights reserved.
// </copyright>
// <author>Marcel Turobin-Ort</author>
// <summary>Defines the keyboard watcher for getting user input.</summary>
//-----------------------------------------------------------------------
namespace SnakesAndLadders.Logic
{
    using System;
    using SnakesAndLadders.Interfaces;

    /// <summary>
    /// Represents a class for watching user input.
    /// </summary>
    public class KeyboardWatcher : IKeyboardWatcher
    {
        /// <summary>
        /// Represents a method for waiting user input until user presses enter.
        /// </summary>
        /// <returns>The user input.</returns>
        public string ReadLine()
        {
            return Console.ReadLine();
        }

        /// <summary>
        /// Represents a method for getting the pressed key.
        /// </summary>
        /// <returns>The pressed key.</returns>
        public ConsoleKeyInfo Continue()
        {
            return Console.ReadKey(true);
        }
    }
}
