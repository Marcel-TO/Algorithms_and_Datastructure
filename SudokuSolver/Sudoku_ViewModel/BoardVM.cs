//-----------------------------------------------------------------------
// <copyright file="BoardVM.cs" company="FHWN">
//     Copyright (c) Marcel Turobin-Ort. All rights reserved.
// </copyright>
// <author>Marcel Turobin-Ort</author>
// <summary> Defines the view model of a sudoku board.</summary>
//-----------------------------------------------------------------------
namespace Sudoku_ViewModel
{
    using System;
    using System.Collections.Generic;
    using Sudoku_Model;

    /// <summary>
    /// Represents the view model of the current game board.
    /// </summary>
    public class BoardVM
    {
        /// <summary>
        /// Represents the current model of the game board.
        /// </summary>
        private Board board;

        /// <summary>
        /// Represents the list of the current view model field list.
        /// </summary>
        private List<FieldVM> fieldVMs;

        /// <summary>
        /// Initializes a new instance of the <see cref="BoardVM"/> class.
        /// </summary>
        /// <param name="board">The current game board.</param>
        /// <param name="fieldVMs">The current list of the view model field list.</param>
        public BoardVM(Board board, List<FieldVM> fieldVMs)
        {
            this.Board = board;
            this.FieldVMs = fieldVMs;
        }

        /// <summary>
        /// Gets the current model of the game board.
        /// </summary>
        /// <value>The current game board.</value>
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

        /// <summary>
        /// Gets or sets the view model list of the current fields.
        /// </summary>
        /// <value>The list of the current fields.</value>
        public List<FieldVM> FieldVMs
        {
            get
            {
                return this.fieldVMs;
            }

            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException($"The {nameof(value)} must not be null!");
                }

                this.fieldVMs = value;
            }
        }
    }
}
