//-----------------------------------------------------------------------
// <copyright file="FieldListEventArgs.cs" company="FHWN">
//     Copyright (c) Marcel Turobin-Ort. All rights reserved.
// </copyright>
// <author>Marcel Turobin-Ort</author>
// <summary> Defines the event arguments of an event.</summary>
//-----------------------------------------------------------------------
namespace Sudoku_Model.EventArgs
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Represents the event arguments of an event.
    /// </summary>
    public class FieldListEventArgs : EventArgs
    {
        /// <summary>
        /// Represents the current list of all fields.
        /// </summary>
        private List<Field> fields;

        /// <summary>
        /// Initializes a new instance of the <see cref="FieldListEventArgs"/> class.
        /// </summary>
        /// <param name="fields">The current list of all fields.</param>
        public FieldListEventArgs(List<Field> fields)
        {
            this.fields = fields;
        }

        /// <summary>
        /// Gets the current list of fields from the sudoku board.
        /// </summary>
        /// <value>The current list of fields.</value>
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
    }
}
