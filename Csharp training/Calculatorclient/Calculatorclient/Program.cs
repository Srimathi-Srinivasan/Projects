using System;
using calculatorlib;

namespace Calculatorclient
{
    internal class Program
    {
        public static calculator cal = new calculator();
        public static void Main()
        {
            Console.WriteLine(cal.message(" Sri")); 
            Console.WriteLine("Add: "+ cal.add(2, 4));
            
            Console.WriteLine("Sub: "+ cal.sub(2, 4));
            
        }
    }
}
