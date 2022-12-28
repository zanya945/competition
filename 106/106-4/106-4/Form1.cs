using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _106_4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            textBox2.Text = "9999";
            textBox3.Text = "0.1";
            textBox4.Text = "1.0;-1.0;0.0";
        }
        List<double> w;
        List<List<double>> data = new List<List<double>>();
        List<List<double>> command = new List<List<double>>();
        List<double> ans = new List<double>();
        private void 選取檔案ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog();
            file.InitialDirectory = System.IO.Directory.GetCurrentDirectory();
            file.ShowDialog();
            string path = file.FileName, line = "";
            FileStream fs = new FileStream(path, FileMode.Open);
            StreamReader s = new StreamReader(fs);
            string str = s.ReadToEnd();
            textBox1.Text = str;
            data = str.Replace("\r\n", "\n").Split('\n').Where(v => v != null).Select(v => v.Split(' ').Where(w => w != "").Select(w => double.Parse(w)).ToList()).ToList();
            for (int i = 0; i < data.Count; i++) {
                List<double> store = new List<double>(3);
                for (int j = 0; j < 4; j++) {
                    if (j == 3) { ans.Add(data[i][j]); break; }
                    else store.Add(data[i][j]);
                }
                command.Add(store);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool fl = true;
            int curry = 1;
            int max_count = int.Parse(textBox2.Text.ToString());
            double learningRate = double.Parse(textBox3.Text.ToString());
            w = textBox4.Text.ToString().Split(';').Where(v => v != "").Select(v => double.Parse(v)).ToList();
            while (max_count >= curry) {
                double E = 0;
                for (int i = 0; i < command.Count; i++) {
                    int state;
                    double w1 = 0;
                    for (int j = 0; j < command[i].Count; j++) {
                        w1 += command[i][j] * w[j];
                    }
                    state = (w1 >= 0) ? 1 : -1;
                    if (state != ans[i]) {
                        for (int j = 0; j < w.Count; j++) {
                            w[j] += learningRate * (ans[i] - state) * command[i][j];
                        }
                        E += 0.5 * Math.Sqrt(ans[i] - state);
                    }
                }
                if (E == 0) break;
                curry++;
            }
            string w_str = "";
            foreach (double a in w) {
                w_str += a + "; ";
            }
            textBox5.Text = w_str;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            List<double> new_command = textBox6.Text.ToString().Split(';').Where(v => v != "").Select(v => double.Parse(v)).ToList();
            int state = -1;
            double w1 = 0;
            for (int i = 0; i < w.Count; i++) {
                w1 += w[i] * new_command[i];
            }
            state = (w1 >= 0) ? 1 : -1;
            if (state == 1)
            {
                label6.Text = "機器人向: " + "1(左)";
            }
            else {
                label6.Text = "機器人向: " + "-1(右)";
            }
        }
    }
}
