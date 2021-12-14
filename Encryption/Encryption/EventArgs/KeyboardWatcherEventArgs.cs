//-----------------------------------------------------------------------
// <copyright file="KeyboardWatcherEventArgs.cs" company="FHWN">
//     Copyright (c) Marcel Turobin-Ort. All rights reserved.
// </copyright>
// <author>Marcel Turobin-Ort</author>
// <summary>Defines the event arguments if a key is pressed.</summary>
//-----------------------------------------------------------------------
namespace Encryption.EventArgs
{
    using System;
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// Represents the event arguments containing the pressed key.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class KeyboardWatcherEventArgs
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="KeyboardWatcherEventArgs"/> class.
        /// </summary>
        /// <param name="key">The current pressed key.</param>
        public KeyboardWatcherEventArgs(ConsoleKey key)
        {
            this.Key = key;
        }

        /// <summary>
        /// Gets the current pressed key.
        /// </summary>
        /// <value>The current pressed key.</value>
        public ConsoleKey Key
        {
            get;
            private set;
        }
    }
}
