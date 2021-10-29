//-----------------------------------------------------------------------
// <copyright file="UnsolvableEventArgs.cs" company="FHWN">
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
    public class UnsolvableEventArgs : EventArgs
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UnsolvableEventArgs"/> class.
        /// </summary>
        /// <param name="isSolveable">Defines if the sudoku board is possible.</param>
        public UnsolvableEventArgs(bool isSolveable)
        {
            this.IsSolveable = isSolveable;
        }

        /// <summary>
        /// Gets or sets a value indicating whether the sudoku board is possible.
        /// </summary>
        /// <value>The value indicating whether the sudoku board is possible.</value>
        public bool IsSolveable
        {
            get;
            set;
        }
    }
}
