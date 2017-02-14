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
        }
        //==========METHODS=========
        static void Distance(Polygon N)
        {
            double q, z = 0;
            for (int i = 0; i < N.AB.Length; i++)
            {
                z++;
                q = Math.Sqrt(Math.Pow(N.AB[i].b.x - N.AB[i].a.x, 2) + Math.Pow(N.AB[i].b.y - N.AB[i].a.y, 2));
                Console.WriteLine("{0}ое ребро = {1}",z,q);
            }
        }
        public static double Area(Polygon N)
        {
            double v = 0;
            double[] mas = new double[3];
            for (int i = 0; i < N.ABC.Length; i++)
            {
                double c = 1, p = 0, q = 0, f = 0;
                for (int k = 0; k < N.ABC[i].a.Length; k++)
                {
                    if (k == N.ABC[i].a.Length - 1)
                    {
                        q = Math.Sqrt(Math.Pow(N.ABC[i].a[k - 2].x - N.ABC[i].a[k].x, 2) + Math.Pow(N.ABC[i].a[k - 2].y - N.ABC[i].a[k].y, 2));
                        mas[k] = q;
                        p += q;
                    }
                    else
                    {
                        q = Math.Sqrt(Math.Pow(N.ABC[i].a[k + 1].x - N.ABC[i].a[k].x, 2) + Math.Pow(N.ABC[i].a[k + 1].y - N.ABC[i].a[k].y, 2));
                        mas[k] = q;
                        p += q;
                    }
                }
                p /= 2;
                for (int k = 0; k < mas.Length; k++)
                {
                    f = p + mas[k];
                    c = c * f;
                }
                p = p * c;
                p = Math.Sqrt(p);
                v = v + p;
            }
            return v;

        }
        public static double Perimeter(Polygon N)
        {
            double q = 0;
            for (int i = 0; i < N.AB.Length; i++)
            {
                q+= Math.Sqrt(Math.Pow(N.AB[i].b.x - N.AB[i].a.x, 2) + Math.Pow(N.AB[i].b.y - N.AB[i].a.y, 2));
            }
            return q;
        }
        //public static double Isosceles(Polygon N)
        //{
            
        //}
        //}
        //public static double Right(Triangle ABC)
        //{
        //    double q, w, e;
        //    q = Math.Sqrt(Math.Pow(ABC.b.x - ABC.a.x, 2) + Math.Pow(ABC.b.y - ABC.a.y, 2));
        //    w = Math.Sqrt(Math.Pow(ABC.c.x - ABC.b.x, 2) + Math.Pow(ABC.c.y - ABC.b.y, 2));
        //    e = Math.Sqrt(Math.Pow(ABC.a.x - ABC.c.x, 2) + Math.Pow(ABC.a.y - ABC.c.y, 2));
        //    if (Math.Pow(q,2) == Math.Pow(w,2)+Math.Pow(e,2))
        //    {
        //        double i = 1;
        //        return i;
        //    }
        //    if (Math.Pow(w,2) == Math.Pow(q,2)+Math.Pow(e,2))
        //    {
        //        double i = 1;
        //        return i;
        //    }
        //    if (Math.Pow(e, 2) == Math.Pow(q, 2) + Math.Pow(w, 2))
        //    {
        //        double i = 1;
        //        return i;
        //    }
        //    else
        //    {
        //        double i = 0;
        //        return i;
        //    }

        //}
        //==========================
        static void Main(string[] args)
        {
            //+++++++++++++++Massiv Triagles+++++++++++++++++++++++
            Random gen = new Random();
            Polygon[] N = new Polygon[1];
            Triangle[] abc = new Triangle[1];      
            Point[] points = new Point[3];
            Edge[] edges = new Edge[3];
            int x = 0, z = 0;
            for (int p = 0; p < N.Length; p++)
            {
                for (int h = 0; h < abc.Length; h++)
                {
                    if (h == 0)
                    {
                        for (int i = 0; i < points.Length; i++)
                        {
                            points[i] = new Point(gen.Next(0, 5), gen.Next(0, 5));
                        }
                        for (int k = 0; k < edges.Length; k++)
                        {
                            if (k == points.Length - 1)
                            {
                                x = k;
                                break;
                            }
                            else edges[k] = new Edge(points[k], points[k + 1]);

                        }
                        abc[h] = new Triangle(points);
                    }
                    else
                    {
                        points[0] = points[1];
                        points[1] = points[2];
                        points[2] = new Point(gen.Next(0, 10), gen.Next(0, 10));
                        for (int k = x; k < edges.Length;)
                        {
                            z++;
                            if (x != 2)
                            {
                                edges[k] = new Edge(points[1], points[2]);
                                x++;
                                break;
                            }
                            else
                            {
                                edges[k] = new Edge(points[1], points[2]);
                                x++;
                                break;
                            }
                        }
                        abc[h] = new Triangle(points);
                    }

                }
                edges[edges.Length - 1] = new Edge(edges[0].a, edges[edges.Length - 2].b);
                N[p] = new Polygon(abc, edges);
            }               
            
            //==========OUTPUT==============================
            for (int i = 0; i < N.Length; i++)
            {

                //if (Isosceles(abc[i]) == 1) Console.WriteLine("Isosceles");
                //else Console.WriteLine("Not Isosceles");

                //if (Right(abc[i]) == 1) Console.WriteLine("Right");
                //else Console.WriteLine("Not Right");

                Distance(N[i]);

                Console.WriteLine("Периметр = {0}",Perimeter(N[i]));
                Console.WriteLine("Площадь = {0}",Area(N[i]));
                Console.WriteLine("====-----------------====");
            }
            Console.ReadKey();
        }
    }
}

