// _______________________________
// | THIS FORM IS JUST FOR TEST ! |
// | THIS IS NOT MAIN CODE        |
// ‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Caesar_TestFaker
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private Label waterMarkLabel;

        public static char cipher(char ch, int key)
        {
            //if (!char.IsLetter(ch))
            //{
            //    return ch;
            //}
            if (ch == '%')
            {
                return '%';
            }
            string[] checkw = { "a", "á", "b", "c", "č", "d", "ď", "e", "é", "ě", "f", "g", "h", "i", "í", "j", "k", "l", "m", "n", "ň", "o", "p", "q", "r", "ř", "s", "š", "t", "ť", "u", "ú", "ů", "v", "w", "x", "y", "ý", "z", "ž", "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };
            char d = char.IsUpper(ch) ? 'A' : 'a';
            char text_char = (char)((((ch + key) - d) % 26) + d);
            if (checkw.Contains(text_char.ToString()))
            {
                return (char)((((ch + key) - d) % 26) + d);
            }
            return ' ';

        }


        public static string Encipher(string input, int key)
        {
            string output = string.Empty;

            foreach (char ch in input)
                output += cipher(ch, key);

            return output;
        }

        public static string Decipher(string input, int key)
        {
            return Encipher(input, 26 - key);
        }

        private static string DecodeFromUtf8(string input)
        {
            string utf8_String = input;
            byte[] bytes = Encoding.Default.GetBytes(utf8_String);
            utf8_String = Encoding.UTF8.GetString(bytes);
            return utf8_String;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string t = Decipher(textBox1.Text, Convert.ToInt32(cipher_code.Text));
            //this.label1.Text = t;
            //this.textBox2.Text = t;
            this.dectrypted.Text = t;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.label1.Text = DecodeFromUtf8(textBox2.Text);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string t = Encipher(textBox1.Text, Convert.ToInt32(cipher_code.Text));
            this.label1.Text = t;
            this.textBox2.Text = t;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Watermark showmark;
            showmark = new Watermark();
            showmark.Show();
        }
    }
}
