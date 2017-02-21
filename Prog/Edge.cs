using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prog
{
    public class Edge
    {
        public Point a;
        public Point b;
        public Edge(Point a, Point b)
        {
            this.a = a;
            this.b = b;
        }
        //======Methods-----
        public static int CheckOnBulge(Edge[] edges)
        {
            int y = 0;
            for (int i = 0; i < edges.Length; i++)
            {
                y = (edges[i].a.x * edges[i].b.y) - (edges[i].a.y * edges[i].b.x);
                if (y < 0) break;
            }
            if (y < 0) return 0;
            else return 1;
        }
        public static int Distance(Point a, Point b)
        {
            int q = 0;
            q = (int)Math.Sqrt(Math.Pow(b.x - a.x, 2) + Math.Pow(b.y - a.y, 2));
            return q;
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
                points = Point.GenerationOfPoints(points, z);
                for (int k = c; k < edges.Length; )
                {
                    z++;
                    edges[k] = new Edge(points[0], points[2]);
                    break;
                }
                return edges;
            }

        }
    }
}
