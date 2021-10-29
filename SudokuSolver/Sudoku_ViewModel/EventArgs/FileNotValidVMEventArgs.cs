//-----------------------------------------------------------------------
// <copyright file="FileNotValidVMEventArgs.cs" company="FHWN">
//     Copyright (c) Marcel Turobin-Ort. All rights reserved.
// </copyright>
// <author>Marcel Turobin-Ort</author>
// <summary> Defines the event argument of the respective event if the level is unsolveable.</summary>
//-----------------------------------------------------------------------
namespace Sudoku_ViewModel.EventArgs
{
    using System;

    /// <summary>
    /// Represents the event arguments if the current level is not solvable.
    /// </summary>
    public class FileNotValidVMEventArgs : EventArgs
    {
        /// <summary>
        /// Represents the new empty game board.
        /// </summary>
        private BoardVM board;

        /// <summary>
        /// Initializes a new instance of the <see cref="FileNotValidVMEventArgs"/> class.
        /// </summary>
        /// <param name="isFileNotValid">True if the level is not valid, otherwise false.</param>
        /// <param name="board">The empty board for reset.</param>
        public FileNotValidVMEventArgs(bool isFileNotValid, BoardVM board)
        {
            this.IsFileNotValid = isFileNotValid;
            this.Board = board;
        }

        /// <summary>
        /// Gets a value indicating whether the level is solvable, otherwise false.
        /// </summary>
        /// <value>True if the level is solvable.</value>
        public bool IsFileNotValid
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the new empty game board.
        /// </summary>
        /// <value>The new empty game board.</value>
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
