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
            public int x;
            public int y;
            public Point(int x, int y)
            {
                this.x = x;
                this.y = y;
            }
        }
        public class Edge
        {
            public Point a;
            public Point b;
            public Edge(Point a, Point b)
            {
                this.a = a;
                this.b = b;
            }
            //======Methods-----
            public static int CheckOnBulge(Edge[] edges)
            {
                int y = 0;
                for (int i = 0; i < edges.Length; i++)
                {
                    y = (edges[i].a.x * edges[i].b.y) - (edges[i].a.y * edges[i].b.x);
                    if (y < 0) break;
                }
                if (y < 0) return 0;
                else return 1;
            }
            public static int Distance(Point a, Point b)
            {
                int q = 0;
                q = (int)Math.Sqrt(Math.Pow(b.x - a.x, 2) + Math.Pow(b.y - a.y, 2));
                return q;
            }
        }
        public class Triangle
        {
            public Point[] a;
            public Triangle(Point[] points)
            {
                this.a = new Point[points.Length];
                for (int i = 0; i < points.Length; i++)
                {
                    this.a[i] = points[i];
                }
            }
            //======Methods-----
            public static double AreaOfTriangleForPolygon(Triangle ABC)
            {
                int[] mas = new int[ABC.a.Length];
                double SemiPerimeter = 0;
                double c = 1, f = 0;
                for (int i = 0; i < ABC.a.Length; i++)
                {
                    if (i == ABC.a.Length - 1)
                    {
                        mas[i] = Edge.Distance(ABC.a[i - 2], ABC.a[i]);
                        SemiPerimeter += mas[i];
                    }
                    else
                    {
                        mas[i] = Edge.Distance(ABC.a[i], ABC.a[i + 1]);
                        SemiPerimeter += mas[i];
                    }
                }
                SemiPerimeter = SemiPerimeter / 2;
                for (int i = 0; i < mas.Length; i++)
                {
                    f = SemiPerimeter - mas[i];
                    c = c * f;
                }
                SemiPerimeter *= c;
                return c;
            }
            public static double AreaOfTriangle(Triangle ABC)
            {
                int[] mas = new int[ABC.a.Length];
                double SemiPerimeter = 0;
                double c = 1, f = 0;
                for (int i = 0; i < ABC.a.Length; i++)
                {
                    if (i == ABC.a.Length - 1)
                    {
                        mas[i] = Edge.Distance(ABC.a[i - 2], ABC.a[i]);
                        SemiPerimeter += mas[i];
                    }
                    else
                    {
                        mas[i] = Edge.Distance(ABC.a[i], ABC.a[i + 1]);
                        SemiPerimeter += mas[i];
                    }
                }
                SemiPerimeter = SemiPerimeter / 2;
                for (int i = 0; i < mas.Length; i++)
                {
                    f = SemiPerimeter - mas[i];
                    c = c * f;
                }
                SemiPerimeter *= c;
                return c;
            }
            public static int PerimeterOfTriangle(Triangle ABC)
            {
                int x = 0;
                for (int i = 0; i < ABC.a.Length; i++)
                {
                    if (i == ABC.a.Length - 1) x += Edge.Distance(ABC.a[i - 2], ABC.a[i]);
                    else x += Edge.Distance(ABC.a[i], ABC.a[i + 1]);
                }
                return x;
            }
            public static double CheckOfRight(Triangle[] ABC)
            {
                double x = 0, z = 0;
                for (int i = 0; i < ABC.Length; i++)
			    {
			        if (Math.Pow(Edge.Distance(ABC[i].a[0], ABC[i].a[1]), 2) == (Math.Pow(Edge.Distance(ABC[i].a[1], ABC[i].a[2]), 2)) + (Math.Pow(Edge.Distance(ABC[i].a[2], ABC[i].a[0]), 2)))
                    {
                        x += AreaOfTriangle(ABC[i]);
                        z++;
                    }
                    if (Math.Pow(Edge.Distance(ABC[i].a[1], ABC[i].a[2]), 2) == (Math.Pow(Edge.Distance(ABC[i].a[0], ABC[i].a[1]), 2)) + (Math.Pow(Edge.Distance(ABC[i].a[2], ABC[i].a[0]), 2)))
                    {
                        x += AreaOfTriangle(ABC[i]);
                        z++;
                    }
                    if (Math.Pow(Edge.Distance(ABC[i].a[2], ABC[i].a[0]), 2) == (Math.Pow(Edge.Distance(ABC[i].a[0], ABC[i].a[1]), 2)) + (Math.Pow(Edge.Distance(ABC[i].a[1], ABC[i].a[2]), 2)))
                    {
                        x += AreaOfTriangle(ABC[i]);
                        z++;
                    }
			    }
                if (x > 0) return x / z;
                else return 0;

                
            }
            public static int CheckOfIsosceles(Triangle[] ABC)
            {
                int x = 0, z = 0, y = 0;
                for (int i = 0; i < ABC.Length; i++)
                {
                    if (Edge.Distance(ABC[i].a[0], ABC[i].a[1]) == Edge.Distance(ABC[i].a[1], ABC[i].a[2]) || Edge.Distance(ABC[i].a[1], ABC[i].a[2]) == Edge.Distance(ABC[i].a[2], ABC[i].a[0]) || Edge.Distance(ABC[i].a[2], ABC[i].a[0]) == Edge.Distance(ABC[i].a[0], ABC[i].a[1]))
                    {
                        x = PerimeterOfTriangle(ABC[i]);
                        z += x;
                        y++;
                    }
                }
                if (z > 0) return z /= y;
                else return 0;
            }
        }
        public class Polygon
        {
            public Triangle[] ABC;
            public Edge[] AB;
            public Polygon(Triangle[] tringles, Edge[] edges)
            {
                this.AB = new Edge[edges.Length];
                this.ABC = new Triangle[tringles.Length];
                for (int i = 0; i < tringles.Length; i++)
                {
                    this.ABC[i] = tringles[i];
                }
                for (int i = 0; i < edges.Length; i++)
                {
                    this.AB[i] = edges[i];
                }
            }
            //======Methods-----
            public void AreaOfPolygon(Triangle[] ABC)
            {
                double q = 0, z = 0;
                for (int i = 0; i < ABC.Length; i++)
                {
                    q = Triangle.AreaOfTriangleForPolygon(ABC[i]);
                    z += q;
                }
                Console.WriteLine("Площадь фигуры = {0}", z);
            }
            public void Perimeter(Edge[] AB)
            {
                int q, PerimeterOfPolygon = 0;
                for (int i = 0; i < AB.Length; i++)
                {
                    q = Edge.Distance(AB[i].a, AB[i].b);
                    PerimeterOfPolygon += q;
                }
                Console.WriteLine("Периметр многоугольника = {0}", PerimeterOfPolygon);
            }
            public void Distance(Edge[] AB)
            {
                int q, z = 0;
                for (int i = 0; i < AB.Length; i++)
                {
                    z++;
                    q = Edge.Distance(AB[i].a, AB[i].b);
                    Console.WriteLine("{0}ое ребро = {1}", z, q);
                }
            }
        }
        public static Point[] GenerationOfPoints(Point[] points, int x)
        {
            Random gen = new Random();
            if (x == 0)
            {
                for (int i = 0; i < points.Length; i++)
                {
                    points[i] = new Point(gen.Next(0, 10), gen.Next(0, 10));

                }
                if (points[2].x == points[1].x && points[2].y == points[1].y || points[2].x == points[0].x && points[2].y == points[0].y)
                {
                    x++;
                    GenerationOfPoints(points, x);
                }
            }
            else
            {
                if (points[2].x == points[1].x && points[2].y == points[1].y || points[2].x == points[0].x && points[2].y == points[0].y)
                {
                    points[2] = new Point(gen.Next(0, 10), gen.Next(0, 10));
                    x++;
                    GenerationOfPoints(points, x);
                }
            }
            return points;
        }
        public static Edge[] GenerationOfEdge(Edge[] edges, Point[] points, int h, int c)
        {
            Random gen = new Random();
            int z = 0;
            if (h == 0)
            {
                for (int k = 0; k < edges.Length; k++)
                {
                    if (k == points.Length - 2)
                    {
                        edges[k] = new Edge(points[0], points[k + 1]);
                        break;
                    }
                    else edges[k] = new Edge(points[k], points[k + 1]);
                }
                return edges;
            }
            else
            {
                points[0] = points[1];
                points[1] = points[2];
                points[2] = new Point(gen.Next(0, 10), gen.Next(0, 10));
                for (int k = c; k < edges.Length; )
                {
                    z++;
                    if (k != 2)
                    {
                        edges[k] = new Edge(points[0], points[2]);
                        break;
                    }
                    else
                    {
                        edges[k] = new Edge(points[0], points[2]);
                        break;
                    }
                }
                return edges;
            }

        }

        static void Main(string[] args)
        {
            Console.Write("Скольки угольник вас интерисует: ");
            int q = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();
            //+++++++++++++++Massiv Polygon++++++++++++++++++++++
            Polygon[] N = new Polygon[1];
            Triangle[] abc = new Triangle[q - 2];
            Point[] points = new Point[3];
            Edge[] edges = new Edge[q];
            int x = 0, c = 2;
            for (int p = 0; p < N.Length; p++)
            {
                    for (int h = 0; h < abc.Length; h++)
                    {
                        if (h == 0)
                        {
                            GenerationOfPoints(points, x);
                            GenerationOfEdge(edges, points, h, c);
                            abc[h] = new Triangle(points);
                        }
                        else
                        {
                            GenerationOfEdge(edges, points, h, c);
                            abc[h] = new Triangle(points);
                            c++;
                        }
                    }
                    edges[edges.Length - 1] = new Edge(edges[edges.Length - 2].b, edges[edges.Length - 3].b);
                    N[p] = new Polygon(abc, edges);
            }
            //==========OUTPUT==============================
            for (int i = 0; i < N.Length; i++)
            {
                if (N[i].ABC.Length > 1)
                {
                    if (Triangle.CheckOfIsosceles(N[i].ABC) > 0) Console.WriteLine("Средний периметр треугольников в многоугольнике = {0}", Triangle.CheckOfIsosceles(N[i].ABC));
                    else Console.WriteLine("В многоугольнике нет равнобедренных треугольников");
                    if (Triangle.CheckOfRight(N[i].ABC) > 0) Console.WriteLine("Средняя площадь треугольников в многоугольнике = {0}", Triangle.CheckOfRight(N[i].ABC));
                    else Console.WriteLine("В многоугольнике нет прямоугольных треугольников");
                }
                N[i].Distance(N[i].AB);
                N[i].AreaOfPolygon(N[i].ABC);
                N[i].Perimeter(N[i].AB);
                Console.WriteLine("====-----------------====");
            }
            Console.ReadKey();
        }
    }
}