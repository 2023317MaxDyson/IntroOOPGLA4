using System.Reflection;
using System.Security.Cryptography.X509Certificates;

namespace Activity_04MaxDyson
{
    public class Point
    {
        public double x;
        public double y;

    }



    public abstract class Shape
    {
        public Point Centre { get; set; } = new Point();

        public Shape(double x, double y)
        {
            //set Center point to parameter values

           Centre.x = x;
            Centre.y = y;

        }

        public void Move(double dx, double dy)
        {
            //increment center to dx and dy amount.

            Centre.x += dx;
            Centre.y += dy;
           
        }

        public abstract double GetArea();
        public abstract double GetPerimeter();

        public bool IsSmallerThan(Shape other)
        {
            // return true if this objects's area is smaller that parameter objects's area.
            // return flase otherwise.

           

            if (GetArea() <  other.GetArea() ) {


                return true;
            }
          


            return false;

        }
    }

    public class Rectangle : Shape
    {

        //To Do

        // Width and Height Properties 

        public double _width;
        public double _height;


        //Create public Rectangle constructor 
        public Rectangle (double x, double y, double width, double height) : base (x, y)
        {
            _width = width;
            _height = height;
        }

        public override double GetArea()
        {
            // Width x Height 

            return _width * _height;


        }

        public override double GetPerimeter()
        {

            // Add all sides (width + width) + (height + height)


            return (_width + _width) + (_height + _height);


        }

    }

    public class Circle : Shape
    {
        //To Do


        // Radius Property

        public double _radius;

        // Create public Circle  constructor

        public Circle(double x, double y, double radius) : base(x, y)
        {
            _radius = radius;

        }


        public override double GetArea()
        {

            // Pi π = 3.14159265358979
            // Pi π x (radius x radius)

            double π = 3.14159265358979;

            return π * (_radius * _radius);


        }


        public override double GetPerimeter()
        {
            // Circumference is the name for the perimeter of a circle 
            // Diameter is 2 mulitply by the radius
            // Circumference = Diameter x pi π
            // Pi π = 3.14159265358979


            double π = 3.14159265358979;

            double Diameter = _radius * 2.00;

            double Circumference = Diameter * π;

            return Circumference; 

           


        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            int shapeCount = Int32.Parse(Console.ReadLine());
            var shapes = new Shape[shapeCount];
            for (int i = 0; i < shapeCount; ++i)
            {
                var cmd = Console.ReadLine().Split();
                if (cmd[0] == "rectangle")
                {
                    double x = double.Parse(cmd[1]);
                    double y = double.Parse(cmd[2]);
                    double width = double.Parse(cmd[3]);
                    double height = double.Parse(cmd[4]);
                    shapes[i] = new Rectangle(x, y, width, height);
                }
                else if (cmd[0] == "circle")
                {
                    double x = double.Parse(cmd[1]);
                    double y = double.Parse(cmd[2]);
                    double radius = double.Parse(cmd[3]);
                    shapes[i] = new Circle(x, y, radius);
                }
            }
            string input;
            while ((input = Console.ReadLine()) != "exit")
            {
                var cmd = input.Split();
                if (cmd[0] == "move")
                {
                    int index = int.Parse(cmd[1]);
                    double dx = double.Parse(cmd[2]);
                    double dy = double.Parse(cmd[3]);
                    shapes[index].Move(dx, dy);
                }
                else if (cmd[0] == "centre")
                {
                    int index = int.Parse(cmd[1]);
                    Console.WriteLine(shapes[index].Centre.x + ", " + shapes[index].Centre.y);
                }
                else if (cmd[0] == "area")
                {
                    int index = int.Parse(cmd[1]);
                    Console.WriteLine(shapes[index].GetArea());
                }
                else if (cmd[0] == "perimeter")
                {
                    int index = int.Parse(cmd[1]);
                    Console.WriteLine(shapes[index].GetPerimeter());
                }
                else if (cmd[0] == "issmaller")
                {
                    int index1 = int.Parse(cmd[1]);
                    int index2 = int.Parse(cmd[2]);
                    Console.WriteLine(shapes[index1].IsSmallerThan(shapes[index2]));
                }
            }
        }
    }
}
