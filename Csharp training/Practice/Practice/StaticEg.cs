using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice
{
    static internal class Student
    {
        public static int regno;
        public static int[] marks = { 98, 87, 78, 100, 98 };

        public static float avg() 
        {
            
            float sum = 0;
            for(int i =0;i<5;i++)
            {
                sum += marks[i];
            }
            Console.WriteLine(sum/5);
            return (sum / 5);
        }
    }

    internal class Program
    {
        public static void Main(string[] args)
        {
            //Student s = new Student(); - error - cannot create instance for static class
            Console.WriteLine("Enter regno: ");
            Student.regno = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Average: " + Student.avg());

        }
    }

    
}
