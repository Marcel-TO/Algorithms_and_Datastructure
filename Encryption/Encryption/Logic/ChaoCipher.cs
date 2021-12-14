//-----------------------------------------------------------------------
// <copyright file="ChaoCipher.cs" company="FHWN">
//     Copyright (c) Marcel Turobin-Ort. All rights reserved.
// </copyright>
// <author>Marcel Turobin-Ort</author>
// <summary>Defines the the chaos cipher encryption.</summary>
//-----------------------------------------------------------------------
namespace Encryption.Logic
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Represents the chaos cipher encryption.
    /// </summary>
    public class ChaoCipher : BaseCipher
    {
        /// <summary>
        /// Represents the left alphabet order.
        /// </summary>
        private string leftAlphabet;

        /// <summary>
        /// Represents the right alphabet order.
        /// </summary>
        private string rightAlphabet;

        /// <summary>
        /// Initializes a new instance of the <see cref="ChaoCipher"/> class.
        /// </summary>
        /// <param name="leftABC">The left alphabet order.</param>
        /// <param name="rightABC">The right alphabet order.</param>
        public ChaoCipher(string leftABC, string rightABC) : base("ChaoCipher")
        {
            this.LeftAlphabet = leftABC;
            this.RightAlphabet = rightABC;
        }

        /// <summary>
        /// Gets the left alphabet order.
        /// </summary>
        /// <value>The left alphabet order.</value>
        public string LeftAlphabet
        {
            get
            {
                return this.leftAlphabet;
            }

            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException($"The {nameof(this.leftAlphabet)} must not be null.");
                }
                else if (!this.CheckIfAlphabetIsValid(value))
                {
                    throw new ArgumentException($"The {nameof(this.leftAlphabet)} must only contain latin characters.");
                }
                else if (value.Length != 26)
                {
                    throw new ArgumentOutOfRangeException($"The {nameof(this.leftAlphabet)} must be the length of the alphabet.");
                }

                this.leftAlphabet = value.ToUpper();
            }
        }

        /// <summary>
        /// Gets the right alphabet order.
        /// </summary>
        /// <value>The right alphabet order.</value>
        public string RightAlphabet
        {
            get
            {
                return this.rightAlphabet;
            }

            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException($"The {nameof(this.rightAlphabet)} must not be null.");
                }
                else if (!this.CheckIfAlphabetIsValid(value))
                {
                    throw new ArgumentException($"The {nameof(this.rightAlphabet)} must only contain latin characters.");
                }
                else if (value.Length != 26)
                {
                    throw new ArgumentOutOfRangeException($"The {nameof(this.rightAlphabet)} must be the length of the alphabet.");
                }

                this.rightAlphabet = value.ToUpper();
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
            List<char> encryptedChars = new List<char>();
            string leftABC = this.LeftAlphabet;
            string rightABC = this.RightAlphabet;

            for (int i = 0; i < encryptedMessage.Length; i++)
            {
                for (int j = 0; j < this.LeftAlphabet.Length; j++)
                {
                    if (encryptedMessage[i] == this.RightAlphabet[j])
                    {
                        encryptedChars.Add(this.LeftAlphabet[j]);
                        leftABC = this.PermuteLeftAlphabet(leftABC, j);
                        rightABC = this.PermuteRightAlphabet(rightABC, j);
                    }
                }
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
            List<char> encryptedChars = new List<char>();
            string leftABC = this.LeftAlphabet;
            string rightABC = this.RightAlphabet;

            for (int i = 0; i < message.Length; i++)
            {
                for (int j = 0; j < this.LeftAlphabet.Length; j++)
                {
                    if (message[i] == this.LeftAlphabet[j])
                    {
                        encryptedChars.Add(this.RightAlphabet[j]);
                        rightABC = this.PermuteLeftAlphabet(rightABC, j);
                        leftABC = this.PermuteRightAlphabet(leftABC, j);
                        continue;
                    }
                }
            }

            return new string(encryptedChars.ToArray());
        }

        /// <summary>
        /// Represents a method for permuting the alphabet to the left side.
        /// </summary>
        /// <param name="alphabet">The current alphabet order.</param>
        /// <param name="index">The current index of the used character.</param>
        /// <returns>The new alphabet order.</returns>
        private string PermuteLeftAlphabet(string alphabet, int index)
        {
            List<char> newAlphabet = new List<char>();

            for (int i = 0; i < alphabet.Length; i++)
            {
                if (index > alphabet.Length - 1)
                {
                    index = 0;
                }

                newAlphabet.Add(alphabet[index++]);
            }

            char newNadir = newAlphabet[1];
            newAlphabet.RemoveAt(1);
            newAlphabet.Insert(13, newNadir);

            return new string(newAlphabet.ToArray());
        }

        /// <summary>
        /// Represents a method for permuting the alphabet to the right side.
        /// </summary>
        /// <param name="alphabet">The current alphabet order.</param>
        /// <param name="index">The current index of the used character.</param>
        /// <returns>The new alphabet order.</returns>
        private string PermuteRightAlphabet(string alphabet, int index)
        {
            List<char> newAlphabet = new List<char>();
            index++;

            for (int i = 0; i < alphabet.Length; i++)
            {
                if (index > alphabet.Length - 1)
                {
                    index = 0;
                }

                newAlphabet.Add(alphabet[index++]);
            }

            char newNadir = newAlphabet[2];
            newAlphabet.RemoveAt(2);
            newAlphabet.Insert(13, newNadir);

            return new string(newAlphabet.ToArray());
        }
    }
}
