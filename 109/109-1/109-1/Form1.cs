using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _109_1
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
            label4.Text = "";
            label5.Text = "";
        }
        string change(int num) {
            string ch = "";
            switch (num)
            {
                case 0:
                    ch = "零";
                    break;
                case 1:
                    ch = "壹";
                    break;
                case 2:
                    ch = "貳";
                    break;
                case 3:
                    ch = "參";
                    break;
                case 4:
                    ch = "肆";
                    break;
                case 5:
                    ch = "伍";
                    break;
                case 6:
                    ch = "陸";
                    break;
                case 7:
                    ch = "柒";
                    break;
                case 8:
                    ch = "捌";
                    break;
                case 9:
                    ch = "玖";
                    break;
            }

            return ch;
        }

        string thousand(List<int> num) {
            string pro = "";
            bool zero = true;
            if (num.Count >= 4) {
                if (num[3] != 0)
                {
                    string ch1 = change(num[3]);
                    pro += ch1 + "千";
                    zero = false;
                }
            }
            if (num.Count >= 3) {
                if (num[2] != 0)
                {
                    string ch1 = change(num[2]);
                    pro += ch1 + "百";
                    zero = false;
                }
            }
            if (num.Count >= 2)
            {
                if (num[1] != 0)
                {
                    string ch1 = change(num[1]);
                    pro += ch1 + "十";
                    zero = false;
                }
            }
            if (num.Count >= 1)
            {
                if (num[0] != 0)
                {
                    string ch1 = change(num[0]);
                    pro += ch1;
                    zero = false;
                }
            }
            if (zero) {
                pro = "零";
            }
            return pro;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Dictionary<string, int> map = new Dictionary<string, int>();
            string str = textBox1.Text;
            string str3 = str, ch_str = "";
            int count = 1;
            for (int i = str.Length -1; i >= 0; i--) {
                if (count == 3) {
                    count = 1;
                    str3 = str3.Insert(i, ",");
                    continue;
                }
                count++;
            }
            count = 0; int car = 1;
            List<int> num = new List<int>();
            for (int i = str.Length - 1; i >= 0; i--) {
                int nu = Convert.ToInt32(str[i]) - Convert.ToInt32('0');
                num.Add(nu);
                if (count == 3)
                {
                    string str1 = thousand(num);
                    ch_str = ch_str.Insert(0, str1);
                    num.Clear();
                    count = 0;
                    if (car == 1)
                    {
                        ch_str = ch_str.Insert(0, "萬");
                        car++;
                        map.Add("萬", 1);
                    }
                    else if (car == 2)
                    {
                        ch_str = ch_str.Insert(0, "億");
                        car++; map.Add("億", 1);
                    }
                    else if (car == 3)
                    {
                        ch_str = ch_str.Insert(0, "兆");
                        car++; map.Add("兆", 1);
                    }
                    continue;

                }
                else if(i == 0){
                    string str1 = thousand(num);
                    ch_str = ch_str.Insert(0, str1);
                    num.Clear();
                    count = 0;
                }
                count++;
            }
            for (int i = ch_str.Length - 1; i >= 0; i--) {
                string temp = "";
                if (i != 0)
                {
                    temp = Convert.ToString(ch_str[i-1]);
                    if (temp == "零" && map.ContainsKey(Convert.ToString(ch_str[i])))
                    {
                        ch_str = ch_str.Remove(i, 1);
                    }
                }
                else {
                    if (temp == "零" && map.ContainsKey(Convert.ToString(ch_str[i])))
                    {
                        ch_str = ch_str.Remove(i, 1);
                    }
                }
            }
            ch_str = ch_str.Replace("零零", "零");
            label5.Text = ch_str;
            label4.Text = str3;
        }
    }
}
