using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1
{
    internal class SBAccount
    {
        public int AccountNumber { get; set; }
        public string AccountHolderName { get; set; }
        public string TypeofAccount { get; set; }
        public DateOnly DateofCreation { get; set; }
        public int Balance { get; set; }

        public SBAccount()
        {
            AccountNumber = 0;
            AccountHolderName = null;
            TypeofAccount = "Savings";
            DateofCreation = DateOnly.MaxValue;
            Balance = 0;
        }

        public SBAccount(int AccountNumber,int Balance)
        {
            this.AccountNumber = AccountNumber;
            this.Balance = Balance;
        }

        public SBAccount(int AccountNumber,string TypeofAccount,int Balance)
        {
            this.AccountNumber = AccountNumber;
            this.TypeofAccount = TypeofAccount;
            this.Balance = Balance;
        }

        public void GetAccountDetails()
        {
            Console.WriteLine("Enter Account number:");
            AccountNumber = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Account Holder Name:");
            AccountHolderName = Console.ReadLine();
            Console.WriteLine("Enter Type of Account:");
            TypeofAccount = Console.ReadLine();
            Console.WriteLine("Enter Date of Creation:");
            DateofCreation = DateOnly.Parse(Console.ReadLine());
            Console.WriteLine("Enter Balance:");
            Balance = Convert.ToInt32(Console.ReadLine());
        }

        public void ShowAccountDetails()
        {
            Console.WriteLine("Account Number: "+AccountNumber);
            Console.WriteLine("Account Holder Name: "+AccountHolderName);
            Console.WriteLine("Type of Account: "+TypeofAccount);
            Console.WriteLine("Date of Creation: "+DateofCreation);
            Console.WriteLine("Balance: "+Balance);
        }
    }
}
