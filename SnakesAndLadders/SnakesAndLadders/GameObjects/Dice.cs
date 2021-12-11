//-----------------------------------------------------------------------
// <copyright file="Dice.cs" company="FHWN">
//     Copyright (c) Marcel Turobin-Ort. All rights reserved.
// </copyright>
// <author>Marcel Turobin-Ort</author>
// <summary>Defines dice instance which rolls a random number within a specific range.</summary>
//-----------------------------------------------------------------------
namespace SnakesAndLadders.GameObjects
{
    using System;

    /// <summary>
    /// Represents the dice class which rolls random numbers.
    /// </summary>
    public class Dice
    {
        /// <summary>
        /// Represents the size of the current dice.
        /// </summary>
        private int size;

        /// <summary>
        /// Initializes a new instance of the <see cref="Dice"/> class.
        /// </summary>
        /// <param name="size">The max value of the dice.</param>
        public Dice(int size)
        {
            this.Size = size;
        }

        /// <summary>
        /// Gets the size of the current dice.
        /// </summary>
        /// <value>The maximum value of the dice.</value>
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
                    throw new ArgumentOutOfRangeException($"The {nameof(this.size)} must not be less than 1.");
                }

                this.size = value;
            }
        }

        /// <summary>
        /// Represents the method for rolling the dice.
        /// </summary>
        /// <returns>A random number between 1 and the maximum value.</returns>
        public int RollDice()
        {
            Random random = new Random();

            return random.Next(1, this.Size + 1);
        }
    }
}
