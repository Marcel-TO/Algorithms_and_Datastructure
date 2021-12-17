namespace MazeGenerator_ViewModel.Logic
{
    using MazeGenerator_Model.Logic;
    using System;
    using System.Collections.Generic;

    public class Logic_VM
    {
        public Orientation layout_pointy;

        public Orientation layout_flat;

        public Logic_VM()
        {
            this.layout_pointy = new Orientation(new List<double> { Math.Sqrt(3.0), Math.Sqrt(3.0) / 2.0, 0.0, 3.0 / 2.0 },
                                                 new List<double> { 3.0 / 2.0, 0.0, Math.Sqrt(3.0) / 2.0, Math.Sqrt(3.0) },
                                                 0.5);

            this.layout_flat = new Orientation(new List<double> { 3.0 / 2.0, 0.0, Math.Sqrt(3.0) / 2.0, Math.Sqrt(3.0) },
                                               new List<double> { 2.0 / 3.0, 0.0, -1.0 / 3.0, Math.Sqrt(3.0) / 3.0 },
                                               0.0);
        }

        public Position HexToPixel(Layout layout, Hexagon hex)
        {
            var orientation = layout.Orientation;

            double x = (orientation.ForwardMatrix[0] * hex.Q + orientation.ForwardMatrix[1] * hex.R) * layout.Size.X;
            double y = (orientation.ForwardMatrix[2] * hex.Q + orientation.ForwardMatrix[3] * hex.R) * layout.Size.Y;

            return new Position(x + layout.Origin.X, y + layout.Origin.Y);
        }

        public List<Position> PolygonCorners(Layout layout, Hexagon hex)
        {
            List<Position> corners = new List<Position>();

            Position center = HexToPixel(layout, hex);

            for (int i = 0; i < 6; i++)
            {
                Position offset = HexCornerOffset(layout, i);
                corners.Add(new Position(center.X + offset.X, center.Y + offset.Y));
            }

            return corners;
        }

        public Position HexCornerOffset(Layout layout, int corner)
        {
            Position size = layout.Size;
            double angle = 2.0 * Math.PI * (layout.Orientation.StartAngle + corner) / 6;

            var cos = Math.Cos(angle);
            var sin = Math.Sin(angle);

            return new Position(size.X * Math.Cos(angle), size.Y * Math.Sin(angle));
        }
    }
}
