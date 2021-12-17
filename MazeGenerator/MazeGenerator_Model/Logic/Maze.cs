namespace MazeGenerator_Model.Logic
{
    using System;
    using System.Collections.Generic;

    public class Maze
    {
        private int size;

        private List<Hexagon> hexagons;

        public Maze(List<Hexagon> hexagons, int size)
        {
            this.Hexagons = hexagons;
            this.Size = size;
        }

        public int Size
        {
            get
            {
                return this.size;
            }

            private set
            {
                if (value < 1)
                {
                    throw new ArgumentOutOfRangeException($"The {nameof(this.size)} must not be null.");
                }

                this.size = value;
            }
        }

        public List<Hexagon> Hexagons
        {
            get
            {
                return this.hexagons;
            }

            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException($"The {nameof(this.hexagons)} must not be null.");
                }

                this.hexagons = value;
            }
        }
    }
}
