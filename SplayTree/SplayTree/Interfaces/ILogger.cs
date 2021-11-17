//-----------------------------------------------------------------------
// <copyright file="ILogger.cs" company="FHWN">
//     Copyright (c) Marcel Turobin-Ort. All rights reserved.
// </copyright>
// <author>Marcel Turobin-Ort</author>
// <summary>Defines the interface for logging.</summary>
//-----------------------------------------------------------------------
namespace SplayTree.Interfaces
{
    using SplayTree.Commands;

    /// <summary>
    /// Represents the logging interface.
    /// </summary>
    public interface ILogger : ICommandVisitor 
    {
        /// <summary>
        /// Represents the welcome message of the application.
        /// </summary>
        void WelcomeMessage();

        /// <summary>
        /// Represents the method for showing all supported commands.
        /// </summary>
        /// <param name="commands">Represents the list of all supported commands.</param>
        void ShowCommands(BaseCommand[] commands);

        /// <summary>
        /// Represents the method for showing the position of the current cursor.
        /// </summary>
        /// <param name="index">Represents the current index of the command list.</param>
        /// <param name="lengthOfCommandList">Represents the length of the command list.</param>
        void ShowCursor(int index, int lengthOfCommandList);

        /// <summary>
        /// Represents the method for sending message.
        /// </summary>
        /// <param name="message">Represents the current message.</param>
        void Message(string message);

        /// <summary>
        /// Represents the method for waiting for user input to continue.
        /// </summary>
        void Continue();

        /// <summary>
        /// Represents the method for clearing the logger.
        /// </summary>
        void Clear();

        /// <summary>
        /// Represents the method for getting the value from user.
        /// </summary>
        int GetValueFromUser();

        /// <summary>
        /// Represents the method for getting the value of traversal from user.
        /// </summary>
        int ChooseTraverseOrder();
    }
}
