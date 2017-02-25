using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class Program
    {
        class Square
        {
            int x;
            public Square(int x)
            {
                this.x = x;
            }
        }
        class Box
        {
            public Square[] points;
            public Box(Square[] number)
            {
                this.points = new Square[16];

                for (int i = 0; i < points.Length; i++)
                    points[i] = number[i];
            }
        }
        static void Main(string[] args)
        {
            Box[] box = new Box[1];
            Square[] number = new Square[16];
            Random gen = new Random();
            int q = 1;
            for (int i = 0; i < box.Length; i++)
            {
                for (int j = 0; j < number.Length; j++)
                {
                    if (j == 15)
                    {
                        number[j] = new Square(0);
                    }
                    else
                    {
                        number[j] = new Square(q);
                        q++;
                    }
                }
                box[i] = new Box(number);
            }
                
            Console.ReadKey();

        }
    }
}
