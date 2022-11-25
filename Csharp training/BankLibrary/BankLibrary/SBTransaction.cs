using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankLibrary
{
    internal class SBTransaction
    {
        public int TransactionId;
        public DateOnly TransactionDate;
        public int AccountNumber;
        public float Amount;
        public string TransactionType;
    }
}
