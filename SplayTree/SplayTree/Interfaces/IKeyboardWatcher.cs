﻿//-----------------------------------------------------------------------
// <copyright file="IKeyboardWatcher.cs" company="FHWN">
//     Copyright (c) Marcel Turobin-Ort. All rights reserved.
// </copyright>
// <author>Marcel Turobin-Ort</author>
// <summary>Defines the interface for user input purpose.</summary>
//-----------------------------------------------------------------------
namespace SplayTree.Interfaces
{
    using System;
    using SplayTree.KeyboardWatcher;

    /// <summary>
    /// Represents the interface of the keyboard watcher for user input.
    /// </summary>
    public interface IKeyboardWatcher
    {
        /// <summary>
        /// Represents the event which fires, if a key got pressed.
        /// </summary>
        public event EventHandler<KeyboardWatcherKeyPressedEventArgs> KeyPressed;

        /// <summary>
        /// Represents the start of the keyboard watcher.
        /// </summary>
        void Start();
    }
}
