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
    public partial class SecondForm : Form
    {
        public SecondForm()
        {
            InitializeComponent();
        }

        private void SecondForm_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string[] s = { "2", "3", "4", "5", "6", "7", "8", "9"};
            int count = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (textBox1.Text == Convert.ToString(s[i]))
                {
                    count++;
                    int GetLenght = int.Parse(textBox1.Text); 
                    FirstForm f = new FirstForm(GetLenght);
                    f.Show();
                }
            }
            if (count == 0)
            {
                MessageBox.Show("Ведите число от 2 до 9");
            }
        }



    }
}
