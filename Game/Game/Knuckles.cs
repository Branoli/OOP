using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class Knuckles
    {
        public int[,] ArrOfKnuckles;
        public Knuckles()
        {
            this.ArrOfKnuckles = new int[4, 4];
            this.ArrOfKnuckles = ArrOfKnuckle();
            PrintOfKnuckles();
        }

        public int[,] ArrOfKnuckle()
        {
            int[,] mas = new int[4, 4];
            int x = 0;
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    mas[i, j] = x;
                    x++;
                }
            }
            return mas;
        }
        public void PrintOfKnuckles()
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    Console.Write("\t{0}", this.ArrOfKnuckles[i, j]);
                }
                Console.WriteLine();
            }
            MovingTheKnuckles();
        }
        public int[,] MovingTheKnuckles()
        {
            int q = 0;
            do
            {
                Console.Write("какую костяшку по отношению к нулю передвинуть ");
                q = Convert.ToInt32(Console.ReadLine());

            } while (CheckTheKnuckles(q) != true);
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (ArrOfKnuckles[i, j] == q)
                    {

                        for (int n = 0; n < 4; n++)
                        {
                            for (int k = 0; k < 4; k++)
                            {
                                if (ArrOfKnuckles[n, k] == 0)
                                {
                                    ArrOfKnuckles[i, j] = 0;
                                    ArrOfKnuckles[n, k] = q;
                                    PrintOfKnuckles();
                                }
                            }
                        }
                    }
                }
            }
            return ArrOfKnuckles;
        }
        public bool CheckTheKnuckles(int q)
        {
            int x = 0;
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (ArrOfKnuckles[i, j] == 0)
                    {
                        if (ArrOfKnuckles[0, 0] == 0 || ArrOfKnuckles[0, 3] == 0 || ArrOfKnuckles[3, 0] == 0 || ArrOfKnuckles[3, 3] == 0)
                        {
                            if ((ArrOfKnuckles[0, 0 + 1] == q || ArrOfKnuckles[0 + 1, 0] == q) || (ArrOfKnuckles[0, 3 - 1] == q || ArrOfKnuckles[0 + 1, 3] == q) ||
                                (ArrOfKnuckles[3, 0 + 1] == q || ArrOfKnuckles[3 - 1, 0] == q) || (ArrOfKnuckles[3, 3 - 1] == q || ArrOfKnuckles[3 - 1, 3] == q))
                            {
                                x++;
                                break;
                            }
                        }
                        //------------------
                        if (ArrOfKnuckles[1, 0] == 0 || ArrOfKnuckles[1, 3] == 0)
                        {
                            if ((ArrOfKnuckles[1, 0 + 1] == q || ArrOfKnuckles[1 + 1, 0] == q || ArrOfKnuckles[1 - 1, 0] == q) ||
                                (ArrOfKnuckles[1, 3 - 1] == q || ArrOfKnuckles[1 - 1, 3] == q || ArrOfKnuckles[1 + 1, 3] == q))
                            {
                                x++;
                                break;
                            }
                            break;
                        }
                        if (ArrOfKnuckles[2, 0] == 0 || ArrOfKnuckles[2, 3] == 0)
                        {
                            if ((ArrOfKnuckles[2, 0 + 1] == q || ArrOfKnuckles[2 + 1, 0] == q || ArrOfKnuckles[2 - 1, 0] == q) ||
                                (ArrOfKnuckles[2, 3 - 1] == q || ArrOfKnuckles[2 - 1, 3] == q || ArrOfKnuckles[2 + 1, 3] == q))
                            {
                                x++;
                                break;
                            }
                            break;
                        }
                        if (ArrOfKnuckles[3, 2] == 0 || ArrOfKnuckles[0, 2] == 0)
                        {
                            if ((ArrOfKnuckles[3 - 1, 2] == q || ArrOfKnuckles[3, 2 + 1] == q || ArrOfKnuckles[3, 2 - 1] == q) ||
                                (ArrOfKnuckles[0 + 1, 2] == q || ArrOfKnuckles[0, 2 + 1] == q || ArrOfKnuckles[0, 2 - 1] == q))
                            {
                                x++;
                                break;
                            }
                            break;
                        }
                        if (ArrOfKnuckles[3, 1] == 0 || ArrOfKnuckles[0, 1] == 0)
                        {
                            if ((ArrOfKnuckles[3 - 1, 1] == q || ArrOfKnuckles[3, 1 + 1] == q || ArrOfKnuckles[3, 1 - 1] == q) ||
                                (ArrOfKnuckles[0 + 1, 1] == q || ArrOfKnuckles[0, 1 - 1] == q || ArrOfKnuckles[0, 1 + 1] == q))
                            {
                                x++;
                                break;
                            }
                            break;
                        }
                        //------------------
                        if (ArrOfKnuckles[1, 1] == 0)
                        {
                            if (ArrOfKnuckles[1, 1 - 1] == q || ArrOfKnuckles[1, 1 + 1] == q || ArrOfKnuckles[1 - 1, 1] == q || ArrOfKnuckles[1 + 1, 1] == q)
                            {
                                x++;
                                break;
                            }
                            break;
                        }
                        if (ArrOfKnuckles[1, 2] == 0)
                        {
                            if (ArrOfKnuckles[1, 2 - 1] == q || ArrOfKnuckles[1, 2 + 1] == q || ArrOfKnuckles[1 - 1, 2] == q || ArrOfKnuckles[1 + 1, 2] == q)
                            {
                                x++;
                                break;
                            }
                            break;
                        }
                        if (ArrOfKnuckles[2, 1] == 0)
                        {
                            if (ArrOfKnuckles[2, 1 - 1] == q || ArrOfKnuckles[2, 1 + 1] == q || ArrOfKnuckles[2 - 1, 1] == q || ArrOfKnuckles[2 + 1, 1] == q)
                            {
                                x++;
                                break;
                            }
                            break;
                        }
                        if (ArrOfKnuckles[2, 2] == 0)
                        {
                            if (ArrOfKnuckles[2, 2 - 1] == q || ArrOfKnuckles[2, 2 + 1] == q || ArrOfKnuckles[2 - 1, 2] == q || ArrOfKnuckles[2 + 1, 2] == q)
                            {
                                x++;
                                break;
                            }
                            break;
                        }
                        //------
                    }
                }
            }
            if (x > 0) return true;
            else return false;

        }
    }
}