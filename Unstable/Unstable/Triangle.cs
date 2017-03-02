using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unstable
{
    class Triangle
    {
        public Point[] abc;
        private Edge[] ABC;
        public Triangle(Point[] points)
        {
            this.abc = new Point[points.Length];
            this.ABC = new Edge[points.Length];
            for (int i = 0; i < points.Length; i++)
            {
                this.abc[i] = points[i];
                if (i == points.Length - 1) this.ABC[i] = new Edge(points[i], points[i - 2]);
                else this.ABC[i] = new Edge(points[i], points[i + 1]);   
            }
        }

        public double CheckOfRight(Triangle triangle)
        {
            double x = 0;
            if (Math.Pow(triangle.ABC[0].DistanceForTriangle(triangle.ABC[0]), 2) == (Math.Pow(triangle.ABC[1].DistanceForTriangle(triangle.ABC[1]), 2)) + (Math.Pow(triangle.ABC[2].DistanceForTriangle(triangle.ABC[2]), 2)))
            {
                x += triangle.AreaOfTriangle(triangle);
                return x;
            }
            if (Math.Pow(triangle.ABC[1].DistanceForTriangle(triangle.ABC[1]), 2) == Math.Pow(triangle.ABC[0].DistanceForTriangle(triangle.ABC[0]), 2) + Math.Pow(triangle.ABC[2].DistanceForTriangle(triangle.ABC[2]), 2))
            {
                x += triangle.AreaOfTriangle(triangle);
                return x;
            }
            if (Math.Pow(triangle.ABC[2].DistanceForTriangle(triangle.ABC[2]), 2) == Math.Pow(triangle.ABC[0].DistanceForTriangle(triangle.ABC[0]), 2) + Math.Pow(triangle.ABC[1].DistanceForTriangle(triangle.ABC[1]), 2))
            {
                x += triangle.AreaOfTriangle(triangle);
                return x;
            }
            else return 0;
        }
        public double AreaOfTriangle(Triangle triangle)
        {
            double[] mas = new double[triangle.abc.Length];
            double SemiPerimeter = 0;
            double c = 1, f = 0;
            for (int i = 0; i < triangle.abc.Length; i++)
            {
                mas[i] = triangle.ABC[i].DistanceForTriangle(triangle.ABC[i]);
                SemiPerimeter += mas[i];
            }
            SemiPerimeter = SemiPerimeter / 2;
            for (int i = 0; i < mas.Length; i++)
            {
                f = SemiPerimeter - mas[i];
                c = c * f;
            }
            SemiPerimeter *= c;
            return SemiPerimeter;
        }
        public double CheckOfIsosceles(Triangle triangle)
        {
            double x = 0;
            for (int i = 0; i < triangle.ABC.Length; i++)
            {
                if (i == triangle.ABC.Length - 1)
                {
                    if (triangle.ABC[i].DistanceForTriangle(triangle.ABC[i]) == triangle.ABC[i - 2].DistanceForTriangle(triangle.ABC[i - 2]))
                    {
                        x += triangle.PerimeterOfTriangle(triangle);
                        return x;
                    }
                }
                else
                {
                    if (triangle.ABC[i].DistanceForTriangle(triangle.ABC[i]) == triangle.ABC[i + 1].DistanceForTriangle(triangle.ABC[i + 1]))
                    {
                        x += triangle.PerimeterOfTriangle(triangle);
                        return x;
                    }
                }
            }
            return 0;
        }
        public double PerimeterOfTriangle(Triangle triangle)
        {
            double perimeter = 0;
            for (int i = 0; i < triangle.ABC.Length; i++)
            {
                perimeter += triangle.ABC[i].DistanceForTriangle(triangle.ABC[i]);
            }
            return perimeter;
        }
    }
}
