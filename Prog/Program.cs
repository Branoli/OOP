using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace Хоар
{
    class Program
    {
        //=========CLASS============
        public class Point
        {
            public double x;
            public double y;
            public Point(int x, int y)
            {
                this.x = x;
                this.y = y;
            }
        }
        public class Edge
        {
            public Point q;
            public Point w;
            public Edge(Point a, Point b)
            {
                this.q = a;
                this.w = b;
            }
        }
        public class Triangle
        {
            public Point a;
            public Point b;
            public Point c;
            public Triangle(Point a, Point b, Point c)
            {
                this.a = a;
                this.b = b;
                this.c = c;
            }
        }
        //==========METHODS=========
        public static double Distance(Edge a)
        {
            return Math.Sqrt(Math.Pow(a.w.x - a.q.x, 2) + Math.Pow(a.w.y - a.q.y, 2));
        }
        public static double Area(Triangle ABC)
        {
            double q, p;
            q = Math.Sqrt(Math.Pow(ABC.b.x - ABC.a.x, 2) + Math.Pow(ABC.b.y - ABC.a.y, 2));
            q += Math.Sqrt(Math.Pow(ABC.c.x - ABC.b.x, 2) + Math.Pow(ABC.c.y - ABC.b.y, 2));
            q += Math.Sqrt(Math.Pow(ABC.a.x - ABC.c.x, 2) + Math.Pow(ABC.a.y - ABC.c.y, 2));
            q = q / 2;
            p = q;
            return q = Math.Sqrt(p * (p - Math.Sqrt(Math.Pow(ABC.b.x - ABC.a.x, 2) + Math.Pow(ABC.b.y - ABC.a.y, 2))) * (p - Math.Sqrt(Math.Pow(ABC.c.x - ABC.b.x, 2) + Math.Pow(ABC.c.y - ABC.b.y, 2))) * (p - Math.Sqrt(Math.Pow(ABC.a.x - ABC.c.x, 2) + Math.Pow(ABC.a.y - ABC.c.y, 2))));
            
        }
        public static double Perimeter(Triangle ABC)
        {
            double q;
            q = Math.Sqrt(Math.Pow(ABC.b.x - ABC.a.x, 2) + Math.Pow(ABC.b.y - ABC.a.y, 2));
            q += Math.Sqrt(Math.Pow(ABC.c.x - ABC.b.x, 2) + Math.Pow(ABC.c.y - ABC.b.y, 2));
            return q += Math.Sqrt(Math.Pow(ABC.a.x - ABC.c.x, 2) + Math.Pow(ABC.a.y - ABC.c.y, 2));

        }
        public static double Isosceles(Triangle ABC)
        {
            double q, w, e;
            q = Math.Sqrt(Math.Pow(ABC.b.x - ABC.a.x, 2) + Math.Pow(ABC.b.y - ABC.a.y, 2));
            w = Math.Sqrt(Math.Pow(ABC.c.x - ABC.b.x, 2) + Math.Pow(ABC.c.y - ABC.b.y, 2));
            e = Math.Sqrt(Math.Pow(ABC.a.x - ABC.c.x, 2) + Math.Pow(ABC.a.y - ABC.c.y, 2));
            if (q == w || q == e || w == q || w == e || e == q || e == w)
            {
                int f = 1;
                return f;
            }
            else
            {
                int f = 0;
                return f;
            }

        }
        public static double Right(Triangle ABC)
        {
            double q, w, e;
            q = Math.Sqrt(Math.Pow(ABC.b.x - ABC.a.x, 2) + Math.Pow(ABC.b.y - ABC.a.y, 2));
            w = Math.Sqrt(Math.Pow(ABC.c.x - ABC.b.x, 2) + Math.Pow(ABC.c.y - ABC.b.y, 2));
            e = Math.Sqrt(Math.Pow(ABC.a.x - ABC.c.x, 2) + Math.Pow(ABC.a.y - ABC.c.y, 2));
            if (Math.Pow(q,2) == Math.Pow(w,2)+Math.Pow(e,2))
            {
                double i = 1;
                return i;
            }
            if (Math.Pow(w,2) == Math.Pow(q,2)+Math.Pow(e,2))
            {
                double i = 1;
                return i;
            }
            if (Math.Pow(e, 2) == Math.Pow(q, 2) + Math.Pow(w, 2))
            {
                double i = 1;
                return i;
            }
            else
            {
                double i = 0;
                return i;
            }

        }
        //==========================
        static void Main(string[] args)
        {
            //===================---------  
            Point a = new Point(5, 1);
            Point b = new Point(1, 1);
            Point c = new Point(1, 7);

            Edge AB = new Edge(a, b);
            Edge BC = new Edge(b, c);
            Edge CA = new Edge(c, a);

            Triangle ABC = new Triangle(a, b, c);
            //===================---------   
            Console.WriteLine(Distance(AB));
            Console.WriteLine(Distance(BC));
            Console.WriteLine(Distance(CA));

            Console.WriteLine(Perimeter(ABC));
            Console.WriteLine(Area(ABC));

            if (Isosceles(ABC) == 1) Console.WriteLine("Isosceles");
            else Console.WriteLine("Not Isosceles");

            if (Right(ABC) == 1) Console.WriteLine("Right");
            else Console.WriteLine("Not Right");




            Console.ReadKey();
        }
    }
}

