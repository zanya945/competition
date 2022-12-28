using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _105_5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Dictionary<int, int> map = new Dictionary<int, int>();
        List<char> chli = new List<char>();
        List<int> c_li = new List<int>();
        double normal_bit = 0, encoding_bit = 0;
        double proportion = 0.0;
        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox2.Text = encoding_bit.ToString();
            textBox3.Text = proportion.ToString();
        }

        void cls() {
            map.Clear();
            chli.Clear();
            c_li.Clear();
            normal_bit = 0;
            encoding_bit = 0;
            proportion = 0;
            textBox2.Text = "";
            textBox3.Text = "";
        }
        private void button1_Click(object sender, EventArgs e)
        {
            cls();
            Random random = new Random();
            int j = 0;
            while (j < 4) {
                int code1 = random.Next(65, 91);
                int code2 = random.Next(1, 1000);
                if (!map.ContainsKey(code1)){
                    map.Add(code1, code2);
                    chli.Add(Convert.ToChar(code1));
                    c_li.Add(code2);
                    j++;
                }
            }
            c_li.Sort();
            for (int i = 0; i < c_li.Count; i++) {
                normal_bit += c_li[i];   
            }
            normal_bit *= 2;
            encoding_bit = (3 * c_li[0] + 3 * c_li[1]) + 2 * c_li[2] + c_li[3];
            proportion = Math.Round(normal_bit / encoding_bit, 4);
            label8.Text = chli[0].ToString();
            label9.Text = chli[1].ToString();
            label10.Text = chli[2].ToString();
            label11.Text = chli[3].ToString();
            label12.Text = c_li[0].ToString();
            label13.Text = c_li[1].ToString();
            label14.Text = c_li[2].ToString();
            label15.Text = c_li[3].ToString();
            textBox1.Text = normal_bit.ToString();
        }
    }
}
