namespace MazeGenerator_Model.Logic
{
    using System;
    using System.Collections.Generic;

    public class Hexagon
    {
        private int q;

        private int r;

        private int s;

        private bool[] isOpen;

        private int direction;

        public Hexagon(int q, int r, int s)
        {
            this.Q = q;
            this.R = r;
            this.S = s;
            this.Direction = 0;
            this.IsChosen = false;

            this.IsOpen = new bool[]
            {
                false,
                false,
                false,
                false,
                false,
                false
            };
        }

        public int Q
        {
            get;
            private set;
        }

        public int R
        {
            get;
            private set;
        }

        public int S
        {
            get;
            private set;
        }

        public bool[] IsOpen
        {
            get
            {
                return this.isOpen;
            }

            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException($"The {nameof(this.isOpen)} must not be null.");
                }
                else if (value.Length != 6)
                {
                    throw new ArgumentOutOfRangeException($"The {nameof(this.isOpen)} must not be 6.");
                }

                this.isOpen = value;
            }
        }

        public int Direction
        {
            get
            {
                return this.direction;
            }

            set
            {
                if (value < 0 || value >= 6)
                {
                    throw new ArgumentOutOfRangeException($"The {nameof(this.direction)} must be between 0-5.");
                }

                this.direction = value;
            }
        }

        public bool IsChosen
        {
            get;
            set;
        }
    }
}
