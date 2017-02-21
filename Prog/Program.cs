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
                        Point.GenerationOfPoints(points, x);
                        Edge.GenerationOfEdge(edges, points, h, c); 
                        abc[h] = new Triangle(points);
                    }
                    else
                    {
                        Edge.GenerationOfEdge(edges, points, h, c); 
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
                    if (Triangle.CheckOfIsosceles(N[i].ABC) > 0) Console.WriteLine("Средний периметр равнобедренных треугольников в многоугольнике = {0}", Triangle.CheckOfIsosceles(N[i].ABC));
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