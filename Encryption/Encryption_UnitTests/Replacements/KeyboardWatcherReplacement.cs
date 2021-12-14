//-----------------------------------------------------------------------
// <copyright file="KeyboardWatcherReplacement.cs" company="FHWN">
//     Copyright (c) Marcel Turobin-Ort. All rights reserved.
// </copyright>
// <author>Marcel Turobin-Ort</author>
// <summary>Defines the keyboard watcher replacement for testing purpose only.</summary>
//-----------------------------------------------------------------------
namespace Encryption_UnitTests.Replacements
{
    using System;
    using Encryption.EventArgs;
    using Encryption.Interfaces;
    using Encryption.Logic;

    /// <summary>
    /// Represents the keyboard watcher for testing purpose.
    /// </summary>
    public class KeyboardWatcherReplacement : IKeyboardWatcher
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
        /// Represents the method for awaiting the for user input to continue.
        /// </summary>
        public void Continue()
        {
            return;
        }

        /// <summary>
        /// Represents the method that gets the user input.
        /// </summary>
        /// <returns>The input from user.</returns>
        public string ReadLine()
        {
            return "testmessage";
        }

        /// <summary>
        /// Represents a method for starting the user input watcher.
        /// </summary>
        /// <param name="cipher">The current selected encryption.</param>
        public void StartKey(BaseCipher cipher)
        {
            this.KeyPressed?.Invoke(this, new KeyboardCipherEventArgs(ConsoleKey.E, new AutokeyCipher("primer")));
            this.KeyPressed?.Invoke(this, new KeyboardCipherEventArgs(ConsoleKey.D, new AutokeyCipher("primer")));
            this.KeyPressed?.Invoke(this, new KeyboardCipherEventArgs(ConsoleKey.Escape, new AutokeyCipher("primer")));
        }

        /// <summary>
        /// Represents the start of the menu navigation.
        /// </summary>
        public void StartNav()
        {
            this.MenuNavigation?.Invoke(this, new KeyboardWatcherEventArgs(ConsoleKey.UpArrow));
            this.MenuNavigation?.Invoke(this, new KeyboardWatcherEventArgs(ConsoleKey.DownArrow));
            this.MenuNavigation?.Invoke(this, new KeyboardWatcherEventArgs(ConsoleKey.Enter));
            this.MenuNavigation?.Invoke(this, new KeyboardWatcherEventArgs(ConsoleKey.Escape));
        }
    }
}
