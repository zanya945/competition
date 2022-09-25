
namespace owo
{
    class owo
    {

        public static void Main(String[] args)
        {
            bool finish = false;
            bool error = false;
            bool oversisze = false;
            List<List<string>> path2 = new List<List<string>>();
            UInt64 result = 1;
            string answer = "";
            while (true)
            {
                Console.WriteLine("請輸入運算式");
                string owo = "";
                answer = "";
                while (true)
                {
                    path2.Clear();
                    result = 1;
                    ConsoleKeyInfo key = Console.ReadKey();
                    if (key.KeyChar >= 48 && key.KeyChar <= 57 || key.KeyChar == 43 || key.KeyChar == 42)
                    {
                        owo += key.KeyChar;
                    }
                    else if (key.KeyChar == 64)
                    {
                        finish = true;
                        break;
                    }
                    else if (key.KeyChar == 13)
                    {
                        break;
                    }
                    else if (key.KeyChar == 8)
                    {

                    }
                    else
                    {
                        error = true;
                        break;
                    }
                }
                if (finish)
                {
                    break;
                }
                else
                {
                    Console.WriteLine(owo);
                }
                if (error)
                {
                    error = false;
                    Console.WriteLine("輸入錯誤");
                    continue;
                }
                else
                {
                    string[] path1 = owo.Split('*');
                    for (int i = 0; i < path1.Length; i++)
                    {
                        path2.Add(path1[i].Split("+").ToList());
                        if (i != 0)
                        {
                            for (int j = 0; j < path2.Count; j++)
                            {
                                UInt64 start = 1;
                                UInt64 end = 1;
                                if (path2[i - 1].Count != 0 && path2[i - 1][path2[i - 1].Count - 1] != "0")
                                {
                                    start = UInt64.Parse(path2[i - 1].Last());
                                    //                                    if (start > 2147483648){
                                    //                                        oversisze = true;
                                    //                                        break;
                                    //                                    }
                                    path2[i - 1][path2[i - 1].Count - 1] = "0";
                                }
                                if (path2[i].Count != 0 && path2[i][path2[i].Count - 1] != "0")
                                {

                                    end = UInt64.Parse(path2[i][0]);
                                    //                                    if (end > 2147483648)
                                    //                                    {
                                    //                                        oversisze = true;
                                    //                                        break;
                                    //                                    }
                                    path2[i][0] = "0";
                                }
                                if (start == 0)
                                {
                                    result = result * end;
                                }
                                else if (end == 0)
                                {
                                    result = result * start;
                                }
                                else
                                {
                                    result = result * start * end;
                                }

                            }
                        }
                        if (path1.Count() == 1)
                        {
                            result = uint.Parse(path1[i]);
                        }
                        if (oversisze)
                        {
                            Console.WriteLine("輸入數字過大");
                            break;
                        }
                    }
                    foreach (List<string> list in path2)
                    {
                        foreach (string item in list)
                        {
                            Int64 num = Int64.Parse(item);
                            //                            if (num > 2147483648) {
                            //                                break;
                            //                            }
                            result = result + uint.Parse(item);
                        }
                    }
                    if (oversisze) { }
                    else if (result.ToString().Count() > 4)
                    {
                        answer = result.ToString();
                        string new1 = "";
                        for (int i = answer.Length - 4; i < answer.Length; i++)
                        {
                            new1 += answer[i];
                        }
                        int awa = int.Parse(new1);
                        answer = awa.ToString();
                    }
                    else
                    {
                        answer = result.ToString();
                    }
                }
                Console.WriteLine("運算結果" + answer);
            }
        }
    }
}
