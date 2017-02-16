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
            public void AREA(Triangle[] ABC)
            {

                double v = 0, d = 0, SumPerimeter = 0;
                for (int i = 0; i < ABC.Length; i++)
                {
                    int[] mas = new int[3];
                    int[] CheckPerimeter = new int[3];
                    int q;
                    double c = 1, p = 0, f = 0, m = 0, OneOrZeroOfPerimeter = 0, Perimeter = 0;
                    for (int k = 0; k < ABC[i].a.Length; k++)
                    {
                        if (k == ABC[i].a.Length - 1)
                        {
                            q = (int)Math.Sqrt(Math.Pow(ABC[i].a[k - 2].x - ABC[i].a[k].x, 2) + Math.Pow(ABC[i].a[k - 2].y - ABC[i].a[k].y, 2));
                            mas[k] = q;
                            CheckPerimeter[k] = q;
                            p += q;
                            Perimeter += q;
                        }
                        else
                        {
                            q = (int)Math.Sqrt(Math.Pow(ABC[i].a[k + 1].x - ABC[i].a[k].x, 2) + Math.Pow(ABC[i].a[k + 1].y - ABC[i].a[k].y, 2));
                            mas[k] = q;
                            CheckPerimeter[k] = q;
                            p += q;
                            Perimeter += q;
                        }
                    }
                    p /= 2;
                    for (int k = 0; k < mas.Length; k++)
                    {
                        f = p - mas[k];
                        c = c * f;
                    }
                    p = p * c;
                    p = Math.Sqrt(p);
                    v += p;
                    m = Isosceles(mas);
                    OneOrZeroOfPerimeter = Right(CheckPerimeter);
                    if (m == 1) d += p;
                    if (OneOrZeroOfPerimeter == 1) SumPerimeter += p;

                }
                if (d != 0) Console.WriteLine("Площадь фигуры = {0} \nСредняя площадь прямоугольных треугольников в этом многоугольнике = {1}", v, d / 2);
                else Console.WriteLine("Площадь фигуры = {0}, в многоугольнике нет равнобедренных треугольников ", v);
                if (SumPerimeter != 0) Console.WriteLine("\nСредний периметр всех прямоугольных треугольников в этом многоугольнике = {0}", SumPerimeter / 2);
                else Console.WriteLine("==-==\nВ многоугольнике нет прямоугольных треугольников ");

            }
            public void Perimeter(Edge[] AB)
            {
                int q, PerimeterOfPolygon = 0;
                for (int i = 0; i < AB.Length; i++)
                {
                    q = (int)Math.Sqrt(Math.Pow(AB[i].b.x - AB[i].a.x, 2) + Math.Pow(AB[i].b.y - AB[i].a.y, 2));
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
                    q = (int)Math.Sqrt(Math.Pow(AB[i].b.x - AB[i].a.x, 2) + Math.Pow(AB[i].b.y - AB[i].a.y, 2));
                    Console.WriteLine("{0}ое ребро = {1}", z, q);
                }
            }
            public static int Right(int[] Edges)
            {
                if (Math.Pow(Edges[0], 2) == Math.Pow(Edges[0], 2) + Math.Pow(Edges[0], 2))
                {
                    int i = 1;
                    return i;
                }
                if (Math.Pow(Edges[1], 2) == Math.Pow(Edges[0], 2) + Math.Pow(Edges[2], 2))
                {
                    int i = 1;
                    return i;
                }
                if (Math.Pow(Edges[2], 2) == Math.Pow(Edges[0], 2) + Math.Pow(Edges[1], 2))
                {
                    int i = 1;
                    return i;
                }
                else
                {
                    int i = 0;
                    return i;

                }
            }
            public static int Isosceles(int[] Edges)
            {
                if (Edges[0] == Edges[1] || Edges[0] == Edges[2] || Edges[1] == Edges[2]) return 1;
                else return 0;
            }
        }
        public static Point[] GenerationOfPoints(Point[] points, int x)
        {
            Random gen = new Random();
            if (x == 0)
            {
                for (int i = 0; i < points.Length; i++)
                {
                    points[i] = new Point(gen.Next(10, 20), gen.Next(10, 20));

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
                    points[2] = new Point(gen.Next(10, 20), gen.Next(10, 20));
                    x++;
                    GenerationOfPoints(points, x);
                }
            }
            return points;
        }
        public static Edge[] GenerationOfEdge(Edge[] edges, Point[] points, int h, int c)
        {
            Random gen = new Random();
            int z = 1;
            if (h == 0)
            {
                for (int k = 0; k < edges.Length; k++)
                {
                    if (k == points.Length - 1)
                    {
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
                points[2] = new Point(gen.Next(0, 20), gen.Next(0, 20));
                for (int k = c; k < edges.Length; )
                {
                    if (k != 2)
                    {
                        edges[k] = new Edge(points[0], points[1]);
                        break;
                    }
                    else
                    {
                        edges[k] = new Edge(points[0], points[1]);
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
            Polygon[] N = new Polygon[6];
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
                edges[edges.Length - 1] = new Edge(edges[edges.Length - 2].b, edges[0].a);
                N[p] = new Polygon(abc, edges);
            }
            //==========OUTPUT==============================
            for (int i = 0; i < N.Length; i++)
            {
                N[i].Distance(N[i].AB);
                N[i].AREA(N[i].ABC);
                N[i].Perimeter(N[i].AB);
                Console.WriteLine("====-----------------====");
            }
            Console.ReadKey();
        }
    }
}