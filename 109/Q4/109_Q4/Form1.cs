namespace _109_Q4
{
    public partial class Form1 : Form
    {
        Random random = new Random();
        List<Pen> penList = new List<Pen>();
        List<List<Point>> square_coordinate = new List<List<Point>>();
        List<Point> all_coordinate = new List<Point>();
        public Form1()
        {
            InitializeComponent();
            Bitmap bitmap = new Bitmap(500,500);
            Graphics g = Graphics.FromImage(bitmap);
            pictureBox1.Image = bitmap;
            Pen pen1 = new Pen(new SolidBrush(Color.Black));
            pen1.DashStyle = System.Drawing.Drawing2D.DashStyle.Custom;
            pen1.DashPattern = new float[] {10, 1};
            Pen pen2 = new Pen(new SolidBrush(Color.Black));
            pen2.DashStyle = System.Drawing.Drawing2D.DashStyle.Custom;
            pen2.DashPattern = new float[] { 10, 3 };
            Pen pen3 = new Pen(new SolidBrush(Color.Black));
            pen3.DashStyle = System.Drawing.Drawing2D.DashStyle.Custom;
            pen3.DashPattern = new float[] { 10, 5 };
            Pen pen4 = new Pen(new SolidBrush(Color.Black));
            pen4.DashStyle = System.Drawing.Drawing2D.DashStyle.Custom;
            pen4.DashPattern = new float[] { 10, 7 };
            penList.Add(pen1);
            penList.Add(pen2);
            penList.Add(pen3);
            penList.Add(pen4);
        }
        

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        { 
            int y = all_coordinate.Select(p => p.Y).Min();
            int x = all_coordinate.Find(p => p.Y == y).X;
            Pen pen1 = new Pen(Color.Red);
            Point start = new Point(x, y);
            while (true) { 
                Point next = all_coordinate.Select(p => )
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            all_coordinate.Clear();
            if (square_coordinate.Count != 0)
            {
                square_coordinate.Clear();
            }
            int count = random.Next(3,5);
            Graphics g = Graphics.FromImage(pictureBox1.Image);
            g.Clear(BackColor);
            int pen_kind = 0;
            for (int i = 0; i < count; i++)
            {
                Getlocate(square_coordinate);
                Point la_point = new Point(square_coordinate[i][0].X, square_coordinate[i][0].Y);
                g.DrawLine(penList[pen_kind], la_point.X, la_point.Y, square_coordinate[i][3].X, square_coordinate[i][3].Y);
                foreach (Point owo in square_coordinate[i]) {
                    g.DrawLine(penList[pen_kind], la_point.X, la_point.Y, owo.X, owo.Y);
                    la_point.X = owo.X;
                    la_point.Y = owo.Y;
                }
                pen_kind++;
            }
            all_coordinate = all_coordinate.OrderBy(p => p.X).ThenBy(p => p.Y).ToList();
        }
        void Getlocate(List<List<Point>> square_coordinate) {
            List<Point> list1 = new List<Point>();
            int x = random.Next(20, 81);
            int y = random.Next(20, 81);
            int length = random.Next(40, 200);
            int width = random.Next(40, 200);
            int x2 = x + length;
            int y2 = y;
            int x3 = x + length;
            int y3 = y + width;
            int x4 = x;
            int y4 = y + width;
            Point coordinate_1 = new Point(x, y);
            Point coordinate_2 = new Point(x2, y2);
            Point coordinate_3 = new Point(x3, y3);
            Point coordinate_4 = new Point(x4, y4);
            list1.Add(coordinate_1);
            list1.Add(coordinate_2);
            list1.Add(coordinate_3);
            list1.Add(coordinate_4);
            all_coordinate.Add(coordinate_1);
            all_coordinate.Add(coordinate_2);
            all_coordinate.Add(coordinate_3);
            all_coordinate.Add(coordinate_4);
            square_coordinate.Add(list1);
        }
    }
}