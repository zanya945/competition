namespace Q1
{
    public partial class Form1 : Form
    {
        static int save = 0;
        static bool isfirst = true;
        public Form1()
        {
            InitializeComponent();
            textBox1.Text = save.ToString();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (save <= 35)
            {
                label6.Text = "餘額不足";
            }
            else if (isfirst && save >= 35)
            {
                save -= 35;
                label6.Text = "送出可樂";
                isfirst = false;
            }
            else if (save >= 35)
            {
                save -= 35;
                label6.Text += ", 送出可樂";
            }
            textBox1.Text = save.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (save <= 30)
            {
                label6.Text = "餘額不足";
            }
            else if (isfirst && save >= 30)
            {
                save -= 30;
                label6.Text = "送出pepso";
                isfirst = false;
            }
            else if (save >= 30)
            {
                save -= 30;
                label6.Text +=", 送出pepso";
            }
            textBox1.Text = save.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (save <= 25)
            {
                label6.Text = "餘額不足";
            }
            else if (isfirst && save >= 25)
            {
                save -= 25;
                label6.Text = "送出Diet pepso";
                isfirst = false;
            }
            else if(save >= 25)
            {
                save -= 25;
                label6.Text += ", 送出Diet pepso";
            }
            textBox1.Text = save.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (save <= 30)
            {
                label6.Text = "餘額不足";
            }
            else if (isfirst && save >= 30)
            {
                save -= 30;
                label6.Text = "送出Diet Cola";
                isfirst = false;
            }
            else if(save >= 30)
            {
                save -= 30;
                label6.Text += ", 送出Diet Cola";
            }
            textBox1.Text = save.ToString();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked) {
                save += 5;
            }
            if (radioButton2.Checked) {
                save += 10;
            }
            if (radioButton3.Checked) {
                save += 50;
            }
            textBox1.Text = save.ToString();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (save >= 0)
            {
                label6.Text = " 退款" + save + "元";
                save = 0;
                isfirst = true;
            }
            textBox1.Text = save.ToString();
        }
    }
}