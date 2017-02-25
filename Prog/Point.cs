using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prog
{
    class Point
    {
        public int x;
        public int y;
        public Point(int x, int y)
        {
            this.x = x;
            this.y = y;
            GenerationOfPoints(x, y);
        }
        public Point GenerationOfPoints(int x, int y)
        {
            Random gen = new Random();
            x = gen.Next(0, 10);
            y = gen.Next(0, 10);
            Point a = new Point(x, y);
            return a;
        }
    }
}
