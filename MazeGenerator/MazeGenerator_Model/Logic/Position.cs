﻿namespace MazeGenerator_Model.Logic
{
    using System;

    public class Position
    {
        public Position(double x, double y)
        {
            this.X = x;
            this.Y = y;
        }

        public double X
        {
            get;
            set;
        }

        public double Y
        {
            get;
            set;
        }
    }
}
