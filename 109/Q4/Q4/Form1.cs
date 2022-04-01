namespace Q4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Bitmap bitmap = new Bitmap(550, 550);
            Graphics g = Graphics.FromImage(bitmap);
            for (int i =0; i<11; i++) {
                g.DrawLine(Pens.Black, 0, i * 50, 500 , i*50) ;
                g.DrawLine(Pens.Black, i * 50, 0, i * 50, 500);
                // 25 75 125 175 225 275 325 375 425 475 525
            }
            pictureBox1.Image = bitmap;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Graphics g = Graphics.FromImage(pictureBox1.Image);
            g.Clear(Color.White);
            for (int i = 0; i < 11; i++)
            {
                g.DrawLine(Pens.Black, 0, i * 50, 500, i * 50);
                g.DrawLine(Pens.Black, i * 50, 0, i * 50, 500);
                // 25 75 125 175 225 275 325 375 425 475 525
            }
            List<Point> nodes = new List<Point>();
            List<List<Point>> path = new List<List<Point>>();
            Random random = new Random();
            Point start = new Point(1, random.Next(1, 11));
            Point end = new Point(9, random.Next(1, 11));
            Point up = new Point(0, 1);
            Point down = new Point(0, -1);
            Point left = new Point(-1, 0);
            Point right = new Point(1, 0);
            Pen red = new Pen(Color.Red, 5);
            Pen blue = new Pen(Color.Blue, 5);
            g.DrawEllipse(blue,start.X * 50 - 5, start.Y * 50 - 5, 10,10);
            g.DrawRectangle(red, end.X * 50 - 5, end.Y * 50 - 5, 10, 10);
            while (nodes.Count < 33)
            {
                Point point = new Point(random.Next(1, 11), random.Next(1, 10));
                if (nodes.Any(w => (w.X == point.X && w.Y == point.Y) || ( point.X == start.X && point.Y == start.Y ) || ( point.X == end.X && w.Y == end.Y)))
                {
                }
                else {
                    nodes.Add(point);
                    g.FillEllipse(Brushes.Black, point.X * 50 -10, point.Y * 50 - 10, 20, 20);
                } 
            }

            List<Point> get_path(Point a) { 
                List<Point> answer = new List<Point>();

                return answer;
            }
        }
    }
}