//-----------------------------------------------------------------------
// <copyright file="KeyboardWatcher.cs" company="FHWN">
//     Copyright (c) Marcel Turobin-Ort. All rights reserved.
// </copyright>
// <author>Marcel Turobin-Ort</author>
// <summary>Defines the keyboard watcher for getting user input.</summary>
//-----------------------------------------------------------------------
namespace Encryption.Logic
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using Encryption.EventArgs;
    using Encryption.Interfaces;

    /// <summary>
    /// Represents a class for watching user input.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class KeyboardWatcher : IKeyboardWatcher
    {
        /// <summary>
        /// Represents the event which fires, if a key got pressed.
        /// </summary>
        public event EventHandler<KeyboardWatcherEventArgs> MenuNavigation;

        /// <summary>
        /// Represents the event which fires, if a key got pressed.
        /// </summary>
        public event EventHandler<KeyboardCipherEventArgs> KeyPressed;

        /// <summary>
        /// Represents the start of the menu navigation.
        /// </summary>
        public void StartNav()
        {
            ConsoleKey key = Console.ReadKey(true).Key;
            this.MenuNavigation?.Invoke(this, new KeyboardWatcherEventArgs(key));
        }

        /// <summary>
        /// Represents a method for starting the user input watcher.
        /// </summary>
        /// <param name="cipher">The current selected encryption.</param>
        public void StartKey(BaseCipher cipher)
        {
            ConsoleKey key = Console.ReadKey(true).Key;
            this.KeyPressed?.Invoke(this, new KeyboardCipherEventArgs(key, cipher));
        }

        /// <summary>
        /// Represents the method that gets the user input.
        /// </summary>
        /// <returns>The input from user.</returns>
        public string ReadLine()
        {
            return Console.ReadLine();
        }

        /// <summary>
        /// Represents the method for awaiting the for user input to continue.
        /// </summary>
        public void Continue()
        {
            Console.ReadKey(true);
        }
    }
}
