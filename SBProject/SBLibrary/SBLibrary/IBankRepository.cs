using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBLibrary
{
    public interface IBankRepository
    {
        void NewAccount(SBAccount acc);
        SBAccount GetAccountDetails(int accno);
        List<SBAccount> GetAllAccounts();
        void DepositAmount(int accno,decimal amount);
        void WithdrawAmount(int accno,decimal amount);
        List<SBTransaction> GetAllTransactions(int accno);
    }
}
