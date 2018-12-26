using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Timer Timer;
        void update()
        {
            Timer = new Timer();
            Timer.Tick += Timer_Tick;
            Timer.Interval = 100;
            Timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            DateTime date = DateTime.Now;
            toolStripStatusLabel1.Text = date.ToString("dd-MM-yy HH:mm:ss");
        }

        public void Textenctypt(string text)
        {
            int i=0,rnd;
            string str = "";
            Random random = new Random();
            while(i<text.Length)
            {
                rnd = random.Next(10);
                if(text[i] >= 97 && text[i]<=122)
                {
                    if(text[i]-rnd > 97)
                    {
                        str += (char)(text[i] - rnd);
                        str += '^';
                        str += rnd.ToString();
                    }
                    else
                    {
                        str += (char)(text[i] + rnd);
                        str += '_';
                        str += rnd.ToString();
                    }
                }
                else if(text[i] >= 65 && text[i] <=90)
                {
                    if(text[i]-rnd >65)
                    {
                        str += (char)(text[i] - rnd);
                        str += '^';
                        str += rnd.ToString();
                    }
                    else
                    {
                        str += (char)(text[i] + rnd);
                        str += '_';
                        str += rnd.ToString();
                    }
                }
                else if(text[i] == 32)
                {
                    str += '*';
                }
                i++;
            }
            textBox2.Text = str;
            MessageBox.Show("Text encrypted", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        public void Decrypt(string text)
        {
            int i=0;
            string str="";
            while(i<text.Length)
            {
                if(text[i+1] == '^')
                {
                    str += (char)(text[i]+int.Parse(text[i+2].ToString()));
                }
                else if(text[i+1] == '_')
                {
                    str += (char)(text[i] - int.Parse(text[i + 2].ToString()));
                }
                if(text[i] == '*')
                {
                    str += ' ';
                    i++;
                }
                else
                    i += 3;
            }
            textBox2.Text = str;
            MessageBox.Show("The text is decoded", "Success", MessageBoxButtons.OK,MessageBoxIcon.Information);
        }
        private void Button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
                Textenctypt(textBox1.Text);
            else if (comboBox1.SelectedIndex == 1)
                Decrypt(textBox1.Text);
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(textBox2.Text);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            update();
        }
    }
}
