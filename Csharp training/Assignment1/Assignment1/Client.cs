using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1
{
    internal class Client
    {
        public static void Main()
        {
            SBAccount s1 = new SBAccount();
            s1.ShowAccountDetails();
            
            SBAccount s2 = new SBAccount(1,1000);
            s2.ShowAccountDetails();

            SBAccount s3 = new SBAccount(1, "Savings", 1000);
            s3.ShowAccountDetails();

            SBAccount s4 = new SBAccount();
            s4.GetAccountDetails();
            s4.ShowAccountDetails();

            SBTransaction t1 = new SBTransaction();
            t1.ShowTransactionDetails();

            SBTransaction t2 = new SBTransaction(101, 2000);
            t2.ShowTransactionDetails();

            SBTransaction t3 = new SBTransaction(101, 2000, 5000);
            t3.ShowTransactionDetails();

            SBTransaction t4 = new SBTransaction();
            t4.GetTransactionDetails();
            t4.ShowTransactionDetails();
            
        }
       
    }
}
