namespace StructsApp
{
    public struct Point
    {
        public double _x;
        public double _y;

        public double X { get => _x; set => _x = value; }
        public double Y { get => _y; set => _y = value; }

        public Point(double x, double y)
        {
            X = x;
            Y = y;
        }

        public double DistanceTo(Point other)
        {
            double dx = X - other.X;
            double dy = Y - other.Y;

            return Math.Sqrt(dx * dx + dy * dy);
        }

        public void Display()
        {
            Console.WriteLine($"Point: ({X},{Y})");
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Point p1 = new Point(10, 20);
            p1.Display();

            Point p2;
            p2._x = 5;
            p2._y = 10;
            p2.Display();

            double distance = p1.DistanceTo(p2);
            Console.WriteLine($"Distance from p1 to p2: {distance:F2}");

            Point p3 = p1; // Value is copied from p1 to p3, because structs are value type
                           // with classes p3 would point to p1's memory adress (p3 is a reference to p1) and thus they would share the same object

            p3._x = 22;
            p3.Display();
            p1.Display();
        }
    }
}
