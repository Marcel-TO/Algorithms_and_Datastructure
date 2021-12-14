//-----------------------------------------------------------------------
// <copyright file="LoggerReplacementInstance.cs" company="FHWN">
//     Copyright (c) Marcel Turobin-Ort. All rights reserved.
// </copyright>
// <author>Marcel Turobin-Ort</author>
// <summary>Defines the logger replacement for testing purpose only.</summary>
//-----------------------------------------------------------------------
namespace Encryption_UnitTests.Replacements
{
    using System.Collections.Generic;
    using Encryption.Interfaces;
    using Encryption.Logic;

    /// <summary>
    /// Represents the console logger replacement for testing purpose.
    /// </summary>
    public class LoggerReplacementInstance : ILogger
    {
        /// <summary>
        /// Represents a method for asking the user for a message.
        /// </summary>
        public void AskUserForMessage()
        {
            return;
        }

        /// <summary>
        /// Represents a method for choosing the next operation.
        /// </summary>
        public void ChooseMethod()
        {
            return;
        }

        /// <summary>
        /// Represents the method for clearing the console.
        /// </summary>
        public void Clear()
        {
            return;
        }

        /// <summary>
        /// Represents the method for waiting for user input to continue.
        /// </summary>
        public void Continue()
        {
            return;
        }

        /// <summary>
        /// Represents the method for sending a message.
        /// </summary>
        /// <param name="message">The current message.</param>
        public void Log(string message)
        {
            return;
        }

        /// <summary>
        /// Represents a method for showing all supported cipher encryptions.
        /// </summary>
        /// <param name="ciphers">The list of all supported cipher encryptions.</param>
        /// <param name="cursorIndex">The index of the current index.</param>
        public void ShowCiphers(List<BaseCipher> ciphers, int cursorIndex)
        {
            return;
        }

        /// <summary>
        /// Represents a method for showing all cursors.
        /// </summary>
        /// <param name="cursorIndex">The current index position.</param>
        /// <param name="cipherLength">The length of all ciphers.</param>
        public void ShowCursor(int cursorIndex, int cipherLength)
        {
            return;
        }
    }
}
