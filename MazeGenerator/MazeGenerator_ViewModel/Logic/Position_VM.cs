namespace MazeGenerator_ViewModel.Logic
{
    using System;

    public class Position_VM
    {
        private int x;

        private int y;

        public Position_VM(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        public int X
        {
            get
            {
                return this.x;
            }

            private set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException($"The {nameof(this.x)} must not be null.");
                }

                this.x = value;
            }
        }

        public int Y
        {
            get
            {
                return this.y;
            }

            private set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException($"The {nameof(this.y)} must not be null.");
                }

                this.y = value;
            }
        }
    }
}
