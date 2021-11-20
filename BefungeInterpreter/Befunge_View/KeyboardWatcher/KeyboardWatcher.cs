//-----------------------------------------------------------------------
// <copyright file="KeyboardWatcher.cs" company="FHWN">
//     Copyright (c) Marcel Turobin-Ort. All rights reserved.
// </copyright>
// <author>Marcel Turobin-Ort</author>
// <summary>Defines the keyboard watcher for getting user input.</summary>
//-----------------------------------------------------------------------
namespace BefungeInterpreter.KeyboardWatcher
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using BefungeInterpreter.Interfaces;

    /// <summary>
    /// Represents a class for watching user input.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class KeyboardWatcher : IKeyboardWatcher
    {
        /// <summary>
        /// Represents the event which fires if a key got pressed.
        /// </summary>
        public event EventHandler<KeyboardWatcherKeyPressedEventArgs> KeyPressed;

        /// <summary>
        /// Represents the method for starting the keyboard watcher.
        /// </summary>
        public void Start()
        {
            ConsoleKeyInfo cki = Console.ReadKey(true);
            this.FireKeyPressed(cki.Key);
        }

        /// <summary>
        /// Represents the method for firing the event.
        /// </summary>
        /// <param name="key">Represents the key which got pressed by user.</param>
        private void FireKeyPressed(ConsoleKey key)
        {
            this.KeyPressed?.Invoke(this, new KeyboardWatcherKeyPressedEventArgs(key));
        }
    }
}
