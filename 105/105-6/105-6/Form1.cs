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

namespace _105_6
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
            file.ShowDialog();
            pictureBox1.Image = Image.FromFile(file.FileName);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Bitmap bit = new Bitmap(pictureBox1.Image);
            List<List<bool>> li = new List<List<bool>>();
            for (int i = 0; i < bit.Width; i++) {
                for (int j = 0; j < bit.Height; j++) {
                    Color r = bit.GetPixel(i, j);
                    int rgb = r.ToArgb();
                    var s = Convert.ToString(rgb, 2);
                    int red = (rgb >> 16 & 1) == 1 ? 255 : 16;
                    int green = (rgb >> 8 & 1) == 1 ? 255 : 16;
                    int blue = (rgb & 1) == 1 ? 255 : 16;
                    bit.SetPixel(i, green, Color.FromArgb(red, green, blue));
                }
            }
            pictureBox1.Image = bit;
        }
    }
}
