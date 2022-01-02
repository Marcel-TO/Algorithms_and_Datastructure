//-----------------------------------------------------------------------
// <copyright file="ConsoleOutput.cs" company="FHWN">
//     Copyright (c) Marcel Turobin-Ort. All rights reserved.
// </copyright>
// <author>Marcel Turobin-Ort</author>
// <summary>Defines the unit tests for the console output class.</summary>
//-----------------------------------------------------------------------
namespace MazeTester
{
    using System;
    using System.Collections.Generic;
    using MazeGenerator_Model.Logic;

    /// <summary>
    /// Represents the class for printing the hexagon maze.
    /// </summary>
    public class ConsoleOutput
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ConsoleOutput"/> class.
        /// </summary>
        public ConsoleOutput()
        {
            Console.SetWindowSize(Console.LargestWindowWidth, Console.LargestWindowHeight);
        }

        /// <summary>
        /// Represents the method for printing the maze.
        /// </summary>
        /// <param name="hexagons">The list of all hexagons.</param>
        public void PrintMaze(List<Hexagon> hexagons)
        {
            List<(int, int)> positions = new List<(int, int)>(hexagons.Count);

            foreach (Hexagon hex in hexagons)
            {
                positions.Add(this.HexToPosition(hex));
            }

            this.PrintHexagons(hexagons, positions);
        }

        /// <summary>
        /// Represents the method for printing the hexagon list.
        /// </summary>
        /// <param name="hexagons">The list of all hexagons.</param>
        /// <param name="positions">The list of all positions.</param>
        private void PrintHexagons(List<Hexagon> hexagons, List<(int, int)> positions)
        {
            int middleX = Console.WindowWidth / 2;
            int middleY = Console.WindowHeight / 2;

            for (int i = 0; i < hexagons.Count; i++)
            {
                int x = middleX + positions[i].Item1;
                int y = middleY + positions[i].Item2;

                Console.SetCursorPosition(x, y - 1);
                if (hexagons[i].IsOpen[1])
                {
                    Console.Write(" ");
                }
                else
                {
                    Console.Write("/");
                }

                if (hexagons[i].IsOpen[2])
                {
                    Console.Write(" ");
                }
                else
                {
                    Console.Write("\\");
                }

                Console.SetCursorPosition(x - 1, y);
                if (hexagons[i].IsOpen[3])
                {
                    Console.Write("  ");
                }
                else
                {
                    Console.Write("| ");
                }

                if (hexagons[i].IsOpen[0])
                {
                    Console.Write("  ");
                }
                else
                {
                    Console.Write(" |");
                }

                Console.SetCursorPosition(x, y + 1);
                if (hexagons[i].IsOpen[4])
                {
                    Console.Write(" ");
                }
                else
                {
                    Console.Write("\\");
                }

                if (hexagons[i].IsOpen[5])
                {
                    Console.Write(" ");
                }
                else
                {
                    Console.Write("/");
                }
            }
        }

        /// <summary>
        /// Represents the method for converting the axial coordinates to normal.
        /// </summary>
        /// <param name="hex">The current hexagon.</param>
        /// <returns>The coordinate of the hexagon.</returns>
        private (int, int) HexToPosition(Hexagon hex)
        {
            int x = 0;
            int y = 0;

            x = hex.Q + (hex.Q + hex.R) + 4;
            y = hex.R * 2;

            return (x, y);
        }

        /// <summary>
        /// Represents the Positions of the flat hexagons.
        /// </summary>
        /// <param name="hex">The current hexagon.</param>
        /// <returns>The coordinates of the hexagon.</returns>
        private (int, int) Flat_HexToPixel(Hexagon hex)
        {
            var x = (3.0 / 2) * hex.Q;
            var y = ((Math.Sqrt(3) / 2) * hex.Q) + (Math.Sqrt(3) * hex.R);

            return (Convert.ToInt32(x), Convert.ToInt32(y));
        }

        /// <summary>
        /// Represents the Positions of the pointy hexagons.
        /// </summary>
        /// <param name="hex">The current hexagon.</param>
        /// <returns>The coordinates of the hexagon.</returns>
        private (int, int) Pointy_HexToPixel(Hexagon hex)
        {
            var x = ((Math.Sqrt(3) / 2) * hex.Q) + (Math.Sqrt(3) * hex.R);
            var y = (3.0 / 2) * hex.Q;

            return (Convert.ToInt32(x), Convert.ToInt32(y));
        }
    }
}
