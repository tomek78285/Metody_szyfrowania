using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Szyfr_Vigenere
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void encrypt(object sender, EventArgs e)
        {
            StringBuilder ciphertext = new StringBuilder();
            string tb1 = textBox1.Text;
            string key = textBox2.Text;
            int keyIndex = 0;

            foreach (char c in tb1)
            {
                if (char.IsLetter(c))
                {
                    char baseChar = char.IsUpper(c) ? 'A' : 'a';
                    int shift = char.ToUpper(key[keyIndex]) - baseChar;
                    char shiftedChar = (char)(((c + shift - baseChar) % 26) + baseChar);
                    ciphertext.Append(shiftedChar);

                    keyIndex = (keyIndex + 1) % key.Length;
                }
                else
                {
                    ciphertext.Append(c);
                }
            }

            textBox3.Text = ciphertext.ToString();
        }

        private void descrypt(object sender, EventArgs e)
        {
            StringBuilder plaintext = new StringBuilder();
            string tb3 = textBox3.Text;
            string key = textBox2.Text;
            int keyIndex = 0;

            foreach (char c in tb3)
            {
                if (char.IsLetter(c))
                {
                    char baseChar = char.IsUpper(c) ? 'A' : 'a';
                    int shift = char.ToUpper(key[keyIndex]) - baseChar;
                    char shiftedChar = (char)(((c - shift - baseChar + 26) % 26) + baseChar);
                    plaintext.Append(shiftedChar);

                    keyIndex = (keyIndex + 1) % key.Length;
                }
                else
                {
                    plaintext.Append(c);
                }
            }

            textBox4.Text = plaintext.ToString();
        }
    }
    }
}
