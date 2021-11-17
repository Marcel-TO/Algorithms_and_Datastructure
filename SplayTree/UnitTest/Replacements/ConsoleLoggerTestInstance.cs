//-----------------------------------------------------------------------
// <copyright file="ConsoleLoggerTestInstance.cs" company="FHWN">
//     Copyright (c) Marcel Turobin-Ort. All rights reserved.
// </copyright>
// <author>Marcel Turobin-Ort</author>
// <summary>Defines the console logger replacement for testing purpose only.</summary>
//-----------------------------------------------------------------------
namespace UnitTest.Replacements
{
    using SplayTree.Commands;
    using SplayTree.Interfaces;

    /// <summary>
    /// Represents the console logger replacement for testing purpose.
    /// </summary>
    public class ConsoleLoggerTestInstance : ILogger
    {
        /// <summary>
        /// Represents the method for getting value from user to choose the traversal order of the tree.
        /// </summary>
        /// <returns>The chosen traversal order.</returns>
        public int ChooseTraverseOrder()
        {
            return 1;
        }

        /// <summary>
        /// Represents the method for clearing the console.
        /// </summary>
        public void Clear()
        {
            return;
        }

        /// <summary>
        /// Represents the method for awaiting user input to continue.
        /// </summary>
        public void Continue()
        {
            return;
        }

        /// <summary>
        /// Represents the method for getting a value from user.
        /// </summary>
        /// <returns>The value chosen by user.</returns>
        public int GetValueFromUser()
        {
            return 3;
        }

        /// <summary>
        /// Represents the method for logging a message.
        /// </summary>
        /// <param name="message">Represents the message for the user.</param>
        public void Message(string message)
        {
            return;
        }

        /// <summary>
        /// Represents the showcase of all supported commands.
        /// </summary>
        /// <param name="commands">Represents the list of all supported commands.</param>
        public void ShowCommands(BaseCommand[] commands)
        {
            return;
        }

        /// <summary>
        /// Represents the visualization of the cursor.
        /// </summary>
        /// <param name="index">Represents the index of the commands list.</param>
        /// <param name="lengthOfCommandList">Represents the amount of the supported commands.</param>
        public void ShowCursor(int index, int lengthOfCommandList)
        {
            return;
        }

        /// <summary>
        /// Represents the visitor pattern of the insert command.
        /// </summary>
        /// <param name="command">Represents the insert command of the splay tree.</param>
        public void Visit(InsertCommand command)
        {
            return;
        }

        /// <summary>
        /// Represents the visitor pattern of the remove command.
        /// </summary>
        /// <param name="command">Represents the remove command of the splay tree.</param>
        public void Visit(RemoveCommand command)
        {
            return;
        }

        /// <summary>
        /// Represents the visitor pattern of the clear command.
        /// </summary>
        /// <param name="command">Represents the clear command of the splay tree.</param>
        public void Visit(ClearCommand command)
        {
            return;
        }

        /// <summary>
        /// Represents the visitor pattern of the count command.
        /// </summary>
        /// <param name="command">Represents the count command of the splay tree.</param>
        public void Visit(CountCommand command)
        {
            return;
        }

        /// <summary>
        /// Represents the visitor pattern of the count specific command.
        /// </summary>
        /// <param name="command">Represents the count specific command of the splay tree.</param>
        public void Visit(CountSpecificCommand command)
        {
            return;
        }

        /// <summary>
        /// Represents the visitor pattern of the minimum command.
        /// </summary>
        /// <param name="command">Represents the minimum command of the splay tree.</param>
        public void Visit(MinCommand command)
        {
            return;
        }

        /// <summary>
        /// Represents the visitor pattern of the maximum command.
        /// </summary>
        /// <param name="command">Represents the maximum command of the splay tree.</param>
        public void Visit(MaxCommand command)
        {
            return;
        }

        /// <summary>
        /// Represents the visitor pattern of the contains command.
        /// </summary>
        /// <param name="command">Represents the contains command of the splay tree.</param>
        public void Visit(ContainsCommand command)
        {
            return;
        }

        /// <summary>
        /// Represents the visitor pattern of the traverse command.
        /// </summary>
        /// <param name="command">Represents the traverse command of the splay tree.</param>
        public void Visit(TraverseCommand command)
        {
            return;
        }

        /// <summary>
        /// Represents the visitor pattern of the display command.
        /// </summary>
        /// <param name="command">Represents the display command of the splay tree.</param>
        public void Visit(DisplayCommand command)
        {
            return;
        }

        /// <summary>
        /// Represents the welcome logging.
        /// </summary>
        public void WelcomeMessage()
        {
            return;
        }
    }
}
