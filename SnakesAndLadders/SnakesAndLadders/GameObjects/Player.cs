//-----------------------------------------------------------------------
// <copyright file="Player.cs" company="FHWN">
//     Copyright (c) Marcel Turobin-Ort. All rights reserved.
// </copyright>
// <author>Marcel Turobin-Ort</author>
// <summary>Defines the player instance of a snakes and ladders game.</summary>
//-----------------------------------------------------------------------
namespace SnakesAndLadders.GameObjects
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Represents the player for the snakes and ladders game.
    /// </summary>
    public class Player
    {
        /// <summary>
        /// Represents the name of the current player.
        /// </summary>
        private string name;

        /// <summary>
        /// Represents the current position of the player.
        /// </summary>
        private int position;

        /// <summary>
        /// Represents the turn history of the player.
        /// </summary>
        private List<Turn> turns;

        /// <summary>
        /// Initializes a new instance of the <see cref="Player"/> class.
        /// </summary>
        /// <param name="name">The name of the player.</param>
        public Player(string name)
        {
            this.Name = name;
            this.Position = 0;
            this.IsFinished = false;
            this.Turns = new List<Turn>();
        }

        /// <summary>
        /// Gets the name of the current player.
        /// </summary>
        /// <value>The name of the player.</value>
        public string Name
        {
            get
            {
                return this.name;
            }

            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException($"The {nameof(this.name)} must not be null.");
                }

                this.name = value;
            }
        }

        /// <summary>
        /// Gets or sets the position of the current player.
        /// </summary>
        /// <value>The position of the player.</value>
        public int Position
        {
            get
            {
                return this.position;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException($"The {nameof(this.position)} must not be negative.");
                }

                this.position = value;
            }
        }

        /// <summary>
        /// Gets or sets the list of all turns from the player.
        /// </summary>
        /// <value>The "roll" value and the position at that point.</value>
        public List<Turn> Turns
        {
            get
            {
                return this.turns;
            }

            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException($"The {nameof(this.turns)} must not be null.");
                }

                this.turns = value;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the player is finished or not.
        /// </summary>
        /// <value>The value indicating whether the player is finished with the game.</value>
        public bool IsFinished
        {
            get;
            set;
        }
    }
}
