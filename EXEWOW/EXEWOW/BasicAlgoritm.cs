using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EXEWOW
{
    class BasicAlgoritm
    {
        public int[,] ArrOfKnuckles;
        public BasicAlgoritm(int GetLenght)
        {
            this.ArrOfKnuckles = new int[GetLenght, GetLenght];
            MovingTheKnuckles();

        }
        public bool CheckTheKnuckle(int q)
        {
            int x = 0, y = 0, z = 0, c = 0;
            for (int i = 0; i < ArrOfKnuckles.GetLength(1); i++)
            {
                for (int j = 0; j < ArrOfKnuckles.GetLength(0); j++)
                {
                    if (ArrOfKnuckles[i, j] == q)
                    {
                        x = i;
                        y = j;
                    }
                    if (ArrOfKnuckles[i, j] == 0)
                    {
                        z = i;
                        c = j;
                    }
                }
            }
            if (Math.Sqrt(Math.Pow(z - x, 2) + Math.Pow(c - y, 2)) == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void MovingTheKnuckles()
        {
            int q = 0;
            do
            {
                q = Convert.ToInt32(Console.ReadLine());
            } while (CheckTheKnuckle(q) == false);


            int x = 0, y = 0, z = 0, c = 0, v = 0;
            for (int i = 0; i < ArrOfKnuckles.GetLength(1); i++)
            {
                for (int j = 0; j < ArrOfKnuckles.GetLength(0); j++)
                {
                    if (ArrOfKnuckles[i, j] == q)
                    {
                        x = i;
                        y = j;
                    }
                    if (ArrOfKnuckles[i, j] == 0)
                    {
                        z = i;
                        c = j;
                    }
                }
            }
            v = ArrOfKnuckles[x, y];
            ArrOfKnuckles[x, y] = ArrOfKnuckles[z, c];
            ArrOfKnuckles[z, c] = v;
            MovingTheKnuckles();
        }
    }
}
