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

namespace _108_5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        double min = 100000;
        List<List<double>> li;
        List<List<bool>> bo;
        List<int> shortest;
        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog();
            file.InitialDirectory = System.IO.Directory.GetCurrentDirectory();
            file.ShowDialog();
            string path = file.FileName;
            FileStream fs = new FileStream(path, FileMode.Open);
            StreamReader s = new StreamReader(fs);
            string str = s.ReadToEnd();
            textBox1.Text = textBox1.Text;
            li = str.Replace("\r\n", "\n").Split('\n').Where(v => v != null).Select(v => v.Split(' ').Where(w => w != "").Select(w => double.Parse(w)).ToList()).ToList();
            int count = (int)li[0][0];
            int start = (int)li[li.Count - 1][0], end = (int)li[li.Count - 1][1];
            li.RemoveAt(0);
            li.RemoveAt(li.Count - 1);
            bo = new List<List<bool>>(li.Count);
            for (int i = 0; i < count; i++) {
                for (int j = 0; j < count; j++) {
                    if (li[i][j] == 0.0)
                    {
                        bo[i][j] = false;
                    }
                    else {
                        bo[i][j] = true;
                    }
                }
            }
            for (int i = 0; i < count; i++) {
                if (bo[start][i]) {
                    List<int> vis = new List<int>();
                    vis.Add(1);
                    vis.Add(i);
                    double len = li[start][i];
                    bfs(vis, li, i, end, len);
                }
            }
            string str2 = "";
            foreach (int i in shortest) {
                str2 += i + "->";
            }
            textBox2.Text = str2.ToString();
            textBox3.Text = min.ToString();
            s.Close();
            fs.Close();
        }

        void bfs(List<int> vis, List<List<double>> table, int start, int end, double len) {
            if (vis[vis.Count - 1] == end)
            {
                if (len < min) {
                    shortest = vis;
                }
                min = Math.Min(min, len);
            }
            else
            {
                for (int i = 0; i < table.Count; i++)
                {
                    if (bo[start][i])
                    {
                        vis.Add(i);
                        len += li[start][i];
                        bfs(vis, li, i, end, len);
                    }
                }
            }
        }
    }
}
