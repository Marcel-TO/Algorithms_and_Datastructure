//-----------------------------------------------------------------------
// <copyright file="BoardEventArgs.cs" company="FHWN">
//     Copyright (c) Marcel Turobin-Ort. All rights reserved.
// </copyright>
// <author>Marcel Turobin-Ort</author>
// <summary> Defines the event argument of the board event.</summary>
//-----------------------------------------------------------------------
namespace Sudoku_Model.EventArgs
{
    using System;

    /// <summary>
    /// Represents a class for the board event arguments.
    /// </summary>
    public class BoardEventArgs : EventArgs
    {
        /// <summary>
        /// Represents the current board of the sudoku game.
        /// </summary>
        private Board board;

        /// <summary>
        /// Initializes a new instance of the <see cref="BoardEventArgs"/> class.
        /// </summary>
        /// <param name="board">The current board of the sudoku game.</param>
        public BoardEventArgs(Board board)
        {
            this.Board = board;
        }

        /// <summary>
        /// Gets the board of the current sudoku game.
        /// </summary>
        /// <value>The current board of the sudoku game.</value>
        public Board Board
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
