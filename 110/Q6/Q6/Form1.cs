namespace Q6
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        void clear() {
            textBox1.Text = "";
            textBox2.Text = "";
        }
        private void button1_Click(object sender, EventArgs e)
        {
            List<List<int>> data = textBox1.Text.Replace("\r\n","\r").Split("\r").Where(v => v != "").Select(v => v.Split(" ").Where(v => v!="").Select(v => int.Parse(v)).ToList()).ToList();
            if (data.Count < 2 || data.Count > 10) {
                MessageBox.Show("ERROR");
                clear();
                return;
            }
            Queue<data_format> indata = new Queue<data_format>();
            Stack<data_format> outdata = new Stack<data_format>();
            for (int i = 0; i < data.Count; i++) {
                if (data[i][0] < 0 || data[i][0]>100 || data[i][1] < 0 || data[i][1] > 100) {
                    MessageBox.Show("ERROR");
                    clear();
                    return;
                }
                int a1 = data[i][0];
                int a2 = data[i][1];
                indata.Enqueue(new data_format(a1, a2));
            }
            int time = 1;
            int car = 0;
            while (indata.Count != 0)
            {
                while (outdata.Count > 0 && outdata.Peek().out_time <= time)
                {
                    outdata.Pop();
                }
                if (outdata.Count != 0)
                {
                    List<data_format> now = new List<data_format>();
                    while (indata.Count > 0 && indata.Peek().in_time == time)
                    {
                        now.Add(indata.Dequeue());
                    }
                    for (int i = 0; i < now.Count(); i++)
                    {
                        if (outdata.Peek().out_time >= now[i].out_time)
                        { outdata.Push(now[i]); car++; }
                    }
                }
                else
                { outdata.Push(indata.Dequeue()); car++; }
                time++;
            }
            label1.Text = car.ToString();
        }

        class data_format
        {
            public int in_time;
            public int out_time;
            public data_format(int inti, int outi) { 
                this.in_time = inti;
                this.out_time = outi;
            }
        }
    }
}