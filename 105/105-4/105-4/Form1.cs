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

namespace _105_4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog();
            file.InitialDirectory = Directory.GetCurrentDirectory();
            file.OpenFile();
            int ct1 = 0, ct2 = 0;
            List<string> target;
            char s_ch;
            string path = file.FileName, line, init_str = "", ans = "";
            init_str = File.ReadAllText(path);
            textBox1.Text = init_str;
            for (int i = 0; i < init_str.Length; i++)
            {
                if (init_str[i] == '/')
                {
                    ct1++;
                }
                else if (init_str[i] == ' ')
                {
                    ct2++;
                }
            }
            s_ch = (ct1 > ct2) ? '/' : ' ';
            target = init_str.Split(s_ch).ToList();
            for (int i = 0; i < target.Count(); i++)
            {
                if (i < target.Count - 1)
                {
                    int code2 = Convert.ToInt32(target[i - 1][0]);
                    int code = Convert.ToInt32(target[i][0]);
                    if ((code >= 65 && code <= 90) || (code >= 97 && code <= 122))
                    {
                        if ((code2 >= 65 && code2 <= 90) || (code2 >= 97 && code2 <= 122))
                        {
                            ans += target[i] + " " + target[i - 1];
                            continue;
                        }
                    }
                    if (target[i].Contains("??"))
                    {
                        target[i].Replace("?", "");
                    }
                    if (target[i].Contains("::"))
                    {
                        target[i].Replace(":", "");
                    }
                    if (target[i].Contains("(") && target[i].Count() <= 2)
                    {
                        target[i].Replace("(", "\r\n");
                        target[i].Replace(")", "");
                    }
                    ans += target[i] + "\r\n";

                }
            }
            textBox2.Text = ans;
        }
    }
}
