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
            int leng = text.Length;
            for (int i = 0; i < leng; i++)
            {
                text3 = text_3(text);
                text4 = re(text);
            }
            label4.Text = text3.ToString();
            label5.Text = text4.ToString();
        }

        string text_3(char[] text) {
            string text4 = "";
            string text5 = "";
            text4 = string.Concat(text);
            int j = 1;
            int lenght = text4.Length;
            for (int i = lenght - 1; i >= 0; i--) {
                if (i != 0 && j == 3) {
                    text4 = text4.Insert(i, ",");
                    j = 0;
                }
                j++;
            }
            return text4;
        }

        string re(char[] text4)
        {
            string result  = "";
            string text = string.Concat(text4);
            int j = 1;
            int owo = 0;
            for (int i = 0; i < text4.Length ; i++) {
                switch (text4[i])
                {
                    case '0':
                        result += '零';
                        break;
                    case '1':
                        result += "壹";
                        break;
                    case '2':
                        result += "貳";
                        break;
                    case '3':
                        result += "叄";
                        break;
                    case '4':
                        result += "肆";
                        break;
                    case '5':
                        result += "伍";
                        break;
                    case '6':
                        result += "陸";
                        break;
                    case '7':
                        result += "柒";
                        break;
                    case '8':
                        result += "捌";
                        break;
                    case '9':
                        result += "玖";
                        break;
                }
            }
            string real_result = "";
            bool first = true;
            bool flag1 = false;
            bool flag2 = false;
            for (int i = result.Length - 1; i >= 0; i--) {

                if (result[i].Equals('零') && first)
                {
                    first = false;
                    j++;
                    continue;
                }
                else if (result[i].Equals('零') && result[i - 1].Equals('零'))
                {
                    j++;
                    continue;
                }
                else if (result[i].Equals('零'))
                {
                    real_result = real_result.Insert(0, "零");
                    j++;
                    continue;
                }

                if (i == result.Length - 5) {
                    real_result = real_result.Insert(0, "萬");
                    first = true;
                } else if (i == result.Length - 9) {
                    real_result = real_result.Insert(0, "億");
                    first= true;
                }
                else if (i == result.Length - 13)
                {
                    real_result = real_result.Insert(0, "兆");
                    first = true;   
                }

                if (j == 2)
                {
                    real_result = real_result.Insert(0 ,result[i] + "拾");
                    j++;
                }
                else if (j == 3)
                {
                    real_result = real_result.Insert(0, result[i] + "佰");
                    j++;
                }
                else if (j == 4)
                {
                    real_result = real_result.Insert(0, result[i] + "仟");
                    j = 1;
                }
                else {
                    real_result = real_result.Insert(0, result[i].ToString());
                    j++;
                }
            }
            int index = real_result.IndexOf("億");
            int index2 = real_result.IndexOf("兆");
            if (real_result[index + 1].Equals('萬'))
            {
                real_result = real_result.Remove(real_result.IndexOf("億") + 1, 1);
            }
            if (real_result[index2 + 1].Equals('億'))
            {
                real_result = real_result.Remove(real_result.IndexOf("兆") + 1, 1);
            }
            if (real_result[real_result.Length -1].Equals('零')) { 
                real_result = real_result.Remove(real_result.Length -1);
            }
            return real_result;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.TextLength > 14 || textBox1.Text.ToString().Contains('-'))
            {
                label4.Text = "輸入數字過長或是負數";
            }
            else {
                label4.Text = "";
            }
        }
    }
}