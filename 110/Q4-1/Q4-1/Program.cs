using System;
using System.Drawing;

namespace owo
{

    class Program
    {
        static void Main(string[] args)
        {
            List<List<int>> map = new List<List<int>>();
            map = Console.ReadLine().Replace("[", "").Replace("]", ".").Split(".").Where(v => v != "").Select(v => v.Split(",").Where(v => v != "").Select(v => int.Parse(v)).ToList()).ToList();
            Console.WriteLine("數學地圖為");
            for (int i = 0; i < map.Count; i++)
            {
                Console.WriteLine("\t" + "[" + String.Join(",", map[i]) + "]");
            }
            Point[] go = new Point[] { new Point(0, 1), new Point(1, 0) };
            Point end = new Point(map[0].Count - 1, map.Count - 1);
            Queue<List<Point>> road = new Queue<List<Point>>();
            road.Enqueue(new List<Point>() { new Point(0, 0) });
            List<List<Point>> ans = new List<List<Point>>();
            List<int> grade = new List<int>();
            while (road.Count() != 0)
            {
                List<Point> road1 = road.Dequeue();
                for (int i = 0; i < go.Length; i++)
                {
                    int x = road1.Last().X + go[i].X;
                    int y = road1.Last().Y + go[i].Y;
                    if (x >= 0 || x < map[0].Count() || y >= 0 || y < map.Count || road1.IndexOf(new Point(x, y)) == -1)
                    {
                        List<Point> road2 = new List<Point>(road1);
                        road2.Add(new Point(x, y));
                        if (road2.Last() == end)
                        {
                            ans.Add(road2);
                        }
                        else if (road2.Count < (map[0].Count - 1 + map.Count))
                        {
                            road.Enqueue(road2);
                        }
                    }
                }
            }

            if (map[0].Count + map.Count <= 8)
            {
                Console.WriteLine("所有路徑為:");
                for (int i = 0; i < ans.Count; i++)
                {
                    Console.WriteLine("[" + String.Join(",", ans[i].Select(v => map[v.Y][v.X])) + "]");
                }
            }
            Console.WriteLine("最短的路徑為");
            grade = ans.Select(v => v.Select(v => map[v.Y][v.X]).Sum()).ToList();
            int short1 = grade.IndexOf(grade.Min());
            List<Point> ans1 = ans[short1];
            Console.WriteLine("["+string.Join(",",ans1.Select(v => map[v.Y][v.X]))+"]");
            Console.WriteLine("最短路徑和:" + grade[short1]);

        }

    }
}