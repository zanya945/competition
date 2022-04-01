using System;
using System.Collections.Generic;
using System.IO;

namespace work
{
    class owo
    {
        public static void Main(String[] args)
        {
            List<List<string>> test1 = new List<List<string>>();
            List<List<string>> test2 = new List<List<string>>();
            Console.WriteLine("輸入資料一");
            string pathname1 = Console.ReadLine();
            string path1 = @"F:\110_Q5\" + pathname1;
            try
            {
                test1 = new StreamReader(path1).ReadToEnd().Replace("\r\n", "\r").Split('\r').Where(v => v != "").Select(v => v.Split(' ').Where(v => v != "").ToList()).ToList();
            }
            catch { return; }
            Console.WriteLine("輸入資料二");
            string pathname2 = Console.ReadLine();
            string path2 = @"F:\110_Q5\" + pathname2;
            try
            {
                test2 = new StreamReader(path2).ReadToEnd().Replace("\r\n", "\r").Split("\r").Where(v => v != "").Select(v => v.Split(' ').Where(v => v != "").ToList()).ToList();
            }
            catch { return; }
            List<int> x1 = x(test1);
            List<int> x2 = x(test2);
            List<int> y1 = y(test1);
            List<int> y2 = y(test2);
            List<double> x_like = like(x1, x2);
            List<double> y_like = like(y1, y2);
            Console.WriteLine("step 2 Y軸投影");
            Console.WriteLine(pathname1 + " Y軸投影量 :");
            for (int i = 0; i < y1.Count; i++) {
                Console.Write(i.ToString().PadLeft(2, ' ')+" ");
            }
            Console.WriteLine();
            for (int i = 0; i < y1.Count; i++)
            {
                Console.Write(y1[i].ToString().PadLeft(2, ' ')+ " ");
            }
            Console.WriteLine();
            Console.WriteLine(pathname2 + " Y軸投影量 :");
            for (int i = 0; i < y1.Count; i++)
            {
                Console.Write(i.ToString().PadLeft(2, ' ') + " "); ;
            }
            Console.WriteLine();
            for (int i = 0; i < y2.Count; i++)
            {
                Console.Write(y2[i].ToString().PadLeft(2, ' ')+ " ");
            }
            Console.WriteLine();
            Console.WriteLine("X軸投影");
            Console.WriteLine(pathname1 + " X軸投影量 :");
            for (int i = 0; i < x1.Count; i++)
            {
                Console.Write(i.ToString().PadLeft(2, ' ') + " ");
            }
            Console.WriteLine();
            for (int i = 0; i < x1.Count; i++)
            {
                Console.Write(x1[i].ToString().PadLeft(2, ' ') + " ");
            }
            Console.WriteLine();
            Console.WriteLine(pathname2 + " X軸投影量 :");
            for (int i = 0; i < x1.Count; i++)
            {
                Console.Write(i.ToString().PadLeft(2, ' ') + " "); 
            }
            Console.WriteLine();
            for (int i = 0; i < y2.Count; i++)
            {
                Console.Write(x2[i].ToString().PadLeft(2, ' ') + " ");
            }
            Console.WriteLine();
            Console.WriteLine("step 3 相似度");
            Console.WriteLine("y軸的兩個圖形之座標的相似度");
            int count = y_like.Count/2;
            for (int i = 0; i < count; i++)
            {
                Console.Write(i.ToString().PadLeft(6, ' ') + " ");
            }
            Console.WriteLine();
            for (int i = 0; i < count; i++)
            {
                Console.Write(y_like[i].ToString().PadLeft(6, ' ') + " ");
            }
            Console.WriteLine();
            for (int i = count; i < y_like.Count; i++)
            {
                Console.Write(i.ToString().PadLeft(6, ' ') + " ");
            }
            Console.WriteLine();
            for (int i = count; i < y_like.Count ; i++)
            {
                Console.Write(y_like[i].ToString().PadLeft(6, ' ') + " ");
            }
            Console.WriteLine();
            Console.WriteLine("x軸的兩個圖形之座標的相似度");
            int count1 = x_like.Count/2;
            for (int i = 0; i < count1; i++)
            {
                Console.Write(i.ToString().PadLeft(6, ' ') + " ");
            }
            Console.WriteLine();
            for (int i = 0; i < count1; i++)
            {
                Console.Write(x_like[i].ToString().PadLeft(6, ' ') + " ");
            }
            Console.WriteLine();
            for (int i = count1; i < x_like.Count; i++)
            {
                Console.Write(i.ToString().PadLeft(6, ' ') + " ");
            }
            Console.WriteLine();
            for (int i = count1; i < x_like.Count; i++)
            {
                Console.Write(x_like[i].ToString().PadLeft(6, ' ') + " ");
            }
            double y_l = y_like.Sum() / y_like.Count();
            double x_l = x_like.Sum() / x_like.Count();
            double total = y_l * x_l ;
            Console.WriteLine();
            Console.WriteLine("求平均似度: 垂直相似度 "+ Math.Round(x_l, 5) +" 水平相似度 "+Math.Round(y_l, 5));
            Console.WriteLine("總相似度:"+Math.Round(total, 6));
            static List<double> like(List<int> a,List<int> b)
            {
                List<double> result = new List<double>();
                for (int i = 0; i < a.Count; i++) {
                    double a_dou = a[i];
                    double b_dou = b[i];
                    double res = a_dou / b_dou;
                    if (res <= 1)
                    {
                        res = res;
                    }
                    else {
                        res = b_dou / a_dou;
                    }
                    result.Add(Math.Round(res, 3));
                }
                return result;
            }
            static List<int> x(List<List<string>> a)
            {
                int garde = 1;
                List<int> x_l = new List<int>();
                for (int i = 0; i < a[0].Count; i++)
                {
                    garde = 1;
                    for (int j = 0; j < a.Count; j++)
                    {
                        if (a[j][i] == "0")
                        {
                            garde++;
                        }
                    }
                    x_l.Add(garde);
                }
                return x_l;
            }
            static List<int> y(List<List<string>> a)
            {
                int garde = 1;
                List<int> y_l = new List<int>();
                for (int i = 0; i < a.Count; i++)
                {
                    garde = 1;
                    for (int j = 0; j < a[1].Count; j++)
                    {
                        if (a[i][j] == "0")
                        {
                            garde++;
                        }
                    }
                    y_l.Add(garde);
                }
                return y_l;
            }
        }
    }
}