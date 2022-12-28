using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _106_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int count, num_people;
        List<Data> ouob = new List<Data>();
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Random random = new Random();
            num_people = random.Next(15,31);
            string ma_str = "", en_str = "";
            count = random.Next(11, 21);
            for (int i = 0; i < num_people; i++) {
                double math = random.Next(0, 101);
                double en = random.Next(0, 101);
                ma_str += math + " ";
                en_str += en + " ";
                Data da = new Data(math, en);
                da.index = 1;
                ouob.Add(da);
            }
            textBox1.Text = ma_str;
            textBox2.Text = en_str;
            textBox4.Text = num_people.ToString();
            textBox5.Text = count.ToString();
        }

        class Data {
            public double math, eng;
            public int index;
            public Data(double ma, double en) {
                math = ma;
                eng = en;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Random random = new Random();
            List<double> mathli = ouob.Select(v => v.math).Where(v => v!=0).ToList();
            List<double> enli = ouob.Select(v => v.eng).Where(v => v!=0).ToList();
            int node1 = random.Next(0, mathli.Count());
            int node2 = random.Next(0, enli.Count());
            if (node1 == node2) node2 = random.Next(0, enli.Count());
            List<Data> g = new List<Data> { ouob[node1], ouob[node2] };

            for (int i = 0; i < count; i++) {
                int mi1 = 0;
                int mi2 = 0;
                foreach(Data da in g){


            }

            }
        }
    }
}
