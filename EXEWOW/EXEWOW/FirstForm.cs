using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EXEWOW
{
    public partial class FirstForm : Form
    {
        private Button[,] MasButtom;

        public FirstForm(int GetLenght)
        {
            SecondForm f2 = new SecondForm();
            f2.Close();
            MasButtom = new Button[GetLenght, GetLenght];
            GenOFButtom();
            InitializeComponent();
        }
        private void GenOFButtom()
        {
            int count = 0;

            for (int i = 0; i < MasButtom.GetLength(0); i++)
            {
                for (int j = 0; j < MasButtom.GetLength(1); j++)
                {
                    MasButtom[i, j] = new Button();
                    MasButtom[i, j].Size = new Size(50, 50);
                    MasButtom[i, j].Location = new Point(50 + i * 50, 50 + j * 50);
                    MasButtom[i, j].BackColor = Color.Azure;
                    MasButtom[i, j].Text = count.ToString();
                    if (MasButtom[i, j].Text == "0") MasButtom[i, j].Visible = false;

                    this.MasButtom[i, j].Click += new System.EventHandler(this.MovingButtom);
                    count++;
                    Controls.Add(MasButtom[i, j]);
                }
            }


        }
        private bool CheckButtom(int XZero, int YZero, int x, int y)
        {
            if (Math.Sqrt(Math.Pow(XZero - x, 2) + Math.Pow(YZero - y, 2)) == 50 || Math.Sqrt(Math.Pow(XZero - x, 2) + Math.Pow(YZero - y, 2)) == 100)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private void MovingButtom(object sender, EventArgs e)
        {
            int x = 0;
            int y = 0;
            int XZero = 0;
            int YZero = 0;
            for (int i = 0; i < MasButtom.GetLength(0); i++)
            {
                for (int j = 0; j < MasButtom.GetLength(1); j++)
                {
                    if (MasButtom[i, j].Text == "0")
                    {
                        XZero = MasButtom[i,j].Location.X;
                        YZero = MasButtom[i, j].Location.Y;
                    }
                    if (MasButtom[i, j] == (sender as Button))
                    {
                        x = MasButtom[i, j].Location.X;
                        y = MasButtom[i, j].Location.Y;
                    }
                }
            }
            if (CheckButtom(XZero, YZero, x, y) == true)
            {
                int XB = 0, YB = 0, XZ = 0, YZ = 0;
                for (int i = 0; i < MasButtom.GetLength(0); i++)
                {
                    for (int j = 0; j < MasButtom.GetLength(1); j++)
                    {
                        if (MasButtom[i, j].Text == "0")
                        {
                            XZ = i;
                            YZ = j;
                        }
                        if (MasButtom[i, j] == (sender as Button))
                        {
                            XB = i;
                            YB = j;
                        }
                    }
                }
                Button bt = new Button();
                bt.Location = new Point(MasButtom[XB, YB].Location.X, MasButtom[XB, YB].Location.Y);
                MasButtom[XB, YB].Location = new Point(MasButtom[XZ, YZ].Location.X, MasButtom[XZ, YZ].Location.Y);
                MasButtom[XZ, YZ].Location = new Point(bt.Location.X, bt.Location.Y);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Random gen = new Random();
            int x = 0;
            int y = 0;
            for (int k = 0; k < 100/MasButtom.Length; k++)
            {
                for (int i = 0; i < MasButtom.GetLength(0); i++)
                {
                    for (int j = 0; j < MasButtom.GetLength(1); j++)
                    {
                        x = gen.Next(0, 4);
                        y = gen.Next(0, 4);
                        Button bt = new Button();

                        bt.Location = new Point(MasButtom[x, y].Location.X, MasButtom[x, y].Location.Y);
                        MasButtom[x, y].Location = new Point(MasButtom[i, j].Location.X, MasButtom[i, j].Location.Y);
                        MasButtom[i, j].Location = new Point(bt.Location.X, bt.Location.Y);
                    }
                }
            }


        }
    }
}
