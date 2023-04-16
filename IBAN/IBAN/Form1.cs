using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IBAN
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void generateIBAN(object sender, EventArgs e)
        {
            string iban = textBox1.Text;
            string oldPartIban = "";

            iban = iban.ToUpper().Replace(" ", "").Replace("-", "");

            if (iban.Length != 26 || !iban.All(char.IsLetterOrDigit))
            {
                textBox2.Text = "Niepoprawny numer IBAN";
            }

            string rearranged = iban.Substring(4) + iban.Substring(0, 4);

            StringBuilder sb = new StringBuilder();

            foreach (char c in rearranged)
            {
                if (char.IsDigit(c))
                {
                    sb.Append(c);
                }
                else
                {
                    sb.Append((c - 55).ToString());
                }
            }

            string numericIban = sb.ToString();

            int remainder = 0;

            for (int i = 0; i < numericIban.Length; i += 7)
            {
                string block = numericIban.Substring(i, Math.Min(7, numericIban.Length - i));
                remainder = int.Parse(remainder.ToString() + block) % 97;
            }

            int checksum = 98 - remainder;

            for (int i = 4; i < 26; i++)
            {
                oldPartIban += iban[i];
            }

            textBox2.Text = "PL" + checksum.ToString("00") + oldPartIban;
        }

        private void isCorrect(object sender, EventArgs e)
        {
            string iban = textBox2.Text;

            iban = iban.ToUpper().Replace(" ", "");
            if (string.IsNullOrEmpty(iban))
            {
                textBox3.Text = "Niepoprawny";
            }
            else if (iban.Length < 2 || iban.Length > 34)
            {
                textBox3.Text = "Niepoprawny";
            }
            else
            {
                string countryCode = iban.Substring(0, 2);
                string checkDigits = iban.Substring(2, 2);
                string bban = iban.Substring(4);

                string formattedIBAN = bban + countryCode + checkDigits;
                StringBuilder numericIBAN = new StringBuilder();

                foreach (char c in formattedIBAN)
                {
                    int charValue = c;

                    if (charValue >= 65 && charValue <= 90)
                    {
                        numericIBAN.Append((charValue - 55).ToString());
                    }
                    else
                    {
                        numericIBAN.Append(c);
                    }
                }

                int modValue = 0;
                for (int i = 0; i < numericIBAN.Length; i++)
                {
                    modValue = (modValue * 10 + int.Parse(numericIBAN[i].ToString())) % 97;
                }

                if (modValue == 1) textBox3.Text = "Poprawny";
                else textBox3.Text = "Niepoprawny";
            }
        }
    }
}
