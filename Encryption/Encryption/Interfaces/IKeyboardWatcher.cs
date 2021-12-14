//-----------------------------------------------------------------------
// <copyright file="IKeyboardWatcher.cs" company="FHWN">
//     Copyright (c) Marcel Turobin-Ort. All rights reserved.
// </copyright>
// <author>Marcel Turobin-Ort</author>
// <summary>Defines the interface for user input purpose.</summary>
//-----------------------------------------------------------------------
namespace Encryption.Interfaces
{
    using System;
    using Encryption.EventArgs;
    using Encryption.Logic;

    /// <summary>
    /// Represents the interface of the keyboard watcher for user input.
    /// </summary>
    public interface IKeyboardWatcher
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
        void StartNav();

        /// <summary>
        /// Represents a method for starting the user input watcher.
        /// </summary>
        /// <param name="cipher">The current selected encryption.</param>
        void StartKey(BaseCipher cipher);

        /// <summary>
        /// Represents the method that gets the user input.
        /// </summary>
        /// <returns>The input from user.</returns>
        string ReadLine();

        /// <summary>
        /// Represents the method for awaiting the for user input to continue.
        /// </summary>
        void Continue();
    }
}
