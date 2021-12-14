//-----------------------------------------------------------------------
// <copyright file="ApplicationLogic.cs" company="FHWN">
//     Copyright (c) Marcel Turobin-Ort. All rights reserved.
// </copyright>
// <author>Marcel Turobin-Ort</author>
// <summary>Defines the logic of the application.</summary>
//-----------------------------------------------------------------------
namespace SnakesAndLadders.Logic
{
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using SnakesAndLadders.EventArgs;
    using SnakesAndLadders.GameObjects;
    using SnakesAndLadders.Interfaces;

    /// <summary>
    /// Represents the application logic for the snakes and ladders simulation.
    /// </summary>
    public class ApplicationLogic
    {
        /// <summary>
        /// Represents the default board size.
        /// </summary>
        private static int defaultBoardSize = 100;

        /// <summary>
        /// Represents the default dice size.
        /// </summary>
        private static int defaultDiceSize = 6;

        /// <summary>
        /// Represents the default player size.
        /// </summary>
        private static int defaultPlayerSize = 1;

        /// <summary>
        /// Represents the default iteration size.
        /// </summary>
        private static int defaultIterationSize = 100;

        /// <summary>
        /// Represents the logger being used.
        /// </summary>
        private ILogger logger;

        /// <summary>
        /// Represents the instance used for user input.
        /// </summary>
        private IKeyboardWatcher keyboardWatcher;

        /// <summary>
        /// Represents the game factory.
        /// </summary>
        private GameFactory factory;

        /// <summary>
        /// Represents the list of all games.   
        /// </summary>
        private List<Game> games;

        /// <summary>
        /// Represents the simulation thread for each game.
        /// </summary>
        private List<Thread> simulations;

        /// <summary>
        /// Represents the amount of finished games.
        /// </summary>
        private int finishedCounter;

        /// <summary>
        /// Represents the value that indicates whether the game should stop.
        /// </summary>
        private bool isExit;

        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationLogic"/> class.
        /// </summary>
        /// <param name="logger">The current logger of the application.</param>
        /// <param name="watcher">The current keyboard watcher of the application.</param>
        public ApplicationLogic(ILogger logger, IKeyboardWatcher watcher)
        {
            this.Logger = logger;
            this.KeyboardWatcher = watcher;
            this.factory = new GameFactory();

            this.games = new List<Game>();
            this.simulations = new List<Thread>();
            this.finishedCounter = 0;
            this.isExit = false;
        }

        /// <summary>
        /// Gets the current application logger.
        /// </summary>
        /// <value>The current logger.</value>
        public ILogger Logger
        {
            get
            {
                return this.logger;
            }

            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException($"The {nameof(this.logger)} must not be null.");
                }

                this.logger = value;
            }
        }

        /// <summary>
        /// Gets the current keyboard watcher instance.
        /// </summary>
        /// <value>The current keyboard watcher.</value>
        public IKeyboardWatcher KeyboardWatcher
        {
            get
            {
                return this.keyboardWatcher;
            }

            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException($"The {nameof(this.keyboardWatcher)} must not be null.");
                }

                this.keyboardWatcher = value;
            }
        }

        /// <summary>
        /// Represents the method which starts the simulation.
        /// </summary>
        public void Run()
        {
            while (!this.isExit)
            {
                this.Logger.BoardSize(defaultBoardSize);
                int boardSize = this.SetSize(defaultBoardSize);

                this.Logger.DiceSize(defaultDiceSize);
                int diceSize = this.SetSize(defaultDiceSize);

                this.Logger.PlayerSize(defaultPlayerSize);
                int playerSize = this.SetSize(defaultPlayerSize);

                this.Logger.IterationSize(defaultIterationSize);
                int iterationSize = this.SetSize(defaultIterationSize);

                for (int i = 0; i < iterationSize; i++)
                {
                    this.games.Add(this.factory.CreateGame($"Game {i + 1}", boardSize, diceSize, playerSize));
                    this.simulations.Add(new Thread(this.RunSimulation));
                }

                // Starts the different games in parallel fashion.
                Parallel.For(0, this.simulations.Count, (i) => { this.simulations[i].Start(this.games[i]); });

                while (true)
                {
                    if (this.finishedCounter == iterationSize)
                    {
                        break;
                    }
                }

                this.Logger.Message("Simulation done");
                this.Logger.Message("Press any key to continue.");
                this.KeyboardWatcher.Continue();
                this.ShowResults(this.games);
                this.MoreInformation(this.games);
                this.Reset();
            }
        }

        /// <summary>
        /// Fires if a game finished.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">The arguments of the event.</param>
        protected void GameIsFinished(object sender, GameIsFinishedEventArg e)
        {
            this.finishedCounter++;
            this.Logger.Message($"{e.Game.Name} is finished.");
        }

        /// <summary>
        /// Represents a method which allows the user to look at chosen game simulations.
        /// </summary>
        /// <param name="games">The list of all games simulated.</param>
        private void MoreInformation(List<Game> games)
        {
            while (true)
            {
                this.Logger.Clear();
                this.Logger.Message($"If you want to look at a specific game, please enter the desired number 1 - {games.Count}");
                this.Logger.Message("Otherwise just press enter.");
                int index = this.Choose(games.Count);

                if (index == 0)
                {
                    return;
                }

                // Subtract the value that got added to start the list at 1 and not at 0.
                index--;
                this.Logger.Message($"Please choose the desired player and enter a number between 1 - {games[index].Players.Count}");
                this.Logger.Message("If you want to skip just press enter.");
                int playerIndex = this.Choose(games[index].Players.Count);

                if (playerIndex == 0)
                {
                    return;
                }

                playerIndex--;
                this.Logger.ShowGame(games[index], playerIndex);
                this.KeyboardWatcher.Continue();
            }
        }

        /// <summary>
        /// Represents a method for resetting the list of games and threads to start again.
        /// </summary>
        private void Reset()
        {
            this.games = new List<Game>();
            this.simulations = new List<Thread>();
            this.finishedCounter = 0;

            this.Logger.Exit();
            this.isExit = this.KeyboardWatcher.Exit();
        }

        /// <summary>
        /// Represents a method for running a single game simulation.
        /// </summary>
        /// <param name="data">The game instance that gets simulated.</param>
        private void RunSimulation(object data)
        {
            if (!(data is Game))
            {
                throw new ArgumentOutOfRangeException(nameof(data), $"The specified arguments must be of the type {nameof(Game)}");
            }

            Game game = (Game)data;
            game.GameIsFinished += this.GameIsFinished;

            this.Logger.Message($"{game.Name} is running.");
            game.Run();
        }

        /// <summary>
        /// Represents a method for showing the desired results of the simulations.
        /// </summary>
        /// <param name="games">The list of all games simulated.</param>
        private void ShowResults(List<Game> games)
        {
            var avgInfo = this.GetAvgInformation(games);
            double avg = avgInfo.Item1;
            int playerCount = avgInfo.Item2;
            int turnSum = avgInfo.Item3;

            var fastestInfo = this.GetFastestRound(games);
            Player fastestPlayer = fastestInfo.Item1;
            Game fastestGame = fastestInfo.Item2;

            this.Logger.ShowResults(avg, playerCount, games.Count, turnSum, fastestPlayer, fastestGame);
            this.KeyboardWatcher.Continue();
        }

        /// <summary>
        /// Represents a method for getting the average turns from all users.
        /// </summary>
        /// <param name="games">The list of all games simulated.</param>
        /// <returns>The average turns, the player count and the total sum of all turns.</returns>
        private (double, int, int) GetAvgInformation(List<Game> games)
        {
            int playerCount = 0;
            int turnsSum = 0;

            for (int i = 0; i < games.Count; i++)
            {
                for (int p = 0; p < games[i].Players.Count; p++)
                {
                    playerCount++;
                    turnsSum += games[i].Players[p].Turns.Count;
                }
            }

            return (Convert.ToDouble(turnsSum) / Convert.ToDouble(playerCount), playerCount, turnsSum);
        }

        /// <summary>
        /// Represents a method for getting the fastest simulation.
        /// </summary>
        /// <param name="games">The list of all games simulated.</param>
        /// <returns>The fastest player in the fastest game.</returns>
        private (Player, Game) GetFastestRound(List<Game> games)
        {
            Game fastestGame = games[0];
            Player fastestPlayer = fastestGame.Players[0];
            
            for (int i = 0; i < games.Count; i++)
            {
                for (int p = 0; p < games[i].Players.Count; p++)
                {
                    if (games[i].Players[p].Turns.Count < fastestPlayer.Turns.Count)
                    {
                        fastestPlayer = games[i].Players[p];
                        fastestGame = games[i];
                    }
                }
            }

            return (fastestPlayer, fastestGame);
        }

        /// <summary>
        /// Represents a method for letting the user change the size.
        /// </summary>
        /// <param name="defaultValue">The default value of the changed object.</param>
        /// <returns>The chosen size -> if no value was added, the default value will be return.</returns>
        private int SetSize(int defaultValue)
        {
            while (true)
            {
                string sizeString = this.KeyboardWatcher.ReadLine();

                bool isNumber = int.TryParse(sizeString, out int number);

                if (isNumber && number >= 0)
                {
                    return number;
                }
                else if (sizeString == string.Empty)
                {
                    return defaultValue;
                }

                this.Logger.Message("This is not a valid number.");
            }
        }

        /// <summary>
        /// Represents a method for letting the user choose an object.
        /// </summary>
        /// <param name="maxValue">The maximum value of the object.</param>
        /// <returns>The chosen value of the object.</returns>
        private int Choose(int maxValue)
        {
            while (true)
            {
                string sizeString = this.KeyboardWatcher.ReadLine();

                bool isNumber = int.TryParse(sizeString, out int number);

                if (isNumber && number > 0 && number <= maxValue)
                {
                    return number;
                }
                else if (sizeString == string.Empty)
                {
                    return 0;
                }

                this.Logger.Message("This is not a valid number.");
            }
        }
    }
}
