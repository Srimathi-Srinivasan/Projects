using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace day1
{
    internal class qs1
    {
        public static void main()
        {
            Console.WriteLine("Enter student name");
            string name = Console.ReadLine();
            Console.WriteLine("Enter the marks");
            int m1, m2, m3, m4, m5;
            m1 = Convert.ToInt32(Console.ReadLine());
            m2 = Convert.ToInt32(Console.ReadLine());
            m3 = Convert.ToInt32(Console.ReadLine());
            m4 = Convert.ToInt32(Console.ReadLine());
            m5 = Convert.ToInt32(Console.ReadLine());
            float avg = (m1 + m2 + m3 + m4 + m5) / 5;
            Console.WriteLine("Average: " + avg);
            if (avg > 90 && avg <= 100)
            {
                Console.WriteLine("Outstanding");
            }
            else if (avg > 65 && avg <= 90)
            {
                Console.WriteLine("Excellent");
            }
            else if (avg > 40 && avg <= 65)
            {
                Console.WriteLine("Good");
            }
            else
            {
                Console.WriteLine("Fail");
            }
        }
    }
}