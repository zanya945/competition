using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _105_2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        double chair_reallW = 0, chair_realH = 830, obj_realH = 0, obj_realW = 0;

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = obj_realW.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox2.Text = obj_realH.ToString();
        }

        int chair_pixelW = 0, chair_pixelH = 0, obj_pixelW = 0, obj_pixelH = 0;
        
        List<Point> Find(Bitmap bit, Point start) {
            List<Point> target = new List<Point>();
            bool touch = false;
            int sx = 1000, ex = -1, sy = 1000, ey = -1;
            for (int i = start.X; i < bit.Width; i++)
            {
                bool isobj = false, first = true;
                for (int j = 0; j < bit.Height; i++)
                {
                    Color r = bit.GetPixel(i, j);
                    double num = r.R * 0.3 + r.G * 0.59 + r.B * 0.11;
                    if (num >= 200)
                    {
                        isobj = false;
                    }
                    else
                    {
                        isobj = true;
                    }
                    if (isobj && first)
                    {
                        sy = Math.Min(sy, j);
                        first = false;
                        touch = true;
                    }
                    else if (!isobj && !first)
                    {
                        ey = Math.Max(ey, j);
                    }
                }
                if (touch && first)
                {
                    break;
                }
            }
            touch = false;
            for (int i = sy; i < bit.Height; i++)
            {
                bool isobj = false, first = true;
                for (int j = start.X; j < bit.Width; i++)
                {
                    Color r = bit.GetPixel(i, j);
                    double num = r.R * 0.3 + r.G * 0.59 + r.B * 0.11;
                    if (num >= 200)
                    {
                        isobj = false;
                    }
                    else
                    {
                        isobj = true;
                    }
                    if (isobj && first)
                    {
                        sx = Math.Min(sx, j);
                        first = false;
                        touch = true;
                    }
                    else if (!isobj && !first)
                    {
                        ex = Math.Max(ex, j);
                    }
                }
                if (touch && first)
                {
                    break;
                }
            }
            Point startp = new Point(sx,sy);
            Point end = new Point(ex, ey);
            target.Add(startp);
            target.Add(end);
            return target;
        }

        private void button1_Click(object sender, EventArgs e)
        { 
            OpenFileDialog file = new OpenFileDialog();
            file.ShowDialog();
            string path = file.FileName;
            Bitmap bit = new Bitmap(path);
            List<Point> chair = Find(bit, new Point(0, 0));
            List<Point> obj = Find(bit, chair[1]);
            chair_pixelH = chair[1].Y - chair[0].Y;
            chair_pixelW = chair[1].X - chair[0].X;
            obj_pixelH = obj[1].Y - obj[0].Y;
            obj_pixelW = obj[1].X - obj[0].X;
            double size = chair_realH / chair_pixelH;
            chair_reallW = chair_pixelW * size;
            obj_realH = obj_pixelH * size;
            obj_realW = obj_pixelW * size;
        }
    }
}
