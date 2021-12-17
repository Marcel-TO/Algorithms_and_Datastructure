namespace MazeGenerator_ViewModel.Logic
{
    using System;
    using System.Collections.Generic;

    public class Maze_VM
    {
        private List<Hexagon_VM> hexagonVMs;

        public Maze_VM(List<Hexagon_VM> hexagons)
        {
            this.HexagonVMs = hexagons;
        }

        public List<Hexagon_VM> HexagonVMs
        {
            get
            {
                return this.hexagonVMs;
            }

            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException($"The {nameof(this.hexagonVMs)} must not be null.");
                }

                this.hexagonVMs = value;
            }
        }
    }
}
