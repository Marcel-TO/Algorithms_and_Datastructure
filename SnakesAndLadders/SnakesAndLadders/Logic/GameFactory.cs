//-----------------------------------------------------------------------
// <copyright file="GameFactory.cs" company="FHWN">
//     Copyright (c) Marcel Turobin-Ort. All rights reserved.
// </copyright>
// <author>Marcel Turobin-Ort</author>
// <summary>Defines the factory for creating a snakes and ladders game.</summary>
//-----------------------------------------------------------------------
namespace SnakesAndLadders.Logic
{
    using System;
    using System.Collections.Generic;
    using SnakesAndLadders.GameObjects;

    /// <summary>
    /// Represents a factory class creating a snakes and ladders game.
    /// </summary>
    public class GameFactory
    {
        /// <summary>
        /// Represents the percentage of how many "special" fields are scattered around the board.
        /// </summary>
        private static double specialPercentage = 0.19;

        /// <summary>
        /// Represents a method for creating a game instance.
        /// </summary>
        /// <param name="name">The name of the game instance.</param>
        /// <param name="boardSize">The size of the board.</param>
        /// <param name="diceSize">The size of the current dice.</param>
        /// <param name="playerSize">The size of players in the current game.</param>
        /// <returns>The new game instance.</returns>
        public Game CreateGame(string name, int boardSize, int diceSize, int playerSize)
        {
            if (name == null)
            {
                throw new ArgumentNullException($"The {nameof(name)} must not be null.");
            }
            else if (boardSize < 1 || diceSize < 1 || playerSize < 1)
            {
                throw new ArgumentOutOfRangeException("The size values must not be at least 1.");
            }

            List<Field> fields = this.CreateFields(boardSize, diceSize);
            Dice dice = this.CreateDice(diceSize);
            List<Player> players = this.CreatePlayers(playerSize);

            return new Game(name, fields, dice, players);
        }

        /// <summary>
        /// Represents a method for creating the list of all fields.
        /// </summary>
        /// <param name="size">The size of the board.</param>
        /// <param name="diceSize">The size of the current dice.</param>
        /// <returns>The new list of all fields.</returns>
        private List<Field> CreateFields(int size, int diceSize)
        {
            List<Field> fields;

            while (true)
            {
                fields = new List<Field>(size);

                for (int i = 0; i < size; i++)
                {
                    fields.Add(new Field(i));
                }

                // Add special fields (Snakes and Ladders).
                Random random = new Random();
                int snakeAmount = Convert.ToInt32(specialPercentage * size);

                for (int i = 0; i < snakeAmount; i++)
                {
                    while (true)
                    {
                        // Chooses a random number.
                        int index = random.Next(1, size - 1);

                        // Checks if the field on this number is already special.
                        if (!fields[index].IsSpecial)
                        {
                            // Chooses another random number to where the field is going to point at.
                            int pointer = random.Next(0, size - 1);

                            // Checks if field on new random number is not special and is not the same field.
                            if (!fields[pointer].IsSpecial && pointer != index)
                            {
                                fields[index].IsSpecial = true;
                                fields[index].Pointer = pointer;
                                break;
                            }
                        }
                    }
                }

                int counter = 0;
                bool isPossible = true;

                for (int i = 0; i < fields.Count; i++)
                {
                    if (fields[i].IsSpecial)
                    {
                        counter++;

                        if (counter >= diceSize - 1)
                        {
                            isPossible = false;
                        }

                        continue;
                    }

                    counter = 0;
                }

                if (isPossible)
                {
                    break;
                }
            }

            return fields;
        }

        /// <summary>
        /// Represents a method for creating the dice used in the game simulation.
        /// </summary>
        /// <param name="size">The size of the dice.</param>
        /// <returns>The new dice for the current game.</returns>
        private Dice CreateDice(int size)
        {
            return new Dice(size);
        }

        /// <summary>
        /// Represents a method for creating a list of all players.
        /// </summary>
        /// <param name="size">The size of all possible players.</param>
        /// <returns>The new list of all players in the game.</returns>
        private List<Player> CreatePlayers(int size)
        {
            List<Player> players = new List<Player>(size);

            for (int i = 0; i < size; i++)
            {
                players.Add(new Player($"Player {i + 1}"));
            }

            return players;
        }
    }
}
