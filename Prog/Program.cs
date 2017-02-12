﻿using System;
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
            public Edge(Point q, Point w)
            {
                this.q = q;
                this.w = w;
            }
        }
        public class Triangle
        {
            public Point a;
            public Point b;
            public Point c;

            public Edge AB;
            public Edge BC;
            public Edge CA;
            public Triangle(Point[] points, Edge[] edges)
            {
                this.a = points[0];
                this.b = points[1];
                this.c = points[2];
                this.AB = edges[0];
                this.BC = edges[1];
                this.CA = edges[2];
            }
            
            
            
        }
        //==========METHODS=========
        public static double Distance(Triangle ABC, int i)
        {
            if (i == 1) return Math.Sqrt(Math.Pow(ABC.AB.w.x - ABC.AB.q.x, 2) + Math.Pow(ABC.AB.w.y - ABC.AB.q.y, 2));
            if (i == 2) return Math.Sqrt(Math.Pow(ABC.BC.w.x - ABC.BC.q.x, 2) + Math.Pow(ABC.BC.w.y - ABC.BC.q.y, 2));
            else return Math.Sqrt(Math.Pow(ABC.CA.w.x - ABC.CA.q.x, 2) + Math.Pow(ABC.CA.w.y - ABC.CA.q.y, 2));
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
            //+++++++++++++++Massiv Triagles+++++++++++++++++++++++
            Random gen = new Random();
            Triangle[] abc = new Triangle[2];      
            Point[] points = new Point[3];
            Edge[] edges = new Edge[3];
            for (int j = 0; j < abc.Length; j++)
            {
                for (int i = 0; i < points.Length; i++)
                {
                    points[i] = new Point(gen.Next(0, 10), gen.Next(0, 10));
                    for (int k = 0; k < edges.Length; k++)
                    {
                        if (edges.Length - 1 == k)
                            edges[k] = new Edge(points[k - 2], points[k]);
                        else
                            edges[k] = new Edge(points[k], points[k + 1]);
                    }
                }
                abc[j] = new Triangle(points, edges);
            }

            
            //==========OUTPUT==============================
            for (int i = 0; i < abc.Length; i++)
            {

                if (Isosceles(abc[i]) == 1) Console.WriteLine("Isosceles");
                else Console.WriteLine("Not Isosceles");

                if (Right(abc[i]) == 1) Console.WriteLine("Right");
                else Console.WriteLine("Not Right");

                Console.WriteLine("ребро AB = {0}",Distance(abc[i], 1));
                Console.WriteLine("ребро BC = {0}",Distance(abc[i], 2));
                Console.WriteLine("ребро CA = {0}",Distance(abc[i], 3));

                Console.WriteLine("Периметр = {0}",Perimeter(abc[i]));
                Console.WriteLine("Площадь = {0}",Area(abc[i]));
                Console.WriteLine("====-----------------====");
            }
            Console.ReadKey();
        }
    }
}

