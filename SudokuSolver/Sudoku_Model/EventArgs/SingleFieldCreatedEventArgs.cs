//-----------------------------------------------------------------------
// <copyright file="SingleFieldCreatedEventArgs.cs" company="FHWN">
//     Copyright (c) Marcel Turobin-Ort. All rights reserved.
// </copyright>
// <author>Marcel Turobin-Ort</author>
// <summary> Defines the arguments of an event.</summary>
//-----------------------------------------------------------------------
namespace Sudoku_Model.EventArgs
{
    using System;

    /// <summary>
    /// Represents the arguments of an event.
    /// </summary>
    public class SingleFieldCreatedEventArgs : EventArgs
    {
        /// <summary>
        /// Represents a new created field.
        /// </summary>
        private Field field;

        /// <summary>
        /// Initializes a new instance of the <see cref="SingleFieldCreatedEventArgs"/> class.
        /// </summary>
        /// <param name="field">The new created field.</param>
        public SingleFieldCreatedEventArgs(Field field)
        {
            this.Field = field;
        }

        /// <summary>
        /// Gets the new created field.
        /// </summary>
        /// <value>The new created field.</value>
        public Field Field
        {
            get
            {
                return this.field;
            }

            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException($"The {nameof(value)} mustn ot be null!");
                }

                this.field = value;
            }
        }
    }
}
