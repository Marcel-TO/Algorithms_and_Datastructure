//-----------------------------------------------------------------------
// <copyright file="Board.cs" company="FHWN">
//     Copyright (c) Marcel Turobin-Ort. All rights reserved.
// </copyright>
// <author>Marcel Turobin-Ort</author>
// <summary> Defines the class of a sudoku board.</summary>
//-----------------------------------------------------------------------
namespace Sudoku_Model
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Represents the board of the sudoku game.
    /// </summary>
    public class Board
    {
        /// <summary>
        /// Represents the list of fields from the board.
        /// </summary>
        private List<Field> fields;

        /// <summary>
        /// Initializes a new instance of the <see cref="Board"/> class.
        /// </summary>
        /// <param name="fields">The list of fields from the game.</param>
        public Board(List<Field> fields)
        {
            this.Fields = fields;
        }

        /// <summary>
        /// Gets the list of fields from the game board.
        /// </summary>
        /// <value>The list of fields.</value>
        public List<Field> Fields
        {
            get
            {
                return this.fields;
            }

            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException($"The {nameof(value)} must not be null!");
                }

                this.fields = value;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the board is solvable or not.
        /// </summary>
        /// <value>True if the board is solvable, otherwise false.</value>
        public bool IsSolvable
        {
            get;
            set;
        }
    }
}
