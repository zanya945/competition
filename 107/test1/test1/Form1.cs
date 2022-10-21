using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace test1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Bitmap bitmap = new Bitmap(350, 300);
            Pen black = new Pen(Color.Black);
            Graphics g = Graphics.FromImage(bitmap);
            g.DrawLine(black, new Point(50, 0), new Point(50, 300));
            g.DrawLine(black, new Point(80, 0), new Point(80, 300));
            g.DrawLine(black, new Point(0, 220), new Point(350, 220));
            g.DrawLine(black, new Point(0, 250), new Point(350, 250));
            pictureBox1.Image = bitmap;
        }
        static int state = 1;
        private void button1_Click(object sender, EventArgs e)
        {
            cls(pictureBox1);
            draw(pictureBox1);
        }
        private void button2_Click(object sender, EventArgs e)
        {
            cls(pictureBox1);
            draw(pictureBox1);
        }
        private void button3_Click(object sender, EventArgs e)
        {
            state = 1;
            cls(pictureBox1);
        }


        static void draw(PictureBox pictureBox) {
            Graphics g = Graphics.FromImage(pictureBox.Image);
            Rectangle red_light1 = new Rectangle(10, 20, 30, 30);
            Rectangle red_light2 = new Rectangle(200, 270, 30, 30);
            Rectangle green_light1 = new Rectangle(10, 60, 30, 30);
            Rectangle green_light2 = new Rectangle(300, 270, 30, 30);
            Rectangle yellow_light1 = new Rectangle(10, 100, 30, 30);
            Rectangle yellow_light2 = new Rectangle(250, 270, 30, 30);
            switch (state) {
                case 1:            
                    g.FillEllipse(Brushes.Red, red_light1);
                    g.FillEllipse(Brushes.Green, green_light2);
                    state+=1;
                    break;
                case 2:
                    g.FillEllipse(Brushes.Red, red_light1);
                    g.FillEllipse(Brushes.Yellow, yellow_light2);
                    state++;
                    break;
                case 3:
                    g.FillEllipse(Brushes.Red, red_light1);
                    g.FillEllipse(Brushes.Red, red_light2);
                    state++;
                    break;
                case 4:
                    g.FillEllipse(Brushes.Green, green_light1);
                    g.FillEllipse(Brushes.Red, red_light2);
                    state++;
                    break;
                case 5:
                    g.FillEllipse(Brushes.Red, red_light2);
                    g.FillEllipse(Brushes.Yellow, yellow_light1);
                    state++;
                    break;               
                case 6:
                    g.FillEllipse(Brushes.Red, red_light2);
                    g.FillEllipse(Brushes.Red, red_light1);
                    state = 1;
                    break;
            }
        }
        static void cls(PictureBox pictureBox1) {
            Bitmap bitmap = new Bitmap(350, 300);
            Pen black = new Pen(Color.Black);
            Graphics g = Graphics.FromImage(bitmap);
            g.DrawLine(black, new Point(50, 0), new Point(50, 300));
            g.DrawLine(black, new Point(80, 0), new Point(80, 300));
            g.DrawLine(black, new Point(0, 220), new Point(350, 220));
            g.DrawLine(black, new Point(0, 250), new Point(350, 250));
            pictureBox1.Image = bitmap;
        }
    }
}
