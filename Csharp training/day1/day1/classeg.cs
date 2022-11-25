using System;


namespace day1
{
    class student
    {
        public int mathsmark;
        public int phymark;
    }
    internal class Classeg
    {
        public static void Main()
        {
            student Ram = new student();
            Ram.mathsmark = 90;
            Ram.phymark = 100;
            student Raja = Ram;
            Console.WriteLine("Ram phy marks:" + Ram.phymark);
            Console.WriteLine("Ram mathsmark:" + Ram.mathsmark);
            Console.WriteLine("Ram phy marks:" + Raja.phymark);
            Console.WriteLine("Ram mathsmark:" + Raja.mathsmark);
            Ram.mathsmark = 95;
            Ram.phymark = 98;
            Console.WriteLine("Ram phy marks:" + Ram.phymark);
            Console.WriteLine("Ram mathsmark:" + Ram.mathsmark);
            Console.WriteLine("Ram phy marks:" + Raja.phymark);
            Console.WriteLine("Ram mathsmark:" + Raja.mathsmark);
        }

    }
}