using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace day1
{
    internal class qs2
    {
        public static void main()
        {
            Console.WriteLine("Enter dob");
            DateTime dob = Convert.ToDateTime(Console.ReadLine());
            //DateTime today = DateTime.Today;
            //DateTime now = Convert.ToDateTime(today.ToShortDateString());
            //Console.WriteLine(today.ToShortDateString());
            //Console.WriteLine(now);
            //DateTime age = now.Subtract(dob).Days;

            DateTime now = DateTime.Now;
            //Console.WriteLine(now.Day);
            int age = now.Subtract(dob).Days;
            //Console.WriteLine(age);
            Console.WriteLine("age: " + age / 365);

            //Console.WriteLine(dob.Year);

            int year = dob.Year;
            if (year % 400 == 0)
            {
                Console.WriteLine("Leap year");
            }
            else if (year % 100 == 0)
            {
                Console.WriteLine("Leap year");

            }
            else if (year % 4 == 0)
            {
                Console.WriteLine("Leap year");

            }
            else
            {
                Console.WriteLine("Not a leap year");
            }

        }
    }
}