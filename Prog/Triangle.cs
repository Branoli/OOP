using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prog
{
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
}
