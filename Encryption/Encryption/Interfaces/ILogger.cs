//-----------------------------------------------------------------------
// <copyright file="ILogger.cs" company="FHWN">
//     Copyright (c) Marcel Turobin-Ort. All rights reserved.
// </copyright>
// <author>Marcel Turobin-Ort</author>
// <summary>Defines the interface for logging the application.</summary>
//-----------------------------------------------------------------------
namespace Encryption.Interfaces
{
    using System.Collections.Generic;
    using Encryption.Logic;

    /// <summary>
    /// Represents the logging interface.
    /// </summary>
    public interface ILogger
    {
        /// <summary>
        /// Represents the method for sending a message.
        /// </summary>
        /// <param name="message">The current message.</param>
        void Log(string message);

        /// <summary>
        /// Represents a method for showing all supported cipher encryptions.
        /// </summary>
        /// <param name="ciphers">The list of all supported cipher encryptions.</param>
        /// <param name="cursorIndex">The index of the current index.</param>
        void ShowCiphers(List<BaseCipher> ciphers, int cursorIndex);

        /// <summary>
        /// Represents a method for showing all cursors.
        /// </summary>
        /// <param name="cursorIndex">The current index position.</param>
        /// <param name="cipherLength">The length of all ciphers.</param>
        void ShowCursor(int cursorIndex, int cipherLength);

        /// <summary>
        /// Represents a method for choosing the next operation.
        /// </summary>
        void ChooseMethod();

        /// <summary>
        /// Represents a method for asking the user for a message.
        /// </summary>
        void AskUserForMessage();

        /// <summary>
        /// Represents the method for clearing the console.
        /// </summary>
        void Clear();

        /// <summary>
        /// Represents the method for waiting for user input to continue.
        /// </summary>
        void Continue();
    }
}
