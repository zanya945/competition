using System;
using System.Collections.Generic;

namespace owo{

    class program {
        static void Main(string[] args) { 
            List<UInt64> store = new List<UInt64>();
            for (int i = 0; i < 93; i++) {
                if (i == 0)
                {
                    store.Add(0);
                }
                else if (i == 1)
                {
                    store.Add(1);
                }
                else {
                    store.Add(store[i - 1] + store[i - 2]);
                }
                Console.WriteLine(i+" "+store[i]);
            }
            Console.WriteLine("請輸入第一個費式數列");
            int a1 = int.Parse(Console.ReadLine());
            Console.WriteLine("請輸入第二個費式數列");
            int a2 = int.Parse(Console.ReadLine());
            UInt64 a3 = store[a1] + store[a2];
            Console.WriteLine("總合為:" + a3);
        }
    }
}
