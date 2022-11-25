using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankLibrary
{
    internal class BankRepository: IBankRepository
    {
        List<SBAccount> account = new List<SBAccount>();
        List<SBTransaction> transaction = new List<SBTransaction>();

        public void DepositAmount(int accno, decimal amt)
        {
            throw new NotImplementedException();
        }

        public SBAccount GetAccountDetails(int accno)
        {
            foreach (SBAccount acc in account)
            {
                if(acc.AccountNumber == accno)
                {
                    return acc;
                }
            }
        }

        public List<SBAccount> GetAllAccounts()
        {
            throw new NotImplementedException();
        }

        public List<SBTransaction> GetAllTransactions(int accno)
        {
            throw new NotImplementedException();
        }

        
        public void NewAccount(SBAccount acc)
        {
            Console.WriteLine("Enter Account Number: ");
            acc.AccountNumber = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Customer Name: ");
            acc.CustomerName = Console.ReadLine();
            Console.WriteLine("Enter Customer Address: ");
            acc.CustomerAddress = Console.ReadLine();
            Console.WriteLine("Enter Current Balance: ");
            acc.CurrentBalance = float.Parse(Console.ReadLine());

            account.Add(acc);
        }

        public void WithdrawalAmount(int accno, decimal amt)
        {
            throw new NotImplementedException();
        }
    }
}
