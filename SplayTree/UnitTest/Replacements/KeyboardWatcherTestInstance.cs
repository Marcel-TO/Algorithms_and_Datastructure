//-----------------------------------------------------------------------
// <copyright file="KeyboardWatcherTestInstance.cs" company="FHWN">
//     Copyright (c) Marcel Turobin-Ort. All rights reserved.
// </copyright>
// <author>Marcel Turobin-Ort</author>
// <summary>Defines the keyboard watcher replacement for testing purpose only.</summary>
//-----------------------------------------------------------------------
namespace UnitTest.Replacements
{
    using System;
    using SplayTree.Interfaces;
    using SplayTree.KeyboardWatcher;

    /// <summary>
    /// Represents the keyboard watcher for testing purpose.
    /// </summary>
    public class KeyboardWatcherTestInstance : IKeyboardWatcher
    {
        /// <summary>
        /// Occurs if pressing a key gets simulated.
        /// </summary>
        public event EventHandler<KeyboardWatcherKeyPressedEventArgs> KeyPressed;

        /// <summary>
        /// Represents the start of the keyboard watcher.
        /// </summary>
        public void Start()
        {
            this.KeyPressed?.Invoke(this, new KeyboardWatcherKeyPressedEventArgs(ConsoleKey.UpArrow));
            this.KeyPressed?.Invoke(this, new KeyboardWatcherKeyPressedEventArgs(ConsoleKey.DownArrow));
            this.KeyPressed?.Invoke(this, new KeyboardWatcherKeyPressedEventArgs(ConsoleKey.Enter));
            this.KeyPressed?.Invoke(this, new KeyboardWatcherKeyPressedEventArgs(ConsoleKey.Escape));
        }
    }
}
