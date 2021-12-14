//-----------------------------------------------------------------------
// <copyright file="AutokeyCipher.cs" company="FHWN">
//     Copyright (c) Marcel Turobin-Ort. All rights reserved.
// </copyright>
// <author>Marcel Turobin-Ort</author>
// <summary>Defines the the autokey cipher encryption.</summary>
//-----------------------------------------------------------------------
namespace Encryption.Logic
{
    using System;
    using System.Collections.Generic;
    using Encryption.Interfaces;

    /// <summary>
    /// Represents the auto key cipher encryption.
    /// </summary>
    public class AutokeyCipher : BaseCipher
    {
        /// <summary>
        /// Represents the latin alphabet.
        /// </summary>
        private static string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

        /// <summary>
        /// Represents the current primer of the encryption.
        /// </summary>
        private string primer;

        /// <summary>
        /// Initializes a new instance of the <see cref="AutokeyCipher"/> class.
        /// </summary>
        /// <param name="primer">The prime key for the encryption.</param>
        public AutokeyCipher(string primer) : base("Autokey cipher")
        {
            this.Primer = primer;
        }

        /// <summary>
        /// Gets the prime key for the encryption.
        /// </summary>
        /// <value>The prime key for the encryption.</value>
        public string Primer
        {
            get
            {
                return this.primer;
            }

            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException($"The {nameof(this.primer)} must not be null.");
                }

                this.primer = value.ToUpper();
            }
        }

        /// <summary>
        /// Represents the decryption method of the cipher.
        /// </summary>
        /// <param name="encryptedMessage">The encrypted message.</param>
        /// <returns>The non encrypted message.</returns>
        public override string Decrypt(string encryptedMessage)
        {
            if (encryptedMessage == null)
            {
                throw new ArgumentNullException($"The {nameof(encryptedMessage)} must not be null.");
            }

            encryptedMessage = encryptedMessage.ToUpper();
            string keystream = this.Primer;
            List<char> encryptedChars = new List<char>();

            int keystreamIndex = 0;
            int encryptedIndex = 0;

            for (int k = 0; k < encryptedMessage.Length; k++)
            {
                keystreamIndex = this.GetIndex(alphabet, keystream[k]);
                string newAlphabet = this.GetNewAlphabet(alphabet, keystreamIndex);
                encryptedIndex = this.GetIndex(newAlphabet, encryptedMessage[k]);

                // Adds the decrypted character to the keystream.
                keystream += alphabet[encryptedIndex].ToString();

                encryptedChars.Add(alphabet[encryptedIndex]);
            }

            return new string(encryptedChars.ToArray());
        }

        /// <summary>
        /// Represents the encryption method of the cipher.
        /// </summary>
        /// <param name="message">The message that gets encrypted.</param>
        /// <returns>The encrypted message.</returns>
        public override string Encrypt(string message)
        {
            if (message == null)
            {
                throw new ArgumentNullException($"The {nameof(message)} must not be null.");
            }

            message = message.ToUpper();
            string cipherText = this.Primer + message;
            List<char> encryptedChars = new List<char>();

            int cipherIndex = 0;
            int messageIndex = 0;

            // Steps through each character in the message and gets the index from the alphabet.
            for (int m = 0; m < message.Length; m++)
            {
                cipherIndex = this.GetIndex(alphabet, cipherText[m]);
                messageIndex = this.GetIndex(alphabet, message[m]);

                // The index of the character from both indizes combined.
                int index = cipherIndex + messageIndex;

                // Checks if index is out of range.
                if (index >= alphabet.Length)
                {
                    index -= alphabet.Length;
                }

                encryptedChars.Add(alphabet[index]);
            }

            return new string(encryptedChars.ToArray());
        }

        /// <summary>
        /// Represents a method for getting the new alphabet order needed to proceed encryption.
        /// </summary>
        /// <param name="alphabet">The standard alphabet.</param>
        /// <param name="index">The index of the first encrypted letter.</param>
        /// <returns>The new alphabet order.</returns>
        private string GetNewAlphabet(string alphabet, int index)
        {
            List<char> newAlphabet = new List<char>();

            ////  Starts at the position of the used character.
            for (int i = 0; i < alphabet.Length; i++)
            {
                ////Checks if the index is out of range and sets it to the start.
                if (index > alphabet.Length - 1)
                {
                    index = 0;
                }

                newAlphabet.Add(alphabet[index++]);
            }

            return new string(newAlphabet.ToArray());
        }

        /// <summary>
        /// Represents a method for getting the index of the current character in the alphabet.
        /// </summary>
        /// <param name="alphabet">The current alphabet.</param>
        /// <param name="character">The current selected character.</param>
        /// <returns>The index of the current selected character.</returns>
        private int GetIndex(string alphabet, char character)
        {
            for (int i = 0; i < alphabet.Length; i++)
            {
                // Checks if ciphertext or message contains the current character from the alphabet.
                if (character == alphabet[i])
                {
                    return i;
                }
            }

            return 0;
        }
    }
}
