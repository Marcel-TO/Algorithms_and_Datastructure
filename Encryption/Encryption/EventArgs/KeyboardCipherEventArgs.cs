//-----------------------------------------------------------------------
// <copyright file="KeyboardCipherEventArgs.cs" company="FHWN">
//     Copyright (c) Marcel Turobin-Ort. All rights reserved.
// </copyright>
// <author>Marcel Turobin-Ort</author>
// <summary>Defines the event arguments for the encrypted cipher.</summary>
//-----------------------------------------------------------------------
namespace Encryption.EventArgs
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using Encryption.Logic;

    /// <summary>
    /// Represents the event arguments containing the cipher and the pressed key.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class KeyboardCipherEventArgs
    {
        /// <summary>
        /// Represents the current cipher encryption.
        /// </summary>
        private BaseCipher cipher;

        /// <summary>
        /// Initializes a new instance of the <see cref="KeyboardCipherEventArgs"/> class.
        /// </summary>
        /// <param name="key">The pressed key.</param>
        /// <param name="cipher">The current selected cipher.</param>
        public KeyboardCipherEventArgs(ConsoleKey key, BaseCipher cipher)
        {
            this.Key = key;
            this.Cipher = cipher;
        }

        /// <summary>
        /// Gets the pressed key.
        /// </summary>
        /// <value>The current pressed key.</value>
        public ConsoleKey Key
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the current selected cipher encryption.
        /// </summary>
        /// <value>the current selected encryption.</value>
        public BaseCipher Cipher
        {
            get
            {
                return this.cipher;
            }

            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException($"The {nameof(this.cipher)} must not be null.");
                }

                this.cipher = value;
            }
        }
    }
}
