using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;
using Prog;

namespace Хоар
{
    class Program
    {
        public static Point[] GenerationOfPoints(Point[] points, int x)
        {
            Random gen = new Random();
            if (x == 0)
            {
                do
                {
                    for (int i = 0; i < points.Length; i++)
                    {
                        points[i] = new Point(gen.Next(0, 10), gen.Next(0, 10));
                    }
                } while (points[0].y == points[1].y && points[0].y == points[2].y && points[1].y == points[2].y);                
            }
            else
            {
                if (points[2].x == points[1].x && points[2].y == points[1].y || points[2].x == points[0].x && points[2].y == points[0].y)
                {
                    do
                    {
                        points[2] = new Point(gen.Next(0, 10), gen.Next(0, 10));
                    } while (points[2].x == points[1].x && points[2].y == points[1].y || points[2].x == points[0].x && points[2].y == points[0].y);
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
                points = GenerationOfPoints(points, z);
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