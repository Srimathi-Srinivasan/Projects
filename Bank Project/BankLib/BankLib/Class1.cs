namespace BankLib
{
    public class SBAccount
    {
        public long AccountNumber;
        public string CustomerName;
        public string CustomerAddress;
        public decimal CurrentBalance;
        public DateTime DateofCreation;

        public SBAccount()
        {

        }
        public SBAccount(long accountNumber, string customerName, string customerAddress, decimal currentBalance, DateTime dateofCreation)
        {
            AccountNumber = accountNumber;
            CustomerName = customerName;
            CustomerAddress = customerAddress;
            CurrentBalance = currentBalance;
            DateofCreation = dateofCreation;
        }
    }

    public class SBTransaction
    {
        public int TransactionId;
        public DateTime TransactionDate;
        public long AccountNumber;
        public decimal Amount;
        public string TransactionType;

        public SBTransaction()
        {

        }
        public SBTransaction(int transactionId, DateTime transactionDate, long accountNumber, decimal amount, string transactionType)
        {
            TransactionId = transactionId;
            TransactionDate = transactionDate;
            AccountNumber = accountNumber;
            Amount = amount;
            TransactionType = transactionType;
        }
    }
}