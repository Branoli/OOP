using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unstable
{
    class Polygon
    {
        private Triangle[] triangle;
        private Edge[] edge;

        public Polygon(Triangle[] triangles)
        {
            this.triangle = new Triangle[triangles.Length];
            this.edge = new Edge[triangles.Length + 2];
            int x = 2;
            for (int i = 0; i < triangles.Length; i++)
            {
                this.triangle[i] = triangles[i];
                if (i == 0)
                {
                    if (triangle.Length == 1)
                    {
                        edge[0] = new Edge(triangle[i].abc[0], triangle[i].abc[1]);
                        edge[1] = new Edge(triangle[i].abc[1], triangle[i].abc[2]);
                        edge[2] = new Edge(triangle[i].abc[2], triangle[i].abc[0]);
                        break;
                    }
                    edge[0] = new Edge(triangle[i].abc[0], triangle[i].abc[1]);
                    edge[1] = new Edge(triangle[i].abc[0], triangle[i].abc[2]);
                }
                else
                {
                    for (int j = x; j < edge.Length; j++)
                    {


                        edge[j] = new Edge(triangle[i].abc[0], triangle[i].abc[2]);
                        x++;
                        if (i == triangle.Length - 1)
                        {
                            edge[edge.Length - 1] = new Edge(triangle[i].abc[2], triangle[i].abc[1]);
                        }
                        break;
                    }
                }
            }

        }

        public double AreaOfPolygon(Polygon polygon)
        {
            double AreaOfTriangle = 0;
            for (int i = 0; i < polygon.triangle.Length; i++)
            {
                AreaOfTriangle += polygon.triangle[i].AreaOfTriangle(polygon.triangle[i]);
            }
            return AreaOfTriangle;
        }
        public double PerimeterOfPolygon(Polygon polygon)
        {
            double PerimeterOfPolygon = 0;
            for (int i = 0; i < polygon.edge.Length; i++)
            {
                PerimeterOfPolygon += polygon.edge[i].DistanceForTriangle(polygon.edge[i]);
            }
            return PerimeterOfPolygon;
        }
        public void DistanceOfEdgePolygon(Polygon polygon)
        {
            for (int j = 0; j < polygon.edge.Length; j++)
            {
                Console.WriteLine("Длина {0}ого ребра ровна {1}", j, polygon.edge[j].DistanceForTriangle(polygon.edge[j]));
            }
        }
        public void CheckOfRightTringleInPolygon(Polygon polygon)
        {
            double x = 0, z = 0;
            for (int i = 0; i < polygon.triangle.Length; i++)
            {
                if (polygon.triangle[i].CheckOfRight(polygon.triangle[i]) > 0 )
                {
                    z += polygon.triangle[i].CheckOfRight(polygon.triangle[i]);
                    x++;
                }
            }
            if (z == 0) Console.WriteLine("В многоугольнике НЕТ прямоугольных треугольников");
            else Console.WriteLine("Кол-во ПРЯМОУГОЛЬНЫХ треугольников в многоугольнике = {0},\nих средняя площадь = {1}", x, z / x);

            
        }
        public void CheckOfIsoscelesTringleInPolygon(Polygon polygon)
        {
            double x = 0, z = 0;
            for (int i = 0; i < polygon.triangle.Length; i++)
            {
                if (polygon.triangle[i].CheckOfIsosceles(polygon.triangle[i]) > 0)
                {
                    z += polygon.triangle[i].CheckOfIsosceles(polygon.triangle[i]);
                    x++;
                }
            }
            if (z == 0) Console.WriteLine("В многоугольнике НЕТ равнобедренных треугольников");
            else Console.WriteLine("Кол-во равнобедренных треугольников в многоугольнике = {0},\nих средняя площадь = {1}", x, z / x);

            
        }
    }
}
