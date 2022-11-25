using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace day1
{
    internal class qs3
    {
        public static void main()
        {
            Console.WriteLine("Enter your 10 digit account number");
            long accNum = Convert.ToInt64(Console.ReadLine());
            const int balance = 5000;
            Console.WriteLine("For Deposit enter 1 and for withdrawal enter 2");
            int choice = Convert.ToInt32(Console.ReadLine());
            int newBalance, amt;
            switch (choice)
            {
                case 1:
                    Console.WriteLine("Enter amount to be deposited");
                    amt = Convert.ToInt32(Console.ReadLine());
                    newBalance = balance + amt;
                    Console.WriteLine("New balance:" + newBalance);
                    break;
                case 2:
                    Console.WriteLine("Enter amount to be withdrawn");
                    amt = Convert.ToInt32(Console.ReadLine());
                    newBalance = balance - amt;
                    Console.WriteLine("New balance:" + newBalance);
                    break;
            }
        }



    }
}