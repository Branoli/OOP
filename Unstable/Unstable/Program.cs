using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unstable
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Скольки угольник вас интерисует: ");
            int q = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();
            //+++++++++++++++Massiv Polygon++++++++++++++++++++++
            Polygon[] polygons = new Polygon[3];
            Triangle[] triangle = new Triangle[q - 2];
            Point[] points = new Point[3];
            Edge[] edges = new Edge[q];
            Random gen = new Random();


            for (int k = 0; k < polygons.Length; k++)
            {
                for (int i = 0; i < triangle.Length; i++)
                {
                    if (i == 0)
                    {
                        do
                        {
                            for (int j = 0; j < points.Length; j++)
                            {
                                points[j] = new Point(gen.Next(0, 20), gen.Next(0, 20));
                            }
                        } while (points[0] == points[1] || points[0] == points[2] || points[1] == points[2]);
                        triangle[i] = new Triangle(points);
                    }
                    else
                    {
                        do
                        {
                            points[0] = points[1];
                            points[1] = points[2];
                            points[2] = new Point(gen.Next(0, 20), gen.Next(0, 20));
                        } while (points[0] == points[1] || points[0] == points[2] || points[1] == points[2]);

                        triangle[i] = new Triangle(points);
                    }
                }
                polygons[k] = new Polygon(triangle);
            }


            for (int i = 0; i < polygons.Length; i++)
            {
                polygons[i].DistanceOfEdgePolygon(polygons[i]);
                Console.WriteLine("Площадь полигона №-{0} ровна {1}",i, polygons[i].AreaOfPolygon(polygons[i]));
                Console.WriteLine("Периметр полигона №-{0} равен {1}", i, polygons[i].PerimeterOfPolygon(polygons[i]));
                polygons[i].CheckOfRightTringleInPolygon(polygons[i]);
                polygons[i].CheckOfIsoscelesTringleInPolygon(polygons[i]);
                Console.WriteLine("-----==========-----");
            }
            Console.ReadKey();
        }
    }
}
