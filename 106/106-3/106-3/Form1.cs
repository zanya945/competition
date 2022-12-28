using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _106_3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            while (state.Count <= 7)
            {
                bool state1 = false;
                state.Add(state1);
            }
            pictureBox7.Image = new Bitmap(256, 88);
            pictureBox6.Image = new Bitmap(256, 88);
            pictureBox5.Image = new Bitmap(256, 88);
            pictureBox4.Image = new Bitmap(20, 50);
            pictureBox3.Image = new Bitmap(20, 50);
            pictureBox2.Image = new Bitmap(20, 50);
            pictureBox1.Image = new Bitmap(20, 50);
        }
        List<bool> state = new List<bool>(7);
        void cls() {
            pictureBox7.Image = new Bitmap(256, 88);
            pictureBox6.Image = new Bitmap(256, 88);
            pictureBox5.Image = new Bitmap(256, 88);
            pictureBox4.Image = new Bitmap(20, 50);
            pictureBox3.Image = new Bitmap(20, 50);
            pictureBox2.Image = new Bitmap(20, 50);
            pictureBox1.Image = new Bitmap(20, 50);
        }
        private void pictureBox6_Click(object sender, EventArgs e)
        {
            state[6] = !state[6];
            bright();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            state.Clear();
            cls();
            Random random = new Random();
            while (state.Count < 7) {
                bool state1 = (random.Next(0, 2) == 1)? true: false;
                state.Add(state1);
            }
            bright();
        }
        Bitmap Black(Bitmap bit) {
            Graphics g = Graphics.FromImage(bit);
            for (int x = 0; x < bit.Width; x++)
            {
                for (int y = 0; y < bit.Height; y++)
                {
                    Color black = Color.Black;
                    bit.SetPixel(x, y, black);
                }
            }
            return bit;
        }
        void bright() {
            cls();
            Bitmap bit;
            for (int i = 0; i < state.Count(); i++)
            {
                if (state[i])
                {
                    switch (i)
                    {
                        case 0:
                            bit = new Bitmap(pictureBox7.Image);
                            pictureBox7.Image = Black(bit);
                            break;
                        case 1:
                            bit = new Bitmap(pictureBox4.Image);
                            pictureBox4.Image = Black(bit);
                            break;
                        case 2:
                            bit = new Bitmap(pictureBox3.Image);
                            pictureBox3.Image = Black(bit);
                            break;
                        case 3:
                            bit = new Bitmap(pictureBox5.Image);
                            pictureBox5.Image = Black(bit);
                            break;
                        case 4:
                            bit = new Bitmap(pictureBox2.Image);
                            pictureBox2.Image = Black(bit);
                            break;
                        case 5:
                            bit = new Bitmap(pictureBox1.Image);
                            pictureBox1.Image = Black(bit);
                            break;
                        case 6:
                            bit = new Bitmap(pictureBox6.Image);
                            pictureBox6.Image = Black(bit);
                            break;
                    }                  
                }

            }
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            state[0] = !state[0];
            bright();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            state[1] = !state[1];
            bright();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            state[2] = !state[2];
            bright();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            state[3] = !state[3];
            bright();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            state[4] = !state[4];
            bright();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            state[5] = !state[5];
            bright();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Dictionary<List<bool>, int> map = new Dictionary<List<bool>, int>();
            List<bool> light = new List<bool>();
            List<bool> dark = new List<bool>();
            for (int i = 0; i < state.Count; i++) {
                light.Add(true);
                dark.Add(false);
            }
            List<bool> zero = new List<bool>(light);
            zero[6] = false;
            List<bool> one = new List<bool>(dark); ;
            one[1] = true;
            one[2] = true;
            List<bool> two = new List<bool>(light); ;
            two[2] = false;
            two[5] = false;
            List<bool> three = new List<bool>(light); ;
            three[4] = false;
            three[5] = false;
            List<bool> four = new List<bool>(light); ;
            four[0] = false;
            four[3] = false;
            four[4] = false;
            List<bool> five = new List<bool>(light); ;
            five[1] = false;
            five[4] = false;
            List<bool> six = new List<bool>(light);
            six[1] = false;
            List<bool> six2 = new List<bool>(light);
            six2[0] = false;
            six2[1] = false;
            List<bool> seven = new List<bool>(dark); ;
            seven[0] = true;
            seven[1] = true;
            seven[2] = true;
            List<bool> nine = new List<bool>(light);
            List<bool> nine2 = new List<bool>(light);
            nine2[3] = false;
            nine2[4] = false;
            List<List<bool>> li = new List<List<bool>>(); 
            nine[4] = false;

            li.Add(zero);
            li.Add(one);
            li.Add(two);
            li.Add(three);
            li.Add(four);
            li.Add(five);
            li.Add(six);
            li.Add(seven);
            li.Add(light);
            li.Add(nine);
            li.Add(six2);
            li.Add(nine2);
            int num = 0;
            bool same = true, touch = false;
            for (int i = 0; i < li.Count; i++) {
                int count = 0;
                same = true;
                foreach (bool li1 in state) {
                    if (li1 == li[i][count])
                    {
                        count++;
                    }
                    else {
                        same = false;
                        break;
                    }
                }
                if (same && i >= 10) {
                    touch = true;
                    if (i == 10)
                    {
                        textBox1.Text = "6";
                    }
                    else {
                        textBox1.Text = "9";
                    }
                } else if (same) {
                    touch = true;
                    textBox1.Text = i.ToString();
                    break;
                }
            }
            if (!touch) {
                textBox1.Text = "非數字";
            }
        }
    }
}
