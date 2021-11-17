//-----------------------------------------------------------------------
// <copyright file="Position.cs" company="FHWN">
//     Copyright (c) Marcel Turobin-Ort. All rights reserved.
// </copyright>
// <author>Marcel Turobin-Ort</author>
// <summary>Defines the class for position values.</summary>
//-----------------------------------------------------------------------
namespace SplayTree.Logic
{
    /// <summary>
    /// Represents the position.
    /// </summary>
    public class Position
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Position"/> class.
        /// </summary>
        /// <param name="x">Represents the x-coordinate.</param>
        /// <param name="y">Represents the y-coordinate.</param>
        public Position(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        /// <summary>
        /// Gets the x-coordinate of the current node.
        /// </summary>
        /// <value>The x-coordinate of the current node.</value>
        public int X // Check?
        {
            get;
            set;
        }

        /// <summary>
        /// Gets the y-coordinate of the current node.
        /// </summary>
        /// <value>The y-coordinate of the current node.</value>
        public int Y
        {
            get;
            set;
        }
    }
}
