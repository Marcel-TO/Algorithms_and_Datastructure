//-----------------------------------------------------------------------
// <copyright file="Program.cs" company="FHWN">
//     Copyright (c) Marcel Turobin-Ort. All rights reserved.
// </copyright>
// <author>Marcel Turobin-Ort</author>
// <summary>Defines the program class for the maze print output.</summary>
//-----------------------------------------------------------------------
namespace MazeTester
{
    using System;
    using MazeGenerator_Model.Factories;
    using MazeGenerator_Model.Logic;

    /// <summary>
    /// Represents the main program of the console.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Represents the main method for printing the maze.
        /// </summary>
        /// <param name="args">The command line arguments.</param>
        public static void Main(string[] args)
        {
            MazeFactory factory = new MazeFactory(new RandomGenerator());
            Maze maze = factory.CreateMaze(5);

            ConsoleOutput logger = new ConsoleOutput();
            logger.PrintMaze(maze.Hexagons);
            Console.ReadKey();
        }
    }
}
