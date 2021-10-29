//-----------------------------------------------------------------------
// <copyright file="BacktrackingSolver.cs" company="FHWN">
//     Copyright (c) Marcel Turobin-Ort. All rights reserved.
// </copyright>
// <author>Marcel Turobin-Ort</author>
// <summary> Defines the backtracking algorithm which is used for solving the sudoku level.</summary>
//-----------------------------------------------------------------------
namespace Sudoku_Model
{
    using System;
    using System.Collections.Generic;
    using Sudoku_Model.EventArgs;

    /// <summary>
    /// Represents the backtracking solver algorithm.
    /// </summary>
    public class BacktrackingSolver
    {
        /// <summary>
        /// Represents the current fields of the sudoku board.
        /// </summary>
        private List<Field> fields;

        /// <summary>
        /// Represents the direction of the algorithm.
        /// </summary>
        private bool isForward;

        /// <summary>
        /// Initializes a new instance of the <see cref="BacktrackingSolver"/> class.
        /// </summary>
        /// <param name="fields">The current list of the sudoku board.</param>
        public BacktrackingSolver(List<Field> fields)
        {
            this.Fields = fields;
        }

        /// <summary>
        /// Occurs if the board is unsolvable.
        /// </summary>
        public event EventHandler<UnsolvableEventArgs> Unsolvable;

        /// <summary>
        /// Gets or sets the current list of the fields from the board.
        /// </summary>
        /// <value>The current list of all fields from the board.</value>
        public List<Field> Fields
        {
            get
            {
                return this.fields;
            }

            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException($"The name of {nameof(value)} must not be null!");
                }

                this.fields = value;
            }
        }

        /// <summary>
        /// Represents the start of the solving algorithm.
        /// </summary>
        /// <returns>The list of field models.</returns>
        public List<Field> InitializeSolvingSequence()
        {
            if (this.Fields == null)
            {
                throw new ArgumentNullException($"The {nameof(this.Fields)} must not be null!");
            }

            // Sets the start direction for the algorithm.
            this.isForward = true;

            this.ResetFields();

            for (int i = 0; i < this.Fields.Count; i++)
            {
                if (i < 0)
                {
                    this.Unsolvable?.Invoke(this, new UnsolvableEventArgs(false));
                    return this.Fields;
                }

                if (this.Fields[i].IsAccessable)
                {
                    this.IncreaseNumber(i);
                }

                // if direction is going backwards sets the index of the loop 2 steps back, because if going on, the loop will increase by 1.
                if (!this.isForward)
                {
                    i -= 2;
                }
            }

            return this.Fields;
        }

        /// <summary>
        /// Represents a method which checks if a number is possible.
        /// </summary>
        /// <param name="fields">The current list of fields.</param>
        /// <param name="index">The index of the current selected field.</param>
        /// <returns>True if the number is possible, otherwise false.</returns>
        public bool CheckIfNumberIsPossible(List<Field> fields, int index)
        {
            for (int i = 0; i < fields.Count; i++)
            {
                if (i != index && fields[i].Number != 0)
                {
                    if (fields[i].Column == fields[index].Column && fields[i].Number == fields[index].Number)
                    {
                        return false;
                    }

                    if (fields[i].Row == fields[index].Row && fields[i].Number == fields[index].Number)
                    {
                        return false;
                    }

                    if (fields[i].Block == fields[index].Block && fields[i].Number == fields[index].Number)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        /// <summary>
        /// Represents the number reset of the current sudoku board.
        /// </summary>
        private void ResetFields()
        {
            for (int i = 0; i < this.Fields.Count; i++)
            {
                if (this.Fields[i].IsAccessable)
                {
                    this.Fields[i].Number = 0;
                }
            }
        }

        /// <summary>
        /// Represents a method for increasing the number of a field.
        /// </summary>
        /// <param name="index">The index of the current field.</param>
        private void IncreaseNumber(int index)
        {
            if (this.Fields[index].Number + 1 > 9)
            {
                this.isForward = false;
                this.Fields[index].Number = 0;
                return;
            }

            this.Fields[index].Number++;

            if (!this.CheckIfNumberIsPossible(this.Fields, index))
            {
                this.IncreaseNumber(index);
            }
            else
            {
                this.isForward = true;
            }
        }
    }
}
