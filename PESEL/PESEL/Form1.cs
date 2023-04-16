using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PESEL
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string tb1 = textBox1.Text;
            int[] weights = { 1, 3, 7, 9, 1, 3, 7, 9, 1, 3 };
            int sum = 0;

            if (tb1.Length == 10)
            {
                for (int i = 0; i < 10; i++)
                {
                    sum += weights[i] * int.Parse(tb1[i].ToString());
                }

                int checksum = 10 - (sum % 10);

                if (checksum == 10)
                {
                    checksum = 0;
                }


                textBox2.Text = tb1 + checksum.ToString();
            }

            else textBox2.Text = "Niepoprawny kod PESEL";
        }

        private void ValidatePESEL(object sender, EventArgs e)
        {
            string tb2 = textBox2.Text;
            string tb3;
            int[] weights = { 1, 3, 7, 9, 1, 3, 7, 9, 1, 3 };
            int sum = 0;

            if (tb2.Length == 11)
            {
                for (int i = 0; i < 10; i++)
                {
                    sum += weights[i] * int.Parse(tb2[i].ToString());
                }

                int checksum = 10 - (sum % 10);

                if (checksum == 10)
                {
                    checksum = 0;
                }


                tb3 = tb2 + checksum.ToString();
                if (tb3 == textBox2.Text) textBox3.Text = "Poprawny kod PESEL";
            }

            else textBox3.Text = "Niepoprawny kod PESEL";
        }

        private void CheckGender(object sender, EventArgs e)
        {
            string tb2 = textBox2.Text;
            if (int.Parse(tb2[11].ToString()) % 2 == 0) label4.Text = "Kobieta";
            else label4.Text = "Mężczyzna";
        }
    }
}
