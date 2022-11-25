using BankLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankProject
{
    internal class BankRepository : IBankRepository
    {
        List<SBAccount> accounts = new List<SBAccount>();
        List<SBTransaction> transactions = new List<SBTransaction>();

        class AccountNumberInvalidException : ApplicationException
        {
            public AccountNumberInvalidException(string message) : base(message)
            {

            }
        }
        //public void DepositAmount(int accno, decimal amount)
        //{
        //    throw new NotImplementedException();
        //}

        public SBAccount GetAccountDetails(long accno)
        {
            
            foreach(SBAccount account in accounts)
            {
                if (account.AccountNumber == accno)
                {
                    return account;
                }

            }
            throw new AccountNumberInvalidException("Account Number is Invalid!!!");
        }

        //public List<SBAccount> GetAllAccounts()
        //{
        //    throw new NotImplementedException();
        //}

        //public List<SBTransaction> GetAllTransactions(int accno)
        //{
        //    throw new NotImplementedException();
        //}

        public void NewAccount(SBAccount acc)
        {
            Random rnd = new Random();
            acc.AccountNumber = rnd.NextInt64();
            Console.WriteLine("Enter Customer Name: ");
            acc.CustomerName = Console.ReadLine();
            Console.WriteLine("Enter Customer Address: ");
            acc.CustomerAddress = Console.ReadLine();
            acc.CurrentBalance = 0;

            accounts.Add(new SBAccount(acc.AccountNumber,acc.CustomerName,acc.CustomerAddress,acc.CurrentBalance));
            Console.WriteLine("New Account created!!!");
            Console.WriteLine("Account Number: "+acc.AccountNumber);

        }

        //public void WithdrawAmount(int accno, decimal amount)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
