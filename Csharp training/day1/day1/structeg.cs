using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace day1
{
    struct student1
    {
        public int mathsmark;
        public int phymark;
    }
    internal class structeg
    {
        public static void main()
        {
            student1 Ram = new student1();
            Ram.mathsmark = 90;
            Ram.phymark = 100;
            student1 Raja = Ram;
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