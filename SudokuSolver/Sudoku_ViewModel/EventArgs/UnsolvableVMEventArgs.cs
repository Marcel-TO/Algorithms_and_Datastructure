//-----------------------------------------------------------------------
// <copyright file="UnsolvableVMEventArgs.cs" company="FHWN">
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
    public class UnsolvableVMEventArgs : EventArgs
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UnsolvableVMEventArgs"/> class.
        /// </summary>
        /// <param name="isSolveable">True if the level is solvable, otherwise false.</param>
        public UnsolvableVMEventArgs(bool isSolveable)
        {
            this.IsSolveable = isSolveable;
        }

        /// <summary>
        /// Gets a value indicating whether the level is solvable, otherwise false.
        /// </summary>
        /// <value>True if the level is solvable.</value>
        public bool IsSolveable
        {
            get;
            private set;
        }
    }
}
