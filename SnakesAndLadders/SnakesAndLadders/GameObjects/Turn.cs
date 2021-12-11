//-----------------------------------------------------------------------
// <copyright file="Turn.cs" company="FHWN">
//     Copyright (c) Marcel Turobin-Ort. All rights reserved.
// </copyright>
// <author>Marcel Turobin-Ort</author>
// <summary>Defines the turn instance from a player from a snakes and ladders game.</summary>
//-----------------------------------------------------------------------
namespace SnakesAndLadders.GameObjects
{
    using System;

    /// <summary>
    /// Represents the the player turn of a snakes and ladders game.
    /// </summary>
    public class Turn
    {
        /// <summary>
        /// Represents the "rolling" value of the dice.
        /// </summary>
        private int roll;

        /// <summary>
        /// Represents the new position of the player.
        /// </summary>
        private int newPosition;

        /// <summary>
        /// Represents the old position of the player.
        /// </summary>
        private int oldPosition;

        /// <summary>
        /// Initializes a new instance of the <see cref="Turn"/> class.
        /// </summary>
        /// <param name="roll">The "rolling" value of the dice.</param>
        /// <param name="oldPos">The old position of the player.</param>
        /// <param name="newPos">The new position of the player.</param>
        /// <param name="usedSpecial">The value indicating whether the player stepped on a special field.</param>
        public Turn(int roll, int oldPos, int newPos, bool usedSpecial)
        {
            this.DiceRoll = roll;
            this.OldPosition = oldPos;
            this.NewPosition = newPos;
            this.UsedSpecial = usedSpecial;
        }

        /// <summary>
        /// Gets the value from the dice "roll".
        /// </summary>
        /// <value>The value from the dice.</value>
        public int DiceRoll
        {
            get
            {
                return this.roll;
            }

            private set
            {
                if (value < 1)
                {
                    throw new ArgumentOutOfRangeException($"The {nameof(this.roll)} must not be negative.");
                }

                this.roll = value;
            }
        }

        /// <summary>
        /// Gets the new position of the current player.
        /// </summary>
        /// <value>The new position from the game board.</value>
        public int NewPosition
        {
            get
            {
                return this.newPosition;
            }

            private set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException($"The {nameof(this.newPosition)} must not be negative.");
                }

                this.newPosition = value;
            }
        }

        /// <summary>
        /// Gets the old position of the current player.
        /// </summary>
        /// <value>The old position from the game board.</value>
        public int OldPosition
        {
            get
            {
                return this.oldPosition;
            }

            private set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException($"The {nameof(this.oldPosition)} must not be negative.");
                }

                this.oldPosition = value;
            }
        }

        /// <summary>
        /// Gets a value indicating whether the player used a "special" field.
        /// </summary>
        /// <value>The value indicating whether the player skipped or lost progress.</value>
        public bool UsedSpecial
        {
            get;
            private set;
        }
    }
}
