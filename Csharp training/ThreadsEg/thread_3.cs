using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreadsEg
{
    internal class threads_3
    {
        static void Main()
        {
            callmethod();
            Console.ReadKey();
        }
        public static async void callmethod()
        {
            
            Task<int> task = method1();
            method2();
            int count = await task;
            method3(count);
        }
        public static async Task<int> method1()
        {
            int count = 0;
            await Task.Run(() =>
            {
                for (int i = 0; i < 100; i++)
                {
                    Console.WriteLine("method 1");
                    
                    count += 1;
                }
            });
            return count;
        }
        public static void method2()
        {
            for (int i = 0; i < 25; i++)
            {
                Console.WriteLine(" method 2");
            }
        }
        public static void method3(int count)
        {
            Console.WriteLine("total count is" + count);
        }
    }
}