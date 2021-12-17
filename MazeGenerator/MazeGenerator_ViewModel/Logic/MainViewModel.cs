namespace MazeGenerator_ViewModel.Logic
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using MazeGenerator_Model.Factories;
    using MazeGenerator_Model.Logic;

    public class MainViewModel
    {
        private int size;

        public MainViewModel()
        {
            this.Size = 10;
            this.IsFlatLayout = true;

            this.Hexagons = this.TestDrawing();
        }

        public int Size
        {
            get
            {
                return this.size;
            }

            set
            {
                if (value < 1)
                {
                    throw new ArgumentOutOfRangeException($"The {nameof(this.size)} must be at least 1.");
                }

                this.size = value;
            }
        }

        public List<Hexagon_VM> Hexagons
        {
            get;
            set;
        }

        public bool IsFlatLayout
        {
            get;
            set;
        }

        public List<Hexagon_VM> TestDrawing()
        {
            MazeFactory factory = new MazeFactory(new RandomGenerator());
            Logic_VM logic = new Logic_VM();
            Maze maze = factory.CreateMaze(1);

            List<Hexagon_VM> hexagonVMs = new List<Hexagon_VM>();

            for (int i = 0; i < maze.Hexagons.Count; i++)
            {
                hexagonVMs.Add(new Hexagon_VM(maze.Hexagons[i], logic.HexToPixel(new Layout(logic.layout_flat, new Position(100, 100), new Position(800, 500)), maze.Hexagons[i])));
            }

            return hexagonVMs;
        }
    }
}
