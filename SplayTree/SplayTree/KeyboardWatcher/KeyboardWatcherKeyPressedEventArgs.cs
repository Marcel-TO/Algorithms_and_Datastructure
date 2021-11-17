//-----------------------------------------------------------------------
// <copyright file="KeyboardWatcherKeyPressedEventArgs.cs" company="FHWN">
//     Copyright (c) Marcel Turobin-Ort. All rights reserved.
// </copyright>
// <author>Marcel Turobin-Ort</author>
// <summary>Defines the arguments of the keyboard watcher event.</summary>
//-----------------------------------------------------------------------
namespace SplayTree.KeyboardWatcher
{
    using System;
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// Represents the arguments of the event.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class KeyboardWatcherKeyPressedEventArgs : EventArgs
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="KeyboardWatcherKeyPressedEventArgs"/> class.
        /// </summary>
        /// <param name="key">Represents key pressed by user.</param>
        public KeyboardWatcherKeyPressedEventArgs(ConsoleKey key)
        {
            this.Key = key;
        }

        /// <summary>
        /// Gets the key.
        /// </summary>
        /// <value> The pressed key.</value>
        public ConsoleKey Key
        {
            get;
            private set;
        }
    }
}
