//-----------------------------------------------------------------------
// <copyright file="ConsoleLogger.cs" company="FHWN">
//     Copyright (c) Marcel Turobin-Ort. All rights reserved.
// </copyright>
// <author>Marcel Turobin-Ort</author>
// <summary>Defines the console logger of the application.</summary>
//-----------------------------------------------------------------------
namespace SnakesAndLadders.Logic
{
    using System;
    using SnakesAndLadders.GameObjects;
    using SnakesAndLadders.Interfaces;

    /// <summary>
    /// Represents a method for logging on console.
    /// </summary>
    public class ConsoleLogger : ILogger
    {
        /// <summary>
        /// Represents the method for asking for board size information.
        /// </summary>
        /// <param name="defaultValue">The default value of the board size.</param>
        public void BoardSize(int defaultValue)
        {
            this.Clear();

            Console.SetCursorPosition(0, 0);

            Console.WriteLine("What size should the board be?");
            Console.WriteLine($"Please enter the desired number. If you just press enter the default size is {defaultValue}.");
        }

        /// <summary>
        /// Represents the method for asking for dice size information.
        /// </summary>
        /// <param name="defaultValue">The default value of the dice size.</param>
        public void DiceSize(int defaultValue)
        {
            this.Clear();

            Console.SetCursorPosition(0, 0);

            Console.WriteLine("What size should the dize be?");
            Console.WriteLine($"Please enter the desired number. If you just press enter the default size is {defaultValue}.");
        }

        /// <summary>
        /// Represents the method for asking for player size information.
        /// </summary>
        /// <param name="defaultValue">The default value of the player size.</param>
        public void PlayerSize(int defaultValue)
        {
            this.Clear();

            Console.SetCursorPosition(0, 0);

            Console.WriteLine("How many players should be on the board?");
            Console.WriteLine($"Please enter the desired number. If you just press enter the default size is {defaultValue}.");
        }

        /// <summary>
        /// Represents the method for asking for iteration size information.
        /// </summary>
        /// <param name="defaultValue">The default value of the iteration size.</param>
        public void IterationSize(int defaultValue)
        {
            this.Clear();

            Console.SetCursorPosition(0, 0);

            Console.WriteLine("How many iterations should be on the simulated?");
            Console.WriteLine($"Please enter the desired number. If you just press enter the default size is {defaultValue}.");
        }

        /// <summary>
        /// Represents the method for displaying a message.
        /// </summary>
        /// <param name="message">The message sent.</param>
        public void Message(string message)
        {
            Console.WriteLine(message);
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
            this.Clear();

            int x = 1;
            int y = 1;

            Console.SetCursorPosition(x, y++);
            Console.WriteLine($"Average turns: {avg.ToString("00.00")}");
            Console.SetCursorPosition(x, y++);
            Console.WriteLine($"Players: {playerCount}");
            Console.SetCursorPosition(x, y++);
            Console.WriteLine($"Games: {gameCount}");
            Console.SetCursorPosition(x, y++);
            Console.WriteLine($"Total turns: {turnSum}");
            Console.SetCursorPosition(x, y++);
            Console.WriteLine($"Total fields: {fastestGame.Fields.Count}");

            y += 2;

            Console.SetCursorPosition(x, y);
            Console.WriteLine("------------");

            y += 2;

            Console.SetCursorPosition(x, y++);
            Console.WriteLine($"The fastest round overall was made in game {fastestGame.Name} with {fastestGame.Time.TotalMilliseconds}ms");
            Console.SetCursorPosition(x, y++);
            Console.WriteLine($"The player {fastestPlayer.Name} finished first:");
            Console.SetCursorPosition(x, y++);
            Console.WriteLine($"All {fastestPlayer.Turns.Count} Turns.");

            y++;

            for (int i = 0; i < fastestPlayer.Turns.Count; i++)
            {
                Console.SetCursorPosition(x, y++);

                if (!fastestPlayer.Turns[i].UsedSpecial)
                {
                    Console.Write($"Dice roll: {fastestPlayer.Turns[i].DiceRoll} | Field: {fastestPlayer.Turns[i].OldPosition + 1} -> {fastestPlayer.Turns[i].NewPosition + 1}");
                }
                else
                {
                    Console.Write($"Dice roll: {fastestPlayer.Turns[i].DiceRoll} | Field: {fastestPlayer.Turns[i].OldPosition + 1} -> " +
                        $"Special field: {fastestPlayer.Turns[i].OldPosition + 1 + fastestPlayer.Turns[i].DiceRoll} -> brings user: {fastestPlayer.Turns[i].NewPosition + 1}");
                }
            }

            y += 2;

            Console.SetCursorPosition(x, y);
            Console.WriteLine("------------");

            y += 2;
            Console.SetCursorPosition(x, y);
            Console.WriteLine("Press any key to continue.");
        }

        /// <summary>
        /// Represents the method for showing a specific simulation.
        /// </summary>
        /// <param name="game">The chosen game.</param>
        /// <param name="playerIndex">The specific player index from the game.</param>
        public void ShowGame(Game game, int playerIndex)
        {
            this.Clear();

            int x = 1;
            int y = 1;

            Console.SetCursorPosition(x, y++);
            Console.WriteLine($"The {game.Name} ended in {game.Time.Milliseconds}ms");
            Console.SetCursorPosition(x, y++);
            Console.WriteLine($"The the turns of the player {game.Players[playerIndex].Name}:");
            Console.SetCursorPosition(x, y++);
            Console.WriteLine($"All {game.Players[playerIndex].Turns.Count} Turns.");

            y++;

            for (int i = 0; i < game.Players[playerIndex].Turns.Count; i++)
            {
                Console.SetCursorPosition(x, y++);

                if (!game.Players[playerIndex].Turns[i].UsedSpecial)
                {
                    Console.Write($"Dice roll: {game.Players[playerIndex].Turns[i].DiceRoll} | Field: {game.Players[playerIndex].Turns[i].OldPosition + 1} -> {game.Players[playerIndex].Turns[i].NewPosition + 1}");
                }
                else
                {
                    Console.Write($"Dice roll: {game.Players[playerIndex].Turns[i].DiceRoll} | Field: {game.Players[playerIndex].Turns[i].OldPosition + 1} -> " +
                        $"Special field: {game.Players[playerIndex].Turns[i].OldPosition + 1 + game.Players[playerIndex].Turns[i].DiceRoll} -> brings user: {game.Players[playerIndex].Turns[i].NewPosition + 1}");
                }
            }

            y += 2;

            Console.SetCursorPosition(x, y);
            Console.WriteLine("------------");

            y += 2;
            Console.SetCursorPosition(x, y);
            Console.WriteLine("Press any key to continue.");
        }

        /// <summary>
        /// Represents the method for clearing the console.
        /// </summary>
        public void Clear()
        {
            Console.Clear();
        }
    }
}
