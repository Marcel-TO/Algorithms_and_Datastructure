//-----------------------------------------------------------------------
// <copyright file="Field.cs" company="FHWN">
//     Copyright (c) Marcel Turobin-Ort. All rights reserved.
// </copyright>
// <author>Marcel Turobin-Ort</author>
// <summary>Defines one field of the snakes and ladders game instance.</summary>
//-----------------------------------------------------------------------
namespace SnakesAndLadders.GameObjects
{
    using System;

    /// <summary>
    /// Represents the field class of the game.
    /// </summary>
    public class Field
    {
        /// <summary>
        /// Represents the pointer to which field the current field is pointing at.
        /// </summary>
        private int pointer;

        /// <summary>
        /// Initializes a new instance of the <see cref="Field"/> class.
        /// </summary>
        /// <param name="index">The current index of the field.</param>
        public Field(int index)
        {
            this.Pointer = index;
            this.IsSpecial = false;
        }

        /// <summary>
        /// Gets or sets the pointer to which field the current field is pointing at.
        /// </summary>
        /// <value>The position of the field which the current field is pointing at.</value>
        public int Pointer
        {
            get
            {
                return this.pointer;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException($"The {nameof(this.pointer)} must not be negative.");
                }

                this.pointer = value;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the current field is defined special.
        /// </summary>
        /// <value>The value indicating whether a field is defined as special.</value>
        public bool IsSpecial
        {
            get;
            set;
        }
    }
}
