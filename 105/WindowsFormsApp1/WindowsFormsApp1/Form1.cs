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

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        double chairRealH = 830, chairRealW;
        double LeftRealH, LeftRealW;
        List<Point> chair, men;

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = LeftRealH.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox2.Text = LeftRealW.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog();
            file.InitialDirectory = Directory.GetCurrentDirectory();
            pictureBox1.Image = Image.FromFile(file.FileName);

            Bitmap bit = new Bitmap(pictureBox1.Image);
            Graphics g = Graphics.FromImage(bit);
            chair = GetSize(bit, new Point(0, 0));
            int chairPixelH = chair[1].Y - chair[0].Y;
            int chairPixelW = chair[1].X - chair[0].X;
            chairRealW = chairPixelW * (chairRealH/chairPixelH);

            men = GetSize(bit, new Point(chair[1].Y, 0));
            int LeftPixelH = men[1].Y - men[0].Y;
            int LeftPixelW = men[1].X - men[0].X;
            LeftRealH = LeftPixelH * (chairRealH / chairPixelH);
            LeftRealW = LeftPixelW * (chairRealW / chairPixelW);
        }
        

        List<Point> GetSize(Bitmap bit, Point start) {
            int sx = 0, sy = 0, ex = 0, ey = 0;
            bool touch = false;
            List<Point> target = new List<Point>();
            for (int i = start.X; i < bit.Width; i++) {
                bool isobj = false;
                for (int j = start.Y; i < bit.Height; j++) {
                    if (!Isbackground(bit.GetPixel(i, j))) {
                        isobj = true;
                        break;
                    }
                }

                if (isobj && !touch) {
                    sx = i;
                    touch = true;
                }
                if (!isobj && touch) {
                    ex = i;
                    break;
                }
            }
            touch = false;
            for (int y = start.Y; y < bit.Height; y++) {
                bool isobj = false;
                for (int x = sx; x <= ex; x++) {
                    if (!Isbackground(bit.GetPixel(x, y))){
                        isobj = true;
                        break;
                    }
                }
                if (isobj && !touch)
                {
                    sy = y;
                    touch = true;
                }
                if (!isobj && touch)
                {
                    ey = y;
                    break;
                }
            }
            target.Add(new Point(sx, sy));
            target.Add(new Point(ex, ey));
            return target;
        }

        bool Isbackground(Color r) {
            return r.R * 0.3 + r.G * 0.59 + r.B * 0.11 >= 200;
        }
    }
}
