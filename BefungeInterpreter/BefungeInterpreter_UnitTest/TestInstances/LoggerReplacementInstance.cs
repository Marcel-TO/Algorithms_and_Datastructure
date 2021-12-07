//-----------------------------------------------------------------------
// <copyright file="LoggerReplacementInstance.cs" company="FHWN">
//     Copyright (c) Marcel Turobin-Ort. All rights reserved.
// </copyright>
// <author>Marcel Turobin-Ort</author>
// <summary>Defines the console logger replacement for testing purpose only.</summary>
//-----------------------------------------------------------------------
namespace BefungeInterpreter_UnitTests.TestInstances
{
    using System;
    using System.Collections.Generic;
    using BefungeInterpreter.Interfaces;
    using BefungeInterpreter.Logic;

    /// <summary>
    /// Represents the console logger replacement for testing purpose.
    /// </summary>
    public class LoggerReplacementInstance : ILogger
    {
        /// <summary>
        /// Represents the method for sending a message.
        /// </summary>
        /// <param name="message">The current message.</param>
        public void Log(string message)
        {
            return;
        }

        /// <summary>
        /// Represents the method for showing all possible <see cref="BefungeProgram"/>.
        /// </summary>
        /// <param name="befungeProgramPaths">The paths of all programs.</param>
        public void ShowBefungePrograms(string[] befungeProgramPaths)
        {
            return;
        }

        /// <summary>
        /// Represents the method for displaying the cursor position.
        /// </summary>
        /// <param name="yPosition">The y position of the cursor.</param>
        /// <param name="lengthOfBefungePrograms">The amount of programs.</param>
        public void ShowCursor(int yPosition, int lengthOfBefungePrograms)
        {
            return;
        }

        /// <summary>
        /// Represents the method for showing the content of the current <see cref="BefungeProgram"/>.
        /// </summary>
        /// <param name="content">The current content of the program.</param>
        /// <param name="position">The current cursor position.</param>
        /// <param name="values">The current values of the stack.</param>
        /// <param name="output">The current output of the program.</param>
        public void ShowProgramContent(string[] content, Position position, List<int> values, List<int> output)
        {
            return;
        }

        /// <summary>
        /// Represents the method for indicating that the interpreter is finished.
        /// </summary>
        public void Finished()
        {
            return;
        }

        /// <summary>
        /// Represents the method for updating the cursor position, the stack values and the output.
        /// </summary>
        /// <param name="program">The current program.</param>
        /// <param name="stackValues">The current values of the stack.</param>
        /// <param name="output">The current output of the stack.</param>
        public void UpdateContent(BefungeProgram program, List<int> stackValues, List<string> output)
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
        /// Represents the method for showing the content of the current <see cref="BefungeProgram"/>.
        /// </summary>
        /// <param name="content">The current content of the program.</param>
        /// <param name="position">The current cursor position.</param>
        /// <param name="values">The current values of the stack.</param>
        /// <param name="output">The current output of the program.</param>
        public void ShowProgramContent(string[] content, Position position, List<int> values, List<string> output)
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
        /// Represents the method for getting a character from the user.
        /// </summary>
        /// <returns>The character from the user input.</returns>
        public char GetUserCharInput()
        {
            return 'h';
        }

        /// <summary>
        /// Represents the method for getting a integer value from the user.
        /// </summary>
        /// <returns>The integer from the user input.</returns>
        public int GetUserIntInput()
        {
            return 5;
        }
    }
}