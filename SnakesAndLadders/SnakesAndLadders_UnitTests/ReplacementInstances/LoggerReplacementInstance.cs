//-----------------------------------------------------------------------
// <copyright file="LoggerReplacementInstance.cs" company="FHWN">
//     Copyright (c) Marcel Turobin-Ort. All rights reserved.
// </copyright>
// <author>Marcel Turobin-Ort</author>
// <summary>Defines the console logger replacement for testing purpose only.</summary>
//-----------------------------------------------------------------------
namespace SnakesAndLadders_UnitTests.ReplacementInstances
{
    using SnakesAndLadders.GameObjects;
    using SnakesAndLadders.Interfaces;

    /// <summary>
    /// Represents the logger for testing purpose only.
    /// </summary>
    public class LoggerReplacementInstance : ILogger
    {
        /// <summary>
        /// Represents the method for asking for board size information.
        /// </summary>
        /// <param name="defaultValue">The default value of the board size.</param>
        public void BoardSize(int defaultValue)
        {
            return;
        }

        /// <summary>
        /// Represents the method for clearing the console.
        /// </summary>
        public void Clear()
        {
          return;
        }

        /// <summary>
        /// Represents the method for asking for dice size information.
        /// </summary>
        /// <param name="defaultValue">The default value of the dice size.</param>
        public void DiceSize(int defaultValue)
        {
          return;
        }

        /// <summary>
        /// Represents the method for asking for iteration size information.
        /// </summary>
        /// <param name="defaultValue">The default value of the iteration size.</param>
        public void IterationSize(int defaultValue)
        {
         return;
        }

        /// <summary>
        /// Represents the method for displaying a message.
        /// </summary>
        /// <param name="message">The message sent.</param>
        public void Message(string message)
        {
         return;
        }

        /// <summary>
        /// Represents the method for asking for player size information.
        /// </summary>
        /// <param name="defaultValue">The default value of the player size.</param>
        public void PlayerSize(int defaultValue)
        {
          return;
        }

        /// <summary>
        /// Represents the method for showing a specific simulation.
        /// </summary>
        /// <param name="game">The chosen game.</param>
        /// <param name="playerIndex">The specific player index from the game.</param>
        public void ShowGame(Game game, int playerIndex)
        {
           return;
        }

        /// <summary>
        /// Represents the method for showing the result of the simulation.
        /// </summary>
        /// <param name="avg">The average turns to finish the game.</param>
        /// <param name="playerCount">The amount of players.</param>
        /// <param name="gameCount">The amount of games.</param>
        /// <param name="turnSum">The amount of turns from all players.</param>
        /// <param name="fastestPlayer">The fastest player to finish the game.</param>
        /// <param name="fastestGame">The fastest game instance.</param>
        public void ShowResults(double avg, int playerCount, int gameCount, int turnSum, Player fastestPlayer, Game fastestGame)
        {
            return;
        }

        /// <summary>
        /// Represents the method for asking user if he wants to exit.
        /// </summary>
        public void Exit()
        {
            return;
        }
    }
}
