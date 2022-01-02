//-----------------------------------------------------------------------
// <copyright file="Hexagon.cs" company="FHWN">
//     Copyright (c) Marcel Turobin-Ort. All rights reserved.
// </copyright>
// <author>Marcel Turobin-Ort</author>
// <summary>Defines the a single Hexagon of the maze.</summary>
//-----------------------------------------------------------------------
namespace MazeGenerator_Model.Logic
{
    using System;

    /// <summary>
    /// Represents the hexagon class.
    /// </summary>
    public class Hexagon
    {
        /// <summary>
        /// Represents the q position of the axial coordinates.
        /// </summary>
        private int q;

        /// <summary>
        /// Represents the r position of the axial coordinate.
        /// </summary>
        private int r;

        /// <summary>
        /// Represents the s position of the axial coordinate.
        /// </summary>
        private int s;

        /// <summary>
        /// Represents the values for the open borders.
        /// </summary>
        private bool[] isOpen;

        /// <summary>
        /// Represents the direction of the hexagon.
        /// </summary>
        private int direction;

        /// <summary>
        /// Initializes a new instance of the <see cref="Hexagon"/> class.
        /// </summary>
        /// <param name="q">The q position of the axial coordinate.</param>
        /// <param name="r">The r position of the axial coordinate.</param>
        /// <param name="s">The s position of the axial coordinate.</param>
        public Hexagon(int q, int r, int s)
        {
            this.Q = q;
            this.R = r;
            this.S = s;
            this.Direction = 0;
            this.IsChosen = false;

            this.IsOpen = new bool[]
            {
                false,
                false,
                false,
                false,
                false,
                false
            };
        }

        /// <summary>
        /// Gets the Q position of the axial coordinate.
        /// </summary>
        /// <value>The Q position.</value>
        public int Q
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the R position of the axial coordinate.
        /// </summary>
        /// <value>The R position.</value>
        public int R
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the S position of the axial coordinate.
        /// </summary>
        /// <value>The S position.</value>
        public int S
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the array of all open borders.
        /// </summary>
        /// <value>The array of all open borders.</value>
        public bool[] IsOpen
        {
            get
            {
                return this.isOpen;
            }

            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException($"The {nameof(this.isOpen)} must not be null.");
                }
                else if (value.Length != 6)
                {
                    throw new ArgumentOutOfRangeException($"The {nameof(this.isOpen)} must not be 6.");
                }

                this.isOpen = value;
            }
        }

        /// <summary>
        /// Gets or sets the direction of the hexagon.
        /// </summary>
        /// <value>The direction of the hexagon.</value>
        public int Direction
        {
            get
            {
                return this.direction;
            }

            set
            {
                if (value < 0 || value >= 6)
                {
                    throw new ArgumentOutOfRangeException($"The {nameof(this.direction)} must be between 0-5.");
                }

                this.direction = value;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the hexagon is chosen.
        /// </summary>
        /// <value>The value indicating whether the hexagon is chosen.</value>
        public bool IsChosen
        {
            get;
            set;
        }
    }
}
