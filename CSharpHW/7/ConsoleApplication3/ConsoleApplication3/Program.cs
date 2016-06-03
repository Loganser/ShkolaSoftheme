using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication3
{
    class Program
    {
        class Point
        {
            public int x { get; set; }
            public int y { get; set; }
            public Point()
            {
                x = 0;
                y = 0;
            }
            public Point(int _x, int _y)
            {
                x = _x;
                y = _y;
            }
        }

        enum ShapeType {Dot, Line, Triangle, Square}

        class shapeDescriptor
        {
            public Point[] points;
            public ShapeType type; //without checking figure conditions (assuming points for square definitely form a square)
            public shapeDescriptor(Point p1)
            {
                points = new Point[1];
                points[0] = p1;
                type = ShapeType.Dot;
            }
            public shapeDescriptor(Point p1, Point p2)
            {
                points = new Point[2];
                points[0] = p1; points[1] = p2;
                type = ShapeType.Line;
            }
            public shapeDescriptor(Point p1, Point p2, Point p3)
            {
                points = new Point[3];
                points[0] = p1; points[1] = p2; points[2] = p3;
                type = ShapeType.Triangle;
            }
            public shapeDescriptor(Point p1, Point p2, Point p3, Point p4) //better to use params Point[]...
            {
                points = new Point[4];
                points[0] = p1; points[1] = p2; points[2] = p3; points[3] = p4;
                type = ShapeType.Square;
            }

        }

        static void Main(string[] args)
        {
            Point p1 = new Point(0, 0);
            Point p2 = new Point(5, 5);
            shapeDescriptor shape1 = new shapeDescriptor(p1);
            shapeDescriptor shape2 = new shapeDescriptor(p1, p2);

            Console.WriteLine(shape1.type.ToString());
            Console.WriteLine(shape2.type.ToString());
            Console.ReadLine();
        }
    }
}
