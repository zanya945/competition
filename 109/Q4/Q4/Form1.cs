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
            List<Point> move = new List<Point>();
            move.Add(up);
            move.Add(down);
            move.Add(left);
            move.Add(right);
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
            List<Point> answer = new List<Point>();
            List<List<Point>> road = new List<List<Point>>();
            List<Point> path3 = new List<Point>();
            get_path(start, path3);
            darw_ans(answer);
            void get_path(Point a, List<Point> path) { 
                //當執行步數一樣，先碰到end為答案
                List<Point> owo_path = path;
                //road 所有結果
                if (a.X == end.X && a.Y == end.Y)
                {
                    answer = owo_path;
                    return;
                } else if (a.X > 11 || a.Y > 11 || a.X < 0 || a.Y <0) {

                }
                else {
                    foreach (Point m in move) {
                        int x = m.X + a.X;
                        int y = m.Y + a.Y;
                        if (x > 11 || y > 11 || nodes.Any(w => w.X == x && w.Y == y || owo_path.Any(w => w.Y == y && w.X == x)))
                        {
                        }
                        else {
                            owo_path.Add(a);
                            get_path(new Point(x, y), owo_path);
                        }
                    }
                }
            }

            void darw_ans(List<Point> path) {
                Point start = path[0];
                path.Remove(start);
                Pen pen = new Pen(Color.Yellow, 7);
                while (path.Count != 0) {
                    g.DrawLine(pen, start.X * 50, start.Y * 50, path[0].X * 50, path[0].Y * 50);
                    start = path[0];
                    path.Remove(start);
                }
            }
        }
    }
}