using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _105_ex
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string str2 = "",str = "";
            int num = int.Parse(textBox1.Text), basic = int.Parse(textBox2.Text), fish = 0;
            while (num != 0) {
                if (num < 0 && basic < num)
                {
                    fish = num - basic;
                }
                else {
                    fish = Math.Abs(num % basic);
                }
                num = (num - fish) / basic;
                if (fish > 9)
                {
                    str2 += Convert.ToChar(fish + 55);
                }
                else {
                    str2 += fish;
                }
            }
            for (int i = str2.Length -1; i >= 0; i--) {
                str += str2[i];
            }
            textBox3.Text = str;
        }
    }
}
