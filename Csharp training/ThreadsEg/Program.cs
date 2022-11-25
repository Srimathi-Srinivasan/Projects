using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;


namespace ThreadsEg
{
    internal class program
    {
        int a, b;

        public void add()
        {
            Console.WriteLine("enter 2 numbers ");
            int.TryParse(Console.ReadLine(), out a);
            int.TryParse(Console.ReadLine(), out b);
            Thread.Sleep(3000);
            Console.WriteLine(a + b);

        }
        public void sub()
        {
            Console.WriteLine("enter 2 numbers ");
            int.TryParse(Console.ReadLine(), out a);
            int.TryParse(Console.ReadLine(), out b);
            Thread.Sleep(3000);
            Console.WriteLine(a - b);
        }
        static void main(string[] args)
        {
            program p = new program();
            Thread t1 = new Thread(new ThreadStart(p.add));
            t1.Start();
            Thread t2 = new Thread(new ThreadStart(p.sub));
            Thread.Sleep(4000);
            t2.Start();
            Console.WriteLine("Hello world ");
        }
    }
}