//-----------------------------------------------------------------------
// <copyright file="Field.cs" company="FHWN">
//     Copyright (c) Marcel Turobin-Ort. All rights reserved.
// </copyright>
// <author>Marcel Turobin-Ort</author>
// <summary> Defines the class of a single Field from the sudoku board.</summary>
//-----------------------------------------------------------------------
namespace Sudoku_Model
{
    using System;

    /// <summary>
    /// Represents a single field of the sudoku board.
    /// </summary>
    public class Field
    {
        /// <summary>
        /// Represents the value of the field.
        /// </summary>
        private int number;

        /// <summary>
        /// Represents the current box of the sudoku board.
        /// </summary>
        private int block;

        /// <summary>
        /// Represents its row of the sudoku board.
        /// </summary>
        private int row;

        /// <summary>
        /// Represents its column of the sudoku board.
        /// </summary>
        private int column;

        /// <summary>
        /// Initializes a new instance of the <see cref="Field"/> class.
        /// </summary>
        /// <param name="number">The current value.</param>
        /// <param name="isAccessable">The value if the field is accessible for the user.</param>
        /// <param name="block">The current box.</param>
        /// <param name="row">The current row.</param>
        /// <param name="column">The current column.</param>
        public Field(int number, bool isAccessable, int block, int row, int column)
        {
            this.Number = number;
            this.IsAccessable = isAccessable;
            this.Block = block;
            this.Row = row;
            this.Column = column;
        }

        /// <summary>
        /// Gets or sets the value of the field.
        /// </summary>
        /// <value>The value of the field.</value>
        public int Number
        {
            get
            {
                return this.number;
            }

            set
            {
                if (value < 0 || value > 9)
                {
                    throw new ArgumentOutOfRangeException($"The number of the field must not be above the required amount.");
                }

                this.number = value;
            }
        }

        /// <summary>
        /// Gets a value indicating whether the user can interact with the field.
        /// </summary>
        /// <value>A value indicating whether the user can interact with the field.</value>
        public bool IsAccessable
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the current block position of the sudoku board.
        /// </summary>
        /// <value>The current block of the sudoku board.</value>
        public int Block
        {
            get
            {
                return this.block;
            }

            private set
            {
                if (value < 1 && value > 9)
                {
                    throw new ArgumentOutOfRangeException($"The {nameof(value)} must be between 1 and 9!");
                }

                this.block = value;
            }
        }

        /// <summary>
        /// Gets the current row of the field.
        /// </summary>
        /// <value>The current row of the field.</value>
        public int Row
        {
            get
            {
                return this.row;
            }

            private set
            {
                if (value < 1 && value > 9)
                {
                    throw new ArgumentOutOfRangeException($"The {nameof(value)} must be between 1 and 9!");
                }

                this.row = value;
            }
        }

        /// <summary>
        /// Gets the current column of the field.
        /// </summary>
        /// <value>The current column of the field.</value>
        public int Column
        {
            get
            {
                return this.column;
            }

            private set
            {
                if (value < 1 && value > 9)
                {
                    throw new ArgumentOutOfRangeException($"The {nameof(value)} must be between 1 and 9!");
                }

                this.column = value;
            }
        }
    }
}
