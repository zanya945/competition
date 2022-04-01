using System.Text;

namespace Q2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        void clear (){
            textBox1.Text = "";
            label2.Text = "";
            label3.Text = "";
        }
        private void button1_Click(object sender, EventArgs e)
        {
            int enc = 0;
            int numc = 0;
            string password = textBox1.Text;
            if (password.Length < 8 || password.Length > 20) { MessageBox.Show("data ERROR"); clear(); return; }
            byte[] ascii_group = Encoding.ASCII.GetBytes(password);
            foreach (var i in ascii_group)
            {
                if (i >= 97 && i <= 122)
                {
                    enc++;
                }
                else if (i >= 48 && i <= 57) {
                    numc++;
                }
                label2.Text = String.Concat("en :",enc, ", num :", numc);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int enc = 0;
            int numc = 0;
            string password = textBox1.Text;
            byte[] ascii_group = Encoding.ASCII.GetBytes(password);
            foreach (var i in ascii_group)
            {
                if (i >= 97 && i <= 122)
                {
                    enc++;
                }
                else if (i >= 48 && i <= 57)
                {
                    numc++;
                }
            }
            if (enc == 0 || numc == 0)
            {
                label3.Text = "weak";
            }
            else if (password.Length >= 8 && password.Length <= 12)
            {
                label3.Text = "weak";
            }
            else if (enc < numc)
            {
                label3.Text = "weak";
            }
            else {
                label3.Text = "strong";
            }
        }
    }
}