//-----------------------------------------------------------------------
// <copyright file="BoardVMEventArgs.cs" company="FHWN">
//     Copyright (c) Marcel Turobin-Ort. All rights reserved.
// </copyright>
// <author>Marcel Turobin-Ort</author>
// <summary> Defines the event argument of the board view model event.</summary>
//-----------------------------------------------------------------------
namespace Sudoku_ViewModel.EventArgs
{
    using System;

    /// <summary>
    /// Represents the class for the board view model event args.
    /// </summary>
    public class BoardVMEventArgs : EventArgs
    {
        /// <summary>
        /// Represents the current view model of the game board.
        /// </summary>
        private BoardVM board;

        /// <summary>
        /// Initializes a new instance of the <see cref="BoardVMEventArgs"/> class.
        /// </summary>
        /// <param name="board">The current view model of the game board.</param>
        public BoardVMEventArgs(BoardVM board)
        {
            this.Board = board;
        }

        /// <summary>
        /// Gets the current view model of the game board.
        /// </summary>
        /// <value>The game board view model.</value>
        public BoardVM Board
        {
            get
            {
                return this.board;
            }

            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException($"The {nameof(value)} must not be null!");
                }

                this.board = value;
            }
        }
    }
}
