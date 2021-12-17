namespace MazeGenerator_Model.Logic
{
    using System;

    public class Layout
    {
        private Orientation orientation;

        private Position size;

        private Position origin;

        public Layout(Orientation orientation, Position size, Position origin)
        {
            this.Orientation = orientation;
            this.Size = size;
            this.Origin = origin;
        }

        public Orientation Orientation
        {
            get
            {
                return this.orientation;
            }

            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException($"The {nameof(this.orientation)} must not be null.");
                }

                this.orientation = value;
            }
        }

        public Position Size
        {
            get
            {
                return this.size;
            }

            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException($"The {nameof(this.size)} must not be null.");
                }

                this.size = value;
            }
        }

        public Position Origin
        {
            get
            {
                return this.origin;
            }

            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException($"The {nameof(this.origin)} must not be null.");
                }

                this.origin = value;
            }
        }
    }
}
