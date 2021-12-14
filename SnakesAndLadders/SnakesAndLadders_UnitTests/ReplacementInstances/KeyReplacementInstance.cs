//-----------------------------------------------------------------------
// <copyright file="KeyReplacementInstance.cs" company="FHWN">
//     Copyright (c) Marcel Turobin-Ort. All rights reserved.
// </copyright>
// <author>Marcel Turobin-Ort</author>
// <summary>Defines the keyboard watcher replacement for testing purpose only.</summary>
//-----------------------------------------------------------------------
namespace SnakesAndLadders_UnitTests.ReplacementInstances
{
    using System;
    using SnakesAndLadders.Interfaces;

    /// <summary>
    /// Represents the keyboard watcher for testing purpose.
    /// </summary>
    public class KeyReplacementInstance : IKeyboardWatcher
    {
        /// <summary>
        /// Represents the keyboard watcher instance that continues the application.
        /// </summary>
        /// <returns>An empty console key information.</returns>
        public ConsoleKeyInfo Continue()
        {
            return new ConsoleKeyInfo();
        }

        /// <summary>
        /// Represents the keyboard watcher and returns the default information.
        /// </summary>
        /// <returns>The default instance.</returns>
        public string ReadLine()
        {
            return string.Empty;
        }

        /// <summary>
        /// Represents the method for exiting the application.
        /// </summary>
        /// <returns>True for the application to exit.</returns>
        public bool Exit()
        {
            return true;
        }
    }
}
