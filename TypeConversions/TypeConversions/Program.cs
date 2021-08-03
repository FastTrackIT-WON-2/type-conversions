using System;

namespace TypeConversions
{
    class Program
    {
        static void Main(string[] args)
        {
            Point p1 = new Point(100, 200);
            string coords = p1;
            Console.WriteLine(coords);

            Point p2 = (Point)coords;
            Console.WriteLine($"Point: X={p2.X}, Y={p2.Y}");

            Point p3 = p1 + p2;
            Console.WriteLine($"Point Sum: X={p3.X}, Y={p3.Y}");
        }
    }
}
