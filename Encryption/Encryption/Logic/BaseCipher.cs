//-----------------------------------------------------------------------
// <copyright file="BaseCipher.cs" company="FHWN">
//     Copyright (c) Marcel Turobin-Ort. All rights reserved.
// </copyright>
// <author>Marcel Turobin-Ort</author>
// <summary>Defines the abstract cipher class for the supported encryptions.</summary>
//-----------------------------------------------------------------------
namespace Encryption.Logic
{
    using System;

    /// <summary>
    /// Represents the abstract base cipher encryption.
    /// </summary>
    public abstract class BaseCipher
    {
        /// <summary>
        /// Represents the name of the current cipher encryption.
        /// </summary>
        private string name;

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseCipher"/> class.
        /// </summary>
        /// <param name="name">The name of the cipher encryption.</param>
        public BaseCipher(string name)
        {
            this.Name = name;
        }

        /// <summary>
        /// Gets the name of the current cipher encryption.
        /// </summary>
        /// <value>The current name of the cipher encryption.</value>
        public string Name
        {
            get
            {
                return this.name;
            }

            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException($"The {nameof(this.name)} must not be null.");
                }

                this.name = value;
            }
        }

        /// <summary>
        /// Represents the abstract encryption method.
        /// </summary>
        /// <param name="message">The current message that gets encrypted.</param>
        /// <returns>The encrypted message.</returns>
        public abstract string Encrypt(string message);

        /// <summary>
        /// Represents the abstract decryption method.
        /// </summary>
        /// <param name="encryptedMessage">The encrypted message that gets decrypted.</param>
        /// <returns>The decrypted message.</returns>
        public abstract string Decrypt(string encryptedMessage);

        /// <summary>
        /// Represents the method for checking if alphabet is valid.
        /// </summary>
        /// <param name="alphabet">The current alphabet.</param>
        /// <returns>True if the alphabet is valid.</returns>
        protected bool CheckIfAlphabetIsValid(string alphabet)
        {
            foreach (char abc in alphabet)
            {
                if (!char.IsLetter(abc))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
