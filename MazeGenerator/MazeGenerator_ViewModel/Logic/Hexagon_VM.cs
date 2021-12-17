namespace MazeGenerator_ViewModel.Logic
{
    using System;
    using System.Collections.Generic;
    using MazeGenerator_Model.Logic;

    public class Hexagon_VM
    {
        private Hexagon hexagon;

        private Position position;

        public Hexagon_VM(Hexagon hexagon, Position position)
        {
            this.Hexagon = hexagon;
            this.Position = position;
        }

        public Hexagon Hexagon
        {
            get
            {
                return this.hexagon;
            }

            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException($"The {nameof(this.hexagon)} must not be null.");
                }

                this.hexagon = value;
            }
        }

        public Position Position
        {
            get
            {
                return this.position;
            }

            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException($"The {nameof(this.position)} must not be null.");
                }

                this.position = value;
            }
        }
    }
}
