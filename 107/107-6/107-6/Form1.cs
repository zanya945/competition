using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _107_6
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            add_table();
            InitializeComponent();
        }
        static string ans1 = "", ans2 = "", code1 = "", code2 = "";
        bool correct1 = false;
        static Dictionary<string, string> table = new Dictionary<string, string>();
        
        private void quit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        static void add_table() {
            table.Add("10", "A");
            table.Add("01", "B");
            table.Add("11", "C");
            table.Add("001", "D");
            table.Add("000", "E");
        }

        static string random_code() {
            Random random1 = new Random();
            int size = random1.Next(26, 51);
            string code = "";
            for (int i = 0; i < size; i++) {
                int ra = random1.Next(0,2);
                code += ra;
            }
            
            return code;
        }

        static bool correct(string str, int decide) {
            bool fl = false;
            string verify = "";
            for (int i = 0; i < str.Length; i++) {
                verify += str[i];
                if (table.ContainsKey(verify)) {
                    switch (decide) {
                        case 1:
                            ans1 += table[verify];
                            break;
                        case 2:
                            ans2 += table[verify];
                            break;
                    }
                    verify = "";
                }
            }
            if (verify.Length == 0) { fl = true; }
            return fl;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            ans1 = "";
            code1 = random_code();
            bool fl = false;
            while (!fl)
            {
                code1 = random_code();
                fl = correct(code1, 1);
                if (!fl) ans1 = "";
            }
            textBox1.Text = code1;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ans2 = "";
            code2 = random_code();
            correct1 = correct(code2, 2);

            textBox4.Text = code2;
        }

        private void Decording_Click(object sender, EventArgs e)
        {
            textBox3.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox3.Text = ans1;
            if (correct1)
            {
                textBox5.Text = "合理";
                textBox6.Text = ans2;
            }
            else {
                textBox5.Text = "不合理";
            }
        }
    }
}
