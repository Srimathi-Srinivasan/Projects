using System;

namespace day1
{
    internal class Program
    {
        static void main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Console.WriteLine("Enter your name");
            string name = Console.ReadLine();
            Console.WriteLine("Enter marks");
            int marks = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter average");
            float avg = float.Parse(Console.ReadLine());
            Console.WriteLine("Enter dob");
            DateTime dob = Convert.ToDateTime(Console.ReadLine());
            Console.WriteLine("Enter result");
            bool result = Convert.ToBoolean(Console.ReadLine());
            Console.WriteLine("Hello " + name);
            Console.WriteLine("Marks: " + marks);
            Console.WriteLine("Average {0}", avg);
            Console.WriteLine($"dob: {dob}" + " " + $"Result: {result}");
            Console.WriteLine("dob without time: {0} and Result: {1}", dob.ToShortDateString(), result);



            string n = "mathi";
            Console.WriteLine(name + n);

        }
    }
}