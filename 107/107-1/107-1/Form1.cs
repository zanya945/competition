using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _107_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            clr();
        }
        static Point R1 = new Point(30, 30), Y1 = new Point(30, 60), G1 = new Point(30, 90), G2 = new Point(280, 270), Y2 = new Point(250, 270), R2 = new Point(220, 270);

        private void button3_Click(object sender, EventArgs e)
        {
            clr();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            clr();
            Bitmap bit = new Bitmap(pictureBox1.Image);
            Graphics g = Graphics.FromImage(bit);
            state++;
            if (state == 7) state = 1;
            draw(state, g);
            pictureBox1.Image = bit;
        }

        static int state = 0;
        private void button1_Click(object sender, EventArgs e)
        {
            clr();
            Bitmap bit = new Bitmap(pictureBox1.Image);
            Graphics g = Graphics.FromImage(bit);
            state = 1;
            draw(state, g);
            pictureBox1.Image = bit;
        }

        void draw(int state, Graphics g) {
            switch (state) {
                case 1:
                    g.FillEllipse(Brushes.Red, R1.X, R1.Y, 20, 20);
                    g.FillEllipse(Brushes.Green, G2.X, G2.Y, 20, 20);
                    break;
                case 2:
                    g.FillEllipse(Brushes.Red, R1.X, R1.Y, 20, 20);
                    g.FillEllipse(Brushes.Yellow, Y2.X, Y2.Y, 20, 20);
                    break;
                case 3:
                    g.FillEllipse(Brushes.Red, R1.X, R1.Y, 20, 20);
                    g.FillEllipse(Brushes.Red, R2.X, R2.Y, 20, 20);
                    break;
                case 4:
                    g.FillEllipse(Brushes.Green, G1.X, G1.Y, 20, 20);
                    g.FillEllipse(Brushes.Red, R2.X, R2.Y, 20, 20);
                    break;
                case 5:
                    g.FillEllipse(Brushes.Yellow, Y1.X, Y1.Y, 20, 20);
                    g.FillEllipse(Brushes.Red, R2.X, R2.Y, 20, 20);
                    break;
                case 6:
                    g.FillEllipse(Brushes.Red, R1.X, R1.Y, 20, 20);
                    g.FillEllipse(Brushes.Red, G2.X, R2.Y, 20, 20);
                    break;
            }
        }

        void clr() {
            Bitmap bitmap = new Bitmap(300, 300);
            Graphics g = Graphics.FromImage(bitmap);
            g.DrawLine(Pens.Black, new Point(50, 0), new Point(50, 300));
            g.DrawLine(Pens.Black, new Point(70, 0), new Point(70, 300));
            g.DrawLine(Pens.Black, new Point(0, 250), new Point(300, 250));
            g.DrawLine(Pens.Black, new Point(300, 270), new Point(0, 270));
            pictureBox1.Image = bitmap;
        }
    }
}
