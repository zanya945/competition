namespace Q1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Bitmap bitmap = new Bitmap(500, 500);
            Graphics g = Graphics.FromImage(bitmap);
            for (int i = 0; i < 10; i++) {
                g.DrawLine(Pens.Black, 25, i*50+25, 475, i*50+25);
                g.DrawLine(Pens.Black, i*50+25, 25, i*50+25,  475);
            }
            pictureBox1.Image = bitmap;
        }
        List<Point> node = new List<Point>();
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            node.Clear();
            Random random = new Random();
            Graphics graphics = Graphics.FromImage(pictureBox1.Image);
            graphics.Clear(BackColor);
            for (int i = 0; i < 10; i++)
            {
                graphics.DrawLine(Pens.Black, 25, i * 50 + 25, 475, i * 50 + 25);
                graphics.DrawLine(Pens.Black, i * 50 + 25, 25, i * 50 + 25, 475);
            }
            while (node.Count < 7)
            {
                Point point = new Point(random.Next(1, 9), random.Next(1, 9));
                if (node.Any(self => self.X == point.X || self.Y == point.Y))
                {
                }
                else
                {
                    node.Add(point);
                }
                for (int i = 0; i < node.Count; i++)
                {
                    graphics.FillEllipse(Brushes.Black, node[i].X * 50 + 10, node[i].Y * 50 + 10, 30, 30);
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int sum = 0;
            Graphics graphics = Graphics.FromImage(pictureBox1.Image);
            int y = node.Select(v => v.Y).Sum() / node.Count();
            int xL = node.Min(v => v.X);
            int xR = node.Max(v => v.X);
            int re = xR - xL;
            Pen red = new Pen(Color.Red, 7);
            graphics.DrawLine(red, xL*50 +25, y*50 + 25, xR*50+25,y * 50 +25);
            sum += xR - xL;
            for (int i = 0; i < node.Count; i++) {
                graphics.DrawLine(red, node[i].X * 50 + 25, y * 50 + 25, node[i].X * 50 + 25, node[i].Y * 50 + 25);
                sum += Math.Abs(node[i].Y - y);
            }
            label2.Text = sum.ToString();
        }
    }
}