namespace MazeTester
{
    using MazeGenerator_Model.Factories;
    using MazeGenerator_Model.Logic;
    using System;

    public class Program
    {
        static void Main(string[] args)
        {
            MazeFactory factory = new MazeFactory(new RandomGenerator());
            Maze maze = factory.CreateMaze(2);

            ConsoleOutput logger = new ConsoleOutput();
            logger.PrintHexes(maze.Hexagons);
        }
    }
}
