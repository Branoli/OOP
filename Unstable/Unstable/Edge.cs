using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unstable
{
    class Edge
    {
        
        private Point A;
        private Point B;
        public Edge(Point A, Point B)
        {
            this.A = A;
            this.B = B;
        }
        public void Distance(Edge AB)
        {
            Console.WriteLine((int)Math.Sqrt(Math.Pow(AB.B.x - AB.A.x, 2) + Math.Pow(AB.B.y - AB.A.y, 2)));   
        }
        public double DistanceForTriangle(Edge AB)
        {
            return (Math.Sqrt(Math.Pow(AB.B.x - AB.A.x, 2) + Math.Pow(AB.B.y - AB.A.y, 2)));
        }
    }
}
