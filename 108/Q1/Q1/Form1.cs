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
                label6.Text = "�l�B����";
            }
            else if (isfirst && save >= 35)
            {
                save -= 35;
                label6.Text = "�e�X�i��";
                isfirst = false;
            }
            else if (save >= 35)
            {
                save -= 35;
                label6.Text += ", �e�X�i��";
            }
            textBox1.Text = save.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (save <= 30)
            {
                label6.Text = "�l�B����";
            }
            else if (isfirst && save >= 30)
            {
                save -= 30;
                label6.Text = "�e�Xpepso";
                isfirst = false;
            }
            else if (save >= 30)
            {
                save -= 30;
                label6.Text +=", �e�Xpepso";
            }
            textBox1.Text = save.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (save <= 25)
            {
                label6.Text = "�l�B����";
            }
            else if (isfirst && save >= 25)
            {
                save -= 25;
                label6.Text = "�e�XDiet pepso";
                isfirst = false;
            }
            else if(save >= 25)
            {
                save -= 25;
                label6.Text += ", �e�XDiet pepso";
            }
            textBox1.Text = save.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (save <= 30)
            {
                label6.Text = "�l�B����";
            }
            else if (isfirst && save >= 30)
            {
                save -= 30;
                label6.Text = "�e�XDiet Cola";
                isfirst = false;
            }
            else if(save >= 30)
            {
                save -= 30;
                label6.Text += ", �e�XDiet Cola";
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
                label6.Text = " �h��" + save + "��";
                save = 0;
                isfirst = true;
            }
            textBox1.Text = save.ToString();
        }
    }
}