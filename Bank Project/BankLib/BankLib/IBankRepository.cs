using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace BankLib
{
    public interface IBankRepository
    {
        long NewAccount(SBAccount acc);
        SqlDataReader GetAccountDetails(long accno);
        DataTable GetAllAccounts();
        decimal DepositAmount(long accno, decimal amount);
        decimal WithdrawAmount(long accno,decimal amount);
        List<SBTransaction> GetAllTransactions(long accno);
    }
}
