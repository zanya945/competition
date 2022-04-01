namespace Q1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int count = 0;
            char[] text = textBox1.Text.ToCharArray();
            string text3 = "";
            string text4 = "";
            int leng = text.Length - 1;
            for (int i = 0 ; i <= leng ; i++) {
                if (leng + 1 >= 12) {
                    int owo =(int)(leng / (10 ^ 12));
                    text4 = re(text4, owo);
                    text4 += "¥ü";
                }
                char a = text[i];
                if (count == 3) {
                    text3 += ",";
                    count = 0;
                }
                text3 += a.ToString();
                label4.Text = text3;
                count++;
            }


        }
        string re(string text4, int owo) {
            switch (owo)
            {
                case 0:
                    text4 += "¹s";
                    break;
                case 1:
                    text4 += "³ü";
                    break;
                case 2:
                    text4 += "¶L";
                    break;
                case 3:
                    text4 += "?";
                    break;
                case 4:
                    text4 += "¸v";
                    break;
                case 5:
                    text4 += "¥î";
                    break;
                case 6:
                    text4 += "³°";
                    break;
                case 7:
                    text4 += "¬m";
                    break;
                case 8:
                    text4 += "®Ã";
                    break;
                case 9:
                    text4 += "¨h";
                    break;
            }
            return text4;
        }
    }
}