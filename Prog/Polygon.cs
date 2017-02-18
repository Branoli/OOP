using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prog
{
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
}
