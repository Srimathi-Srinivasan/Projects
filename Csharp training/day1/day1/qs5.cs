using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace day1
{
    internal class qs5
    {
        public static void main()
        {
            Console.WriteLine("Enter max score");
            int maxScore = Convert.ToInt32(Console.ReadLine());
            qs5 obj = new qs5();
            obj.func1(maxScore);
        }
        public void func1(int m)
        {
            for (int i = 0; i < m; i++)
            {
                Console.WriteLine("Congradulations!!!");
            }

        }
    }
}