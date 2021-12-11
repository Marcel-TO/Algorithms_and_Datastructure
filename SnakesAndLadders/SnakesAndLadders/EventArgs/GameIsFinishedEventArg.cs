//-----------------------------------------------------------------------
// <copyright file="GameIsFinishedEventArg.cs" company="FHWN">
//     Copyright (c) Marcel Turobin-Ort. All rights reserved.
// </copyright>
// <author>Marcel Turobin-Ort</author>
// <summary>Defines the event arguments for the event which fires if the game is finished.</summary>
//-----------------------------------------------------------------------
namespace SnakesAndLadders.EventArgs
{
    using System;
    using SnakesAndLadders.GameObjects;

    /// <summary>
    /// Represents a the arguments of the event which is fired, if the game is finished.
    /// </summary>
    public class GameIsFinishedEventArg : EventArgs
    {
        /// <summary>
        /// Represents the current game instance.
        /// </summary>
        private Game game;

        /// <summary>
        /// Initializes a new instance of the <see cref="GameIsFinishedEventArg"/> class.
        /// </summary>
        /// <param name="game">The current game.</param>
        public GameIsFinishedEventArg(Game game)
        {
            this.Game = game;
        }

        /// <summary>
        /// Gets the current game.
        /// </summary>
        /// <value>The current game instance.</value>
        public Game Game
        {
            get
            {
                return this.game;
            }

            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException($"The {nameof(this.game)} must not be null.");
                }

                this.game = value;
            }
        }
    }
}
