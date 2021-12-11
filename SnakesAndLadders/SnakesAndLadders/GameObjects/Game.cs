//-----------------------------------------------------------------------
// <copyright file="Game.cs" company="FHWN">
//     Copyright (c) Marcel Turobin-Ort. All rights reserved.
// </copyright>
// <author>Marcel Turobin-Ort</author>
// <summary>Defines the game instance of the snakes and ladders game.</summary>
//-----------------------------------------------------------------------
namespace SnakesAndLadders.GameObjects
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using SnakesAndLadders.EventArgs;

    /// <summary>
    /// Represents the snakes and ladders game.
    /// </summary>
    public class Game
    {
        /// <summary>
        /// Represents the name of the game instance.
        /// </summary>
        private string name;

        /// <summary>
        /// Represents the list of all fields in the game.
        /// </summary>
        private List<Field> fields;

        /// <summary>
        /// Represents the list of all players in the game.
        /// </summary>
        private List<Player> players;

        /// <summary>
        /// Represents the used dice.
        /// </summary>
        private Dice dice;

        /// <summary>
        /// Represents the counter for how many players already finished the game.
        /// </summary>
        private int finishedCounter;

        /// <summary>
        /// Initializes a new instance of the <see cref="Game"/> class.
        /// </summary>
        /// <param name="name">The name of the current game.</param>
        /// <param name="fields">The list of all fields in the game.</param>
        /// <param name="dice">The used dice.</param>
        /// <param name="players">The list of all players in the game.</param>
        public Game(string name, List<Field> fields, Dice dice, List<Player> players)
        {
            this.Name = name;
            this.Fields = fields;
            this.Dice = dice;
            this.Players = players;
            this.IsFinished = false;
            this.finishedCounter = 0;
            this.Time = TimeSpan.Zero;
        }

        /// <summary>
        /// Occurs if the game is finished and every player reached the top.
        /// </summary>
        public event EventHandler<GameIsFinishedEventArg> GameIsFinished;

        /// <summary>
        /// Gets the name of the current game.
        /// </summary>
        /// <value>The name of the current game.</value>
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
        /// Gets the list of all fields for the game.
        /// </summary>
        /// <value>The list of all fields for the game.</value>
        public List<Field> Fields
        {
            get
            {
                return this.fields;
            }

            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException($"The {nameof(this.fields)} must not be null.");
                }

                this.fields = value;
            }
        }

        /// <summary>
        /// Gets the current dice and its possibility to gain random "rolls".
        /// </summary>
        /// <value>The current dice.</value>
        public Dice Dice
        {
            get
            {
                return this.dice;
            }

            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException($"The {nameof(this.dice)} must not be null.");
                }

                this.dice = value;
            }
        }

        /// <summary>
        /// Gets the list of all players in the game.
        /// </summary>
        /// <value>The list of all players.</value>
        public List<Player> Players
        {
            get
            {
                return this.players;
            }

            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException($"The {nameof(this.players)} must not be null.");
                }

                this.players = value;
            }
        }

        /// <summary>
        /// Gets a value indicating whether the game is finished or not.
        /// </summary>
        /// <value>The value indicating whether the game is finished.</value>
        public bool IsFinished
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the timespan which shows how long the game lasted.
        /// </summary>
        /// <value>The timespan which shows how long the game lasted.</value>
        public TimeSpan Time
        {
            get;
            private set;
        }

        /// <summary>
        /// Represents the method for playing the game.
        /// </summary>
        public void Run()
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            while (true)
            {
                this.IsFinished = this.CheckIfAllPlayersDone(this.Players, this.finishedCounter);

                if (this.IsFinished)
                {
                    stopwatch.Stop();
                    this.Time = stopwatch.Elapsed;
                    this.GameIsFinished?.Invoke(this, new GameIsFinishedEventArg(this));
                    return;
                }

                // Lets every Player move.
                foreach (Player player in this.Players)
                {
                    // Checks if player is finished.
                    if (!player.IsFinished)
                    {
                        int roll = this.Dice.RollDice();

                        // Checks if player would move too far.
                        if (player.Position + roll > this.Fields.Count - 1)
                        {
                            player.Turns.Add(new Turn(roll, player.Position, player.Position, false));
                            continue;
                        }

                        // Moves player to the new position.
                        player.Turns.Add(new Turn(roll, player.Position, this.Fields[player.Position + roll].Pointer, this.Fields[player.Position + roll].IsSpecial));
                        player.Position = this.Fields[player.Position + roll].Pointer;

                        if (player.Position == this.Fields.Count - 1)
                        {
                            this.finishedCounter++;
                            player.IsFinished = true;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Represents the method for checking if all players are done.
        /// </summary>
        /// <param name="players">The list of all players from the game.</param>
        /// <param name="finishedCounter">The amount of finished players.</param>
        /// <returns>True if all players are finished with the game and reached the top.</returns>
        private bool CheckIfAllPlayersDone(List<Player> players, int finishedCounter)
        {
            if (finishedCounter == players.Count)
            {
                return true;
            }

            return false;
        }
    }
}
