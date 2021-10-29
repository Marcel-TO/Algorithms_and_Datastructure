//-----------------------------------------------------------------------
// <copyright file="FieldVMListEventArgs.cs" company="FHWN">
//     Copyright (c) Marcel Turobin-Ort. All rights reserved.
// </copyright>
// <author>Marcel Turobin-Ort</author>
// <summary> Defines the view model arguments of the respective event.</summary>
//-----------------------------------------------------------------------
namespace Sudoku_ViewModel.EventArgs
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Represents the event arguments containing the view model field list.
    /// </summary>
    public class FieldVMListEventArgs : EventArgs
    {
        /// <summary>
        /// Represents the view model field list.
        /// </summary>
        private List<FieldVM> fields;

        /// <summary>
        /// Initializes a new instance of the <see cref="FieldVMListEventArgs"/> class.
        /// </summary>
        /// <param name="fields">The view model field list.</param>
        public FieldVMListEventArgs(List<FieldVM> fields)
        {
            this.Fields = fields;
        }

        /// <summary>
        /// Gets the view model field list of the current level.
        /// </summary>
        /// <value>The current view model field list.</value>
        public List<FieldVM> Fields
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
