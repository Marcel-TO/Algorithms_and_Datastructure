//-----------------------------------------------------------------------
// <copyright file="Position.cs" company="FHWN">
//     Copyright (c) Marcel Turobin-Ort. All rights reserved.
// </copyright>
// <author>Marcel Turobin-Ort</author>
// <summary>Defines the coordinate position of the cursor.</summary>
//-----------------------------------------------------------------------
namespace BefungeInterpreter.Logic
{
    using System;

    /// <summary>
    /// Represents the position of the cursor.
    /// </summary>
    public class Position
    {
        /// <summary>
        /// Represents the x coordinate of the cursor.
        /// </summary>
        private int x;

        /// <summary>
        /// Represents the y coordinate of the cursor.
        /// </summary>
        private int y;

        /// <summary>
        /// Initializes a new instance of the <see cref="Position"/> class.
        /// </summary>
        /// <param name="x">The x coordinate of the cursor.</param>
        /// <param name="y">The y coordinate of the cursor.</param>
        public Position(int x, int y)
        {
            this.X = x;
            this.Y = y; 
        }

        /// <summary>
        /// Gets or sets the x coordinate of the cursor.
        /// </summary>
        /// <value>The x coordinate of the cursor.</value>
        public int X
        {
            get
            {
                return this.x;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException($"The {nameof(this.x)} must not be negative.");
                }

                this.x = value;
            }
        }

        /// <summary>
        /// Gets or sets the y coordinate of the cursor.
        /// </summary>
        /// <value>The y coordinate of the cursor.</value>
        public int Y
        {
            get
            {
                return this.y;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException($"The {nameof(this.y)} must not be negative.");
                }

                this.y = value;
            }
        }
    }
}
