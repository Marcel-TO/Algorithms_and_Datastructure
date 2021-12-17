namespace MazeTester
{
    using MazeGenerator_Model.Logic;
    using System;
    using System.Collections.Generic;

    public class ConsoleOutput
    {
        public void PrintHexes(List<Hexagon> hexagons)
        {
            int centerX = Console.WindowWidth / 2;
            int centerY = Console.WindowHeight / 2;

            foreach (Hexagon hex in hexagons)
            {
                var pos = this.Pointy_HexToPixel(hex);
                Console.SetCursorPosition(centerX + pos.Item1, centerY + pos.Item2);
                Console.Write("H");
            }
        }

        private (int, int) Flat_HexToPixel(Hexagon hex)
        {
            var x = (3.0 / 2) * hex.Q;
            var y = (Math.Sqrt(3) / 2) * hex.Q + Math.Sqrt(3) * hex.R;

            return (Convert.ToInt32(x), Convert.ToInt32(y));
        }

        private (int, int) Pointy_HexToPixel(Hexagon hex)
        {
            var x = (Math.Sqrt(3) / 2) * hex.Q + Math.Sqrt(3) * hex.R;
            var y = (3.0 / 2) * hex.Q;

            return (Convert.ToInt32(x), Convert.ToInt32(y));
        }
    }
}
