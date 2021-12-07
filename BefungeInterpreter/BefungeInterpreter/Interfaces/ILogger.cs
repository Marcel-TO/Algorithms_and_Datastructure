//-----------------------------------------------------------------------
// <copyright file="ILogger.cs" company="FHWN">
//     Copyright (c) Marcel Turobin-Ort. All rights reserved.
// </copyright>
// <author>Marcel Turobin-Ort</author>
// <summary>Defines the interface for logging the application.</summary>
//-----------------------------------------------------------------------
namespace BefungeInterpreter.Interfaces
{
    using System.Collections.Generic;
    using BefungeInterpreter.Logic;

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
        /// Represents the method for displaying the cursor position.
        /// </summary>
        /// <param name="yPosition">The y position of the cursor.</param>
        /// <param name="lengthOfBefungePrograms">The amount of programs.</param>
        void ShowCursor(int yPosition, int lengthOfBefungePrograms);

        /// <summary>
        /// Represents the method for showing all possible <see cref="BefungeProgram"/>.
        /// </summary>
        /// <param name="befungeProgramPaths">The paths of all programs.</param>    
        void ShowBefungePrograms(string[] befungeProgramPaths);

        /// <summary>
        /// Represents the method for showing the content of the current <see cref="BefungeProgram"/>.
        /// </summary>
        /// <param name="content">The current content of the program.</param>
        /// <param name="position">The current cursor position.</param>
        /// <param name="values">The current values of the stack.</param>
        /// <param name="output">The current output of the program.</param>
        void ShowProgramContent(string[] content, Position position, List<int> values, List<string> output);

        /// <summary>
        /// Represents the method for updating the cursor position, the stack values and the output.
        /// </summary>
        /// <param name="program">The current program.</param>
        /// <param name="values">The current values of the stack.</param>
        /// <param name="output">The current output of the stack.</param>
        void UpdateContent(BefungeProgram program, List<int> values, List<string> output);

        /// <summary>
        /// Represents the method for clearing the console.
        /// </summary>
        void Clear();

        /// <summary>
        /// Represents the method for waiting for user input to continue.
        /// </summary>
        void Continue();

        /// <summary>
        /// Represents the method for indicating that the interpreter is finished.
        /// </summary>
        void Finished();

        /// <summary>
        /// Represents the method for getting a character from the user.
        /// </summary>
        /// <returns>The character from the user input.</returns>
        char GetUserCharInput();

        /// <summary>
        /// Represents the method for getting a integer value from the user.
        /// </summary>
        /// <returns>The integer from the user input.</returns>
        int GetUserIntInput();
    }
}
