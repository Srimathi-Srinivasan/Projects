using NUnit.Framework;
using SBLibrary;

namespace SBLibraryTest
{
    public class Tests
    {
        public IBankRepository Iobj;

        [SetUp]        
        public void Setup()
        {
            Iobj = new BankRepository();
        }

        [Test]
        public void GetAccountDetailsTest()
        {
            SBAccount s = new SBAccount();
            s = Iobj.GetAccountDetails(1196243924);
            string actres = s.CustomerName;
            string expres = "Arun";
            Assert.AreEqual(expres,actres);
        }

        [Test]
        public void GetAccountDetailsFailTest()
        {
            SBAccount s = new SBAccount();
            s = Iobj.GetAccountDetails(11962439);
            SBAccount expres = null;
            Assert.AreEqual(expres, s);
        }

        [Test]
        public void GetAllTransactionsTest()
        {
            List<SBTransaction> transaction = Iobj.GetAllTransactions(1196243924);
            SBTransaction obj = new SBTransaction();
            foreach(SBTransaction t in transaction)
            {
                obj.TransactionId = t.TransactionId;
                obj.TransactionDate = t.TransactionDate;
                obj.TransactionType = t.TransactionType;
                obj.AccountNumber = t.AccountNumber;
                obj.Amount = t.Amount;
            }
            int actres = obj.TransactionId;
            int expres = 139100;
            Assert.AreEqual(expres, actres);
        }


    }
}