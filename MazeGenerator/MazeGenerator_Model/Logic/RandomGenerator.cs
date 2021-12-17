namespace MazeGenerator_Model.Logic
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using MazeGenerator_Model.Interfaces;

    [ExcludeFromCodeCoverage]
    public class RandomGenerator : IRandom
    {
        private Random random;

        public RandomGenerator()
        {
            this.random = new Random();
        }

        public int Random(int min, int max)
        {
            return this.random.Next(min, max);
        }
    }
}
