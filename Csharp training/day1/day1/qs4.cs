using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace day1
{
    internal class qs4
    {
        public static void main()
        {
            Console.WriteLine("Enter the number of students in the class");
            int studentCount = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < studentCount; i++)
            {
                Console.WriteLine("Welcome Student " + (i + 1));
            }
        }
    }
}