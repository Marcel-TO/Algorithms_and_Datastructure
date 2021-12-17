namespace MazeGenerator_Model.Logic
{
    using System;
    using System.Collections.Generic;

    public class Orientation
    {
        private List<double> forwardMatrix;

        private List<double> inverseMatrix;

        public Orientation(List<double> forwardMatrix, List<double> inverseMatrix, double startingAngle)
        {
            this.ForwardMatrix = forwardMatrix;
            this.InverseMatrix = inverseMatrix;
            this.StartAngle = startingAngle;
        }

        public List<double> ForwardMatrix
        {
            get
            {
                return this.forwardMatrix;
            }

            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException($"The {nameof(this.forwardMatrix)} must not be null.");
                }
                else if (value.Count != 4)
                {
                    throw new ArgumentOutOfRangeException($"The {nameof(this.forwardMatrix)} must contain 4 values.");
                }

                this.forwardMatrix = value;
            }
        }

        public List<double> InverseMatrix
        {
            get
            {
                return this.inverseMatrix;
            }

            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException($"The {nameof(this.inverseMatrix)} must not be null.");
                }
                else if (value.Count != 4)
                {
                    throw new ArgumentOutOfRangeException($"The {nameof(this.inverseMatrix)} must contain 4 values.");
                }

                this.inverseMatrix = value;
            }
        }

        public double StartAngle
        {
            get;
            private set;
        }
    }
}
