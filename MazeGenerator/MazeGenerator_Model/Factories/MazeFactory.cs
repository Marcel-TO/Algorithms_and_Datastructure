namespace MazeGenerator_Model.Factories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using MazeGenerator_Model.Interfaces;
    using MazeGenerator_Model.Logic;

    public class MazeFactory
    {
        private List<Hexagon> directions;

        private IRandom random;

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

        public Maze CreateMaze(int size)
        {
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

        private List<Hexagon> RandomWalk(List<Hexagon> hexagons, int randomIndex, int size)
        {
            List<Hexagon> walk = new List<Hexagon> { hexagons[randomIndex] };

            while (true)
            {
                int direction = this.random.Random(0, 6);
                Hexagon neighbor = this.HexNeighbor(walk[walk.Count - 1], direction);

                // Check if neighbor is in range.
                if (neighbor.Q <= size && neighbor.R <= size && neighbor.S <= size && neighbor.Q >= -size && neighbor.R >= -size && neighbor.S >= -size)
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

        private int InverseDirection(int direction)
        {
            direction += 3;

            if (direction >= this.directions.Count)
            {
                direction -= this.directions.Count;
            }

            return direction;
        }

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

        private Hexagon HexDirection(int direction)
        {
            if (direction < 0 || direction >= this.directions.Count)
            {
                throw new ArgumentOutOfRangeException($"The {nameof(direction)} must be between the directions 0 - {this.directions.Count - 1}");
            }

            return this.directions[direction];
        }

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
