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
    }
}
