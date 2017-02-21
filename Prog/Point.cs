using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prog
{
    public class Point
    {
        public int x;
        public int y;
        public Point(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
        public static Point[] GenerationOfPoints(Point[] points, int x)
        {
            Random gen = new Random();
            if (x == 0)
            {
                do
                {
                    for (int i = 0; i < points.Length; i++)
                    {
                        points[i] = new Point(gen.Next(0, 10), gen.Next(0, 10));
                    }
                } while (points[0].y == points[1].y && points[0].y == points[2].y && points[1].y == points[2].y);
            }
            else
            {
                if (points[2].x == points[1].x && points[2].y == points[1].y || points[2].x == points[0].x && points[2].y == points[0].y)
                {
                    do
                    {
                        points[2] = new Point(gen.Next(0, 10), gen.Next(0, 10));
                    } while (points[2].x == points[1].x && points[2].y == points[1].y || points[2].x == points[0].x && points[2].y == points[0].y);
                    x++;
                    GenerationOfPoints(points, x);
                }
            }
            return points;
        }
    }
}
