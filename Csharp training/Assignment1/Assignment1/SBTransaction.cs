using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1
{
    internal class SBTransaction
    {
        public int TransactionID { get; set; }
        public int TAccountNumber { get; set; }
        public DateOnly TransactionDate { get; set; }
        public int TransactionAmt {
            get { return TransactionAmt; }
            set
            {
                if (value < 0)
                    TransactionAmt = 0;
                else
                    TransactionAmt = value;
            }
        }
        public int NewBalance { get; set; }

        public SBTransaction()
        {
            TransactionID = 0;
            TAccountNumber = 0;
            TransactionDate = DateOnly.MaxValue;
            TransactionAmt = 0;
            NewBalance = 0;
        }

        public SBTransaction(int TransactionID,int TransactionAmt)
        {
            this.TransactionID = TransactionID;
            this.TransactionAmt = TransactionAmt;
        }

        public SBTransaction(int TransactionID,int TransactionAmt,int NewBalance)
        {
            this.TransactionID= TransactionID;
            this.TransactionAmt= TransactionAmt;
            this.NewBalance = NewBalance;
        }

        public void GetTransactionDetails()
        {
            Console.WriteLine("Enter TransactionID: ");
            TransactionID = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter TAccountNumber: ");
            TAccountNumber = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Transaction Date: ");
            TransactionDate = DateOnly.Parse(Console.ReadLine());
            Console.WriteLine("Enter Transaction Amount: ");
            TransactionAmt = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter New Balance: ");
            NewBalance = Convert.ToInt32(Console.ReadLine());
        }

        public void ShowTransactionDetails()
        {
            Console.WriteLine("Transaction ID: " + TransactionID);
            Console.WriteLine("Transaction Account Number: "+TAccountNumber);
            Console.WriteLine("Transaction Date: "+TransactionDate);
            Console.WriteLine("Transaction Amount: "+TransactionAmt);
            Console.WriteLine("New Balance: "+NewBalance);
        }
    }
}
