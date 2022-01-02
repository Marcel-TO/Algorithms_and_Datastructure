//-----------------------------------------------------------------------
// <copyright file="MazeFactory.cs" company="FHWN">
//     Copyright (c) Marcel Turobin-Ort. All rights reserved.
// </copyright>
// <author>Marcel Turobin-Ort</author>
// <summary>Defines the factory class for the hexagon maze.</summary>
//-----------------------------------------------------------------------
namespace MazeGenerator_Model.Factories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using MazeGenerator_Model.Interfaces;
    using MazeGenerator_Model.Logic;

    /// <summary>
    /// Represents the factory class for the hexagon maze.
    /// </summary>
    public class MazeFactory
    {
        /// <summary>
        /// Represents the directions for the neighbor navigation.
        /// </summary>
        private List<Hexagon> directions;

        /// <summary>
        /// Represents the random number generator.
        /// </summary>
        private IRandom random;

        /// <summary>
        /// Initializes a new instance of the <see cref="MazeFactory"/> class.
        /// </summary>
        /// <param name="random">The random number generator.</param>
        public MazeFactory(IRandom random)
        {
            if (random == null)
            {
                throw new ArgumentNullException($"The {nameof(random)} must not be null.");
            }

            this.random = random;

            this.directions = new List<Hexagon>(6)
            {
                new Hexagon(1, 0, -1),
                new Hexagon(1, -1, 0),
                new Hexagon(0, -1, 1),
                new Hexagon(-1, 0, 1),
                new Hexagon(-1, 1, 0),
                new Hexagon(0, 1, -1)

                /*
                 * Flat directions:
                 *  LowerRight, UpperRight, Up, UpperLeft, LowerLeft, Down
                 *  
                 *  Pointy directions:
                 *  Right, UpperRight, upperLeft, Left, LowerLeft, LowerRight
                 */
            };
        }

        /// <summary>
        /// Represents the method for creating a hexagon maze.
        /// </summary>
        /// <param name="size">The size of the maze.</param>
        /// <returns>The generated maze.</returns>
        public Maze CreateMaze(int size)
        {
            if (size < 1)
            {
                throw new ArgumentOutOfRangeException($"The {nameof(size)} must be atleast 1.");
            }

            List<Hexagon> hexagons = this.CreateHexagons(size);

            int startIndex = this.GetRandomHex(hexagons);
            hexagons[startIndex].IsChosen = true;

            while (true)
            {
                int randomIndex = this.GetRandomHex(hexagons);

                hexagons = this.RandomWalk(hexagons, randomIndex, size);

                var unfinished = hexagons.Where(h => !h.IsChosen).ToList();

                if (unfinished.Count == 0)
                {
                    return new Maze(hexagons, size);
                }
            }
        }

        /// <summary>
        /// Represents the method for creating the list of hexagons.
        /// </summary>
        /// <param name="size">The size of the maze.</param>
        /// <returns>The list of all hexagons.</returns>
        private List<Hexagon> CreateHexagons(int size)
        {
            List<Hexagon> hexagons = new List<Hexagon>();

            for (int q = size * (-1); q < size + 1; q++)
            {
                for (int r = size * (-1); r < size + 1; r++)
                {
                    for (int s = size * (-1); s < size + 1; s++)
                    {
                        if (q + r + s == 0)
                        {
                            hexagons.Add(new Hexagon(q, r, s));
                        }
                    }
                }
            }

            return hexagons;
        }

        /// <summary>
        /// Represents the method for a random walk.
        /// </summary>
        /// <param name="hexagons">The list of all hexagons.</param>
        /// <param name="randomIndex">The index of the random start position.</param>
        /// <param name="size">The size of the maze.</param>
        /// <returns>The list of all hexagons from the walk.</returns>
        private List<Hexagon> RandomWalk(List<Hexagon> hexagons, int randomIndex, int size)
        {
            List<Hexagon> walk = new List<Hexagon> { hexagons[randomIndex] };

            while (true)
            {
                int direction = this.random.Random(0, 6);
                Hexagon neighbor = this.HexNeighbor(walk[walk.Count - 1], direction);

                // Check if neighbor is in range.
                if (neighbor.Q < size && neighbor.R < size && neighbor.S < size && neighbor.Q > -size && neighbor.R > -size && neighbor.S > -size)
                {
                    walk[walk.Count - 1].Direction = direction;

                    // Go through every step from the random walk.
                    for (int i = 0; i < walk.Count; i++)
                    {
                        // Check if it chose a hexagon from before and removes the current way since the point.
                        if (neighbor.Q == walk[i].Q && neighbor.R == walk[i].R && neighbor.S == walk[i].S)
                        {
                            walk.RemoveRange(i, walk.Count - i);
                        }
                    }

                    bool check = this.CheckIfWalkHitCurrentMaze(neighbor, hexagons);

                    if (check)
                    {
                        return this.AddWalk(walk, hexagons);
                    }

                    // Adds the neighbor.
                    walk.Add(neighbor);
                }
            }
        }

        /// <summary>
        /// Represents the method for adding the random walk to the maze.
        /// </summary>
        /// <param name="walk">The random walk.</param>
        /// <param name="hexagons">The list of all hexagons.</param>
        /// <returns>The list of the changed hexagons.</returns>
        private List<Hexagon> AddWalk(List<Hexagon> walk, List<Hexagon> hexagons)
        {
            for (int w = 0; w < walk.Count; w++)
            {
                for (int h = 0; h < hexagons.Count; h++)
                {
                    if (walk[w].Q == hexagons[h].Q && walk[w].R == hexagons[h].R && walk[w].S == hexagons[h].S)
                    {
                        hexagons[h].IsChosen = true;
                        hexagons[h].Direction = walk[w].Direction;
                        hexagons[h].IsOpen[hexagons[h].Direction] = true;

                        Hexagon neighbor = this.HexNeighbor(hexagons[h], hexagons[h].Direction);
                        var hex = hexagons.Where(h => h.Q == neighbor.Q && h.R == neighbor.R && h.S == neighbor.S).ToList();
                        hex[0].IsOpen[this.InverseDirection(hexagons[h].Direction)] = true;
                        continue;
                    }
                }
            }

                return hexagons;
        }

        /// <summary>
        /// Represents the method for checking if the random walk hit the current maze.
        /// </summary>
        /// <param name="latestWalk">The latest position of the walk.</param>
        /// <param name="hexagons">The list of all hexagons of the maze.</param>
        /// <returns>True if the walk hit the current maze, otherwise false.</returns>
        private bool CheckIfWalkHitCurrentMaze(Hexagon latestWalk, List<Hexagon> hexagons)
        {
            for (int i = 0; i < hexagons.Count; i++)
            {
                if (latestWalk.Q == hexagons[i].Q && latestWalk.R == hexagons[i].R && latestWalk.S == hexagons[i].S)
                {
                    if (hexagons[i].IsChosen)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        /// <summary>
        /// Represents the method for inversing the direction.
        /// </summary>
        /// <param name="direction">The current direction.</param>
        /// <returns>The inversed direction.</returns>
        private int InverseDirection(int direction)
        {
            direction += 3;

            if (direction >= this.directions.Count)
            {
                direction -= this.directions.Count;
            }

            return direction;
        }

        /// <summary>
        /// Represents the method for getting a random position from the maze that isn't chosen.
        /// </summary>
        /// <param name="hexagons">The list of all hexagons.</param>
        /// <returns>The random hexagon that isn't chosen.</returns>
        private int GetRandomHex(List<Hexagon> hexagons)
        {
            while (true)
            {
                int random = this.random.Random(0, hexagons.Count);

                if (!hexagons[random].IsChosen)
                {
                    return random;
                }
            }
        }

        /// <summary>
        /// Represents the method for adding the hexagons together.
        /// </summary>
        /// <param name="a">The first hexagon.</param>
        /// <param name="b">The second hexagon.</param>
        /// <returns>The new hexagon.</returns>
        private Hexagon Hex_Add(Hexagon a, Hexagon b)
        {
            if (a == null)
            {
                throw new ArgumentNullException($"The {nameof(a)} must not be null.");
            }
            else if (b == null)
            {
                throw new ArgumentNullException($"The {nameof(b)} must not be null.");
            }

            return new Hexagon(a.Q + b.Q, a.R + b.R, a.S + b.S);
        }

        /// <summary>
        /// Represents the method for subtracting the hexagons.
        /// </summary>
        /// <param name="a">The first hexagon.</param>
        /// <param name="b">The second hexagon.</param>
        /// <returns>The new subtracted hexagon.</returns>
        private Hexagon Hex_Subtract(Hexagon a, Hexagon b)
        {
            if (a == null)
            {
                throw new ArgumentNullException($"The {nameof(a)} must not be null.");
            }
            else if (b == null)
            {
                throw new ArgumentNullException($"The {nameof(b)} must not be null.");
            }

            return new Hexagon(a.Q - b.Q, a.R - b.R, a.S - b.S);
        }

        /// <summary>
        /// Represents the direction for the next hexagon.
        /// </summary>
        /// <param name="direction">The direction.</param>
        /// <returns>The new Hexagon direction.</returns>
        private Hexagon HexDirection(int direction)
        {
            if (direction < 0 || direction >= this.directions.Count)
            {
                throw new ArgumentOutOfRangeException($"The {nameof(direction)} must be between the directions 0 - {this.directions.Count - 1}");
            }

            return this.directions[direction];
        }

        /// <summary>
        /// Represents the method for getting the neighbor of the current hexagon.
        /// </summary>
        /// <param name="hex">The current hexagon.</param>
        /// <param name="direction">The direction for the next hexagon.</param>
        /// <returns>The neighbor of the hexagon.</returns>
        private Hexagon HexNeighbor(Hexagon hex, int direction)
        {
            if (hex == null)
            {
                throw new ArgumentNullException($"The {nameof(hex)} must not be null.");
            }

            return this.Hex_Add(hex, this.HexDirection(direction));
        }
    }
}
