using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankLibrary
{
    internal interface IBankRepository
    {
        public void NewAccount(SBAccount acc);
        public SBAccount GetAccountDetails(int accno);
        public List<SBAccount> GetAllAccounts();
        public void DepositAmount(int accno, decimal amt);
        public void WithdrawalAmount(int accno, decimal amt);
        List<SBTransaction> GetAllTransactions(int accno);
    }
}
