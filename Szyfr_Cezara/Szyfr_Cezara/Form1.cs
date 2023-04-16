using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Szyfr_Cezara
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void encrypt(object sender, EventArgs e)
        {
            string tb1 = textBox1.Text;

            StringBuilder ciphertext = new StringBuilder();
            foreach (char c in tb1)
            {
                if (char.IsLetter(c))
                {
                    char baseChar = char.IsUpper(c) ? 'A' : 'a';
                    char shiftedChar = (char)(((c + 3 - baseChar) % 26) + baseChar);
                    ciphertext.Append(shiftedChar);
                }
                else
                {
                    ciphertext.Append(c);
                }
            }

            textBox2.Text = ciphertext.ToString();
        }

        private void decrypt(object sender, EventArgs e)
        {
            string tb2 = textBox2.Text;

            StringBuilder ciphertext = new StringBuilder();
            foreach (char c in tb2)
            {
                if (char.IsLetter(c))
                {
                    char baseChar = char.IsUpper(c) ? 'A' : 'a';
                    char shiftedChar = (char)(((c - 3 - baseChar) % 26) + baseChar);
                    ciphertext.Append(shiftedChar);
                }
                else
                {
                    ciphertext.Append(c);
                }
            }

            textBox3.Text = ciphertext.ToString();
        }
    }
}
