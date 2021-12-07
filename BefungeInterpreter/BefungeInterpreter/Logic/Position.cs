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
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the y coordinate of the cursor.
        /// </summary>
        /// <value>The y coordinate of the cursor.</value>
        public int Y
        {
            get;
            set;
        }

        public Position ValidatePosition(Position position, string[] content)
        {
            if (content == null)
            {
                throw new ArgumentNullException($"The {nameof(content)} must not be null.");
            }
            else if (position.Y < 0)
            {
                position.Y = content.Length - 1;
            }
            else if (position.Y > content.Length - 1)
            {
                position.Y = 0;
            }
            else if (position.X < 0)
            {
                position.X = content[position.Y].Length - 1;
            }
            else if (position.X > content[position.Y].Length - 1)
            {
                position.X = 0;
            }

            return position;
        }
    }
}
