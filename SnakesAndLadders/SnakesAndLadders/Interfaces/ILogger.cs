//-----------------------------------------------------------------------
// <copyright file="ILogger.cs" company="FHWN">
//     Copyright (c) Marcel Turobin-Ort. All rights reserved.
// </copyright>
// <author>Marcel Turobin-Ort</author>
// <summary>Defines the interface for logging the application.</summary>
//-----------------------------------------------------------------------
namespace SnakesAndLadders.Interfaces
{
    using SnakesAndLadders.GameObjects;

    /// <summary>
    /// Represents the logging instance of the application.
    /// </summary>
    public interface ILogger
    {
        /// <summary>
        /// Represents the method for asking for board size information.
        /// </summary>
        /// <param name="defaultValue">The default value of the board size.</param>
        void BoardSize(int defaultValue);

        /// <summary>
        /// Represents the method for asking for dice size information.
        /// </summary>
        /// <param name="defaultValue">The default value of the dice size.</param>
        void DiceSize(int defaultValue);

        /// <summary>
        /// Represents the method for asking for player size information.
        /// </summary>
        /// <param name="defaultValue">The default value of the player size.</param>
        void PlayerSize(int defaultValue);

        /// <summary>
        /// Represents the method for asking for iteration size information.
        /// </summary>
        /// <param name="defaultValue">The default value of the iteration size.</param>
        void IterationSize(int defaultValue);

        /// <summary>
        /// Represents the method for displaying a message.
        /// </summary>
        /// <param name="message">The message sent.</param>
        void Message(string message);

        /// <summary>
        /// Represents the method for showing the result of the simulation.
        /// </summary>
        /// <param name="avg">The average turns to finish the game.</param>
        /// <param name="playerCount">The amount of players.</param>
        /// <param name="gameCount">The amount of games.</param>
        /// <param name="turnSum">The amount of turns from all players.</param>
        /// <param name="fastestPlayer">The fastest player to finish the game.</param>
        /// <param name="fastestGame">The fastest game instance.</param>
        void ShowResults(double avg, int playerCount, int gameCount, int turnSum, Player fastestPlayer, Game fastestGame);

        /// <summary>
        /// Represents the method for showing a specific simulation.
        /// </summary>
        /// <param name="game">The chosen game.</param>
        /// <param name="playerIndex">The specific player index from the game.</param>
        void ShowGame(Game game, int playerIndex);

        /// <summary>
        /// Represents the method for clearing the console.
        /// </summary>
        void Clear();

        /// <summary>
        /// Represents the method for asking user if he wants to exit.
        /// </summary>
        void Exit();
    }
}
