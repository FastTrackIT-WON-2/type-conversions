using System;

namespace TypeConversions
{
    public class Point
    {
        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        public int X { get; }

        public int Y { get; }

        public static implicit operator string(Point p)
        {
            return $"({p.X},{p.Y})";
        }

        public static explicit operator Point(string coords)
        {
            if (string.IsNullOrWhiteSpace(coords))
            {
                throw new FormatException();
            }

            string sanitized = coords.Replace("(", string.Empty)
                                     .Replace(")", string.Empty);

            string[] parts = sanitized.Split(",", StringSplitOptions.RemoveEmptyEntries);
            if (parts.Length != 2)
            {
                throw new FormatException();
            }

            string xCoord = parts[0];
            string yCoord = parts[1];

            if (!int.TryParse(xCoord, out int xCoordAsInt))
            {
                throw new FormatException();
            }

            if (!int.TryParse(yCoord, out int yCoordAsInt))
            {
                throw new FormatException();
            }

            return new Point(xCoordAsInt, yCoordAsInt);
        }

        public static Point operator +(Point p1, Point p2)
        {
            return new Point(p1.X + p2.X, p1.Y + p2.Y);
        }
    }
}
