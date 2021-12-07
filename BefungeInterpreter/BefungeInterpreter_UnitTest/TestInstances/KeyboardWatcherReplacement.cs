//-----------------------------------------------------------------------
// <copyright file="KeyboardWatcherReplacement.cs" company="FHWN">
//     Copyright (c) Marcel Turobin-Ort. All rights reserved.
// </copyright>
// <author>Marcel Turobin-Ort</author>
// <summary>Defines the keyboard watcher replacement for testing purpose only.</summary>
//-----------------------------------------------------------------------
namespace BefungeInterpreter_UnitTests.TestInstances
{
    using System;
    using BefungeInterpreter.Interfaces;
    using BefungeInterpreter.KeyboardWatcher;

    /// <summary>
    /// Represents the keyboard watcher for testing purpose.
    /// </summary>
    public class KeyboardWatcherReplacement : IKeyboardWatcher
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
            return;
        }
    }
}