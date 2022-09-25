using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;

namespace test
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Dictionary<string, int> map = new Dictionary<string, int>();
            Int64 mx_map_count = 1;
            int count = Convert.ToInt32(Console.ReadLine());
            Random rand = new Random();
            Stack<int> A = new Stack<int>(count);
            Stack<int> B = new Stack<int>(count);
            Stack<int> C = new Stack<int>(count);
            for (int j = count; j > 0; j--)
            {
                A.Push(j);
            }
            for (int i = 1; i <= count; i++)
            {
                mx_map_count = i * mx_map_count;
            }
            honata(1, A, B ,C);
            for (int i = 0; i < count; i++)
            {
                string s = Console.ReadLine().Replace(" ", "");
                if (map.ContainsKey(s))
                {
                    Console.WriteLine("yes");
                }
                else if (s == "0") {
                    break;
                }
                else {
                    Console.WriteLine("no");
                }
            }
            /* 
         num = 1 (a-b)
         num = 2 (b-c)
         num = 3 (b-a)
         num = 4 (c-b)
         */
            void honata(int num, Stack<int> a, Stack<int> b, Stack<int> c)
            {
                Stack<int> f_a = new Stack<int>(a) as Stack<int>;
                Stack<int> new_a = new Stack<int>(f_a) as Stack<int>;
                Stack<int> f_b = new Stack<int>(b) as Stack<int>;
                Stack<int> new_b = new Stack<int>(f_b) as Stack<int>;
                Stack<int> f_c = new Stack<int>(c) as Stack<int>;
                Stack<int> new_c = new Stack<int>(f_c) as Stack<int>;
                if (new_c.Count == count)
                {
                    string s = "";
                    foreach (int x in new_c)
                    {
                        s += x.ToString();
                    }
                    if (!map.ContainsKey(s))
                    {
                        map.Add(s, 0);
                    }
                }
                switch (num) {
                    case 1:
                        if (new_a.Count != 0)
                        {
                            new_b.Push(new_a.Pop());
                            honata(1, new_a, new_b, new_c);
                            honata(2, new_a, new_b, new_c);
                        }
                        else if(b.Count != 0){
                            honata(2, new_a, new_b, new_c);
                        }
                        break;
                    case 2:
                        if (new_b.Count != 0)
                        {
                            new_c.Push(new_b.Pop());
                            honata(1, new_a, new_b, new_c);
                            honata(2, new_a, new_b, new_c);
                        }
                        else if (new_a.Count != 0)
                        {
                            honata(1, new_a, new_b, new_c);
                        }
                        break;
                }
            }

        }
    }
}