//-----------------------------------------------------------------------
// <copyright file="ConsoleLogger.cs" company="FHWN">
//     Copyright (c) Marcel Turobin-Ort. All rights reserved.
// </copyright>
// <author>Marcel Turobin-Ort</author>
// <summary>Defines the console logger of the application.</summary>
//-----------------------------------------------------------------------
namespace Encryption.Logic
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using Encryption.Interfaces;

    /// <summary>
    /// Represents a console logger for the application.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class ConsoleLogger : ILogger
    {
        /// <summary>
        /// Represents the cursor x position offset.
        /// </summary>
        private int cursorOffsetX;

        /// <summary>
        /// Represents the y offset for the cursor.
        /// </summary>
        private int offsetY;

        /// <summary>
        /// Represents the cipher start position.
        /// </summary>
        private int cipherStartX;

        /// <summary>
        /// Initializes a new instance of the <see cref="ConsoleLogger"/> class.
        /// </summary>
        public ConsoleLogger()
        {
            this.cursorOffsetX = 1;
            this.offsetY = 1;
            this.cipherStartX = 4;

            Console.CursorVisible = false;
        }

        /// <summary>
        /// Represents the method for sending a message.
        /// </summary>
        /// <param name="message">The current message.</param>
        public void Log(string message)
        {
            Console.WriteLine(message);
        }

        /// <summary>
        /// Represents a method for showing all supported cipher encryptions.
        /// </summary>
        /// <param name="ciphers">The list of all supported cipher encryptions.</param>
        /// <param name="cursorIndex">The index of the current index.</param>
        public void ShowCiphers(List<BaseCipher> ciphers, int cursorIndex)
        {
            this.Clear();

            int x = this.cipherStartX;
            int y = this.offsetY;

            for (int i = 0; i < ciphers.Count; i++)
            {
                Console.SetCursorPosition(x, y++);
                Console.Write($"{ciphers[i].Name}");
            }
        }

        /// <summary>
        /// Represents a method for showing all cursors.
        /// </summary>
        /// <param name="cursorIndex">The current index position.</param>
        /// <param name="cipherLength">The length of all ciphers.</param>
        public void ShowCursor(int cursorIndex, int cipherLength)
        {
            int x = this.cursorOffsetX;
            int y = this.offsetY + cursorIndex;

            Console.SetCursorPosition(x, y - 1);
            Console.Write("  ");
            Console.SetCursorPosition(x, y);
            Console.Write("->");
            Console.SetCursorPosition(x, y + 1);
            Console.Write("  ");

            if (cursorIndex == 0)
            {
                Console.SetCursorPosition(x, y + cipherLength - 1);
                Console.Write("  ");
            }
            else if (cursorIndex == cipherLength - 1)
            {
                Console.SetCursorPosition(x, this.offsetY);
                Console.Write("  ");
            }
        }

        /// <summary>
        /// Represents a method for choosing the next operation.
        /// </summary>
        public void ChooseMethod()
        {
            this.Clear();

            Console.SetCursorPosition(this.cursorOffsetX, this.offsetY);
            Console.WriteLine("Press [E] to encrypt a message.");
            Console.SetCursorPosition(this.cursorOffsetX, this.offsetY + 1);
            Console.WriteLine("Press [D] to decrypt a message.");
        }

        /// <summary>
        /// Represents a method for asking the user for a message.
        /// </summary>
        public void AskUserForMessage()
        {
            this.Clear();

            Console.SetCursorPosition(0, 0);
            Console.WriteLine("What message do you want to encrypt?");
        }

        /// <summary>
        /// Represents the method for clearing the console.
        /// </summary>
        public void Clear()
        {
            Console.Clear();
        }

        /// <summary>
        /// Represents the method for waiting for user input to continue.
        /// </summary>
        public void Continue()
        {
            Console.WriteLine("Press any key to continue.");
        }
    }
}
