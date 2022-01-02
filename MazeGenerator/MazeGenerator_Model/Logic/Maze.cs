//-----------------------------------------------------------------------
// <copyright file="Maze.cs" company="FHWN">
//     Copyright (c) Marcel Turobin-Ort. All rights reserved.
// </copyright>
// <author>Marcel Turobin-Ort</author>
// <summary>Defines maze of the application.</summary>
//-----------------------------------------------------------------------
namespace MazeGenerator_Model.Logic
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Represents the maze class.
    /// </summary>
    public class Maze
    {
        /// <summary>
        /// Represents the size of the maze.
        /// </summary>
        private int size;

        /// <summary>
        /// Represents the list of all hexagons of the maze.
        /// </summary>
        private List<Hexagon> hexagons;

        /// <summary>
        /// Initializes a new instance of the <see cref="Maze"/> class.
        /// </summary>
        /// <param name="hexagons">The list of all hexagons.</param>
        /// <param name="size">The size of the maze.</param>
        public Maze(List<Hexagon> hexagons, int size)
        {
            this.Hexagons = hexagons;
            this.Size = size;
        }

        /// <summary>
        /// Gets the size of the maze.
        /// </summary>
        /// <value>The size of the maze.</value>
        public int Size
        {
            get
            {
                return this.size;
            }

            private set
            {
                if (value < 1)
                {
                    throw new ArgumentOutOfRangeException($"The {nameof(this.size)} must not be null.");
                }

                this.size = value;
            }
        }

        /// <summary>
        /// Gets the list of all hexagons.
        /// </summary>
        /// <value>The list of all hexagons.</value>
        public List<Hexagon> Hexagons
        {
            get
            {
                return this.hexagons;
            }

            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException($"The {nameof(this.hexagons)} must not be null.");
                }

                this.hexagons = value;
            }
        }
    }
}
