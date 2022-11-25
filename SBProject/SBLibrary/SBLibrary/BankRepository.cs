using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace SBLibrary
{
    public class BankRepository : IBankRepository
    {
        List<SBAccount> accounts = new List<SBAccount>();
        List<SBTransaction> transactions = new List<SBTransaction>();

        

        public static SqlConnection con;
        public static SqlCommand cmd;

        Random rnd = new Random();
        decimal amt;

        public void NewAccount(SBAccount acc)
        {
            acc.AccountNumber = rnd.Next(1000000000, 1999999999);
            
            
            int i = 0;
            string option;
                do
                {
                    Console.WriteLine("Enter Customer Name: ");
                    acc.CustomerName = Console.ReadLine();
                    if (acc.CustomerName.All(Char.IsLetter))
                    {
                        
                        Console.WriteLine("Enter Customer Address: ");
                        acc.CustomerAddress = Console.ReadLine();
                        acc.CurrentBalance = 0;
                        acc.DateofCreation = DateTime.Now;


                        con = getcon();
                        cmd = new SqlCommand("spnewaccount");
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Connection = con;

                        cmd.Parameters.AddWithValue("@Account_Number", acc.AccountNumber);
                        cmd.Parameters.AddWithValue("@Customer_Name", acc.CustomerName);
                        cmd.Parameters.AddWithValue("@Customer_Address", acc.CustomerAddress);
                        cmd.Parameters.AddWithValue("@Current_Balance", acc.CurrentBalance);
                        cmd.Parameters.AddWithValue("@Date_Of_Creation", acc.DateofCreation);

                        cmd.ExecuteNonQuery();
                        //Console.WriteLine(i + " number of row(s) affected ");
                        //return acc.AccountNumber;
                        Console.WriteLine("Account Created!");
                        Console.WriteLine("Account Number: " + acc.AccountNumber);
                        break;

                    }
                    else
                    {
                        Console.WriteLine("Customer Name should contain only Alphabets!");
                        if (i == 2)
                        {
                            break;
                        }
                        Console.WriteLine("Do you want to try again? (Y/N)");
                        option = Console.ReadLine();
                        if (option is "N" || option is "n")
                        {
                            break;
                        }
                        else if(option is "Y" || option is "y")
                        {
                            i++;
                        }
                        else
                        {
                            Console.WriteLine("Invalid option!");
                            i = 3;
                        }
                        
                        //if (i == 2)
                        //    break;
                        //return 0;
                    }
                } while (i<3);
            
                if(i == 2 || i == 3)
                {
                    Console.WriteLine("Account not created,Try after Sometime");
                }
            
            //throw new NotImplementedException();
        }

        private static SqlConnection getcon()
        {
            con = new SqlConnection("Data Source=.;Initial Catalog = StateBankDB;Integrated Security=true");
            con.Open();
            return con;
        }

        public SBAccount GetAccountDetails(int accno)
        {
            #region

            //con = getcon();
            //cmd = new SqlCommand("spgetaccountdetails");
            //cmd.CommandType = System.Data.CommandType.StoredProcedure;
            //cmd.Connection = con;

            //cmd.Parameters.AddWithValue("@Account_Number", accno);

            //SqlDataReader dr = cmd.ExecuteReader();
            //if (dr != null)
            //{
            //    while (dr.Read())
            //    {
            //        SBAccount acc = new SBAccount();
            //            acc.AccountNumber = accno;
            //            acc.CustomerName = (string)dr["Customer_Name"];
            //            acc.CustomerAddress = (string)dr["Customer_Address"];
            //            acc.CurrentBalance = Convert.ToDecimal(dr["Current_Balance"]);
            //            acc.DateofCreation = Convert.ToDateTime(dr["Date_Of_Creation"]);
            //            return acc;                 

            //    }
            //}
            #endregion
            con = getcon();
            cmd = new SqlCommand("spgetallaccounts");
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Connection = con;
            SqlDataReader dr = cmd.ExecuteReader();

            if (dr != null)
            {
                while (dr.Read())
                {
                    SBAccount acc = new SBAccount();
                    acc.AccountNumber = (int)dr["Account_Number"];
                    acc.CustomerName = (string)dr["Customer_Name"];
                    acc.CustomerAddress = (string)dr["Customer_Address"];
                    acc.CurrentBalance = Convert.ToDecimal(dr["Current_Balance"]);
                    acc.DateofCreation = Convert.ToDateTime(dr["Date_Of_Creation"]);
                    accounts.Add(acc);
                    //return acc;

                }
            }
            
                SBAccount res = (from i in accounts
                           where i.AccountNumber == accno
                           select i).SingleOrDefault();
                return res;
            
                
                //foreach(var i in res)
                //{
                //    Console.WriteLine(i.AccountNumber);
                //    Console.WriteLine(i.CustomerName);
                //    Console.WriteLine(i.CustomerAddress);
                //    Console.WriteLine(i.CurrentBalance);
                //    Console.WriteLine(i.DateofCreation);
                //}
                //foreach(var i in res)
                //{
                //    return i;
                //}
                //return (SBAccount)res;
                
            

            //return null;
            
            
        }

        public SqlDataReader checkaccount(int accno)
        {
            con = getcon();
            cmd = new SqlCommand("spgetaccountdetails");
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Connection = con;

            cmd.Parameters.AddWithValue("@Account_Number", accno);

            SqlDataReader dr = cmd.ExecuteReader();

            if (dr != null)
            {
                while (dr.Read())
                {
                    return dr;
                }
            }

            //Console.WriteLine("Account Number not found!");
            return null;
        }

        public List<SBAccount> GetAllAccounts()
        {
            con = getcon();
            cmd = new SqlCommand("spgetallaccounts", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                SBAccount acc = new SBAccount();
                acc.AccountNumber = Convert.ToInt32(dr["Account_Number"]);
                acc.CustomerName = (string)dr["Customer_Name"];
                acc.CustomerAddress = (string)dr["Customer_Address"];
                acc.CurrentBalance = Convert.ToDecimal(dr["Current_Balance"]);
                acc.DateofCreation = Convert.ToDateTime(dr["Date_Of_Creation"]);
                accounts.Add(acc);
            }
            return accounts;
            
        }

        public void DepositAmount(int accno, decimal amount)
        {
            con = getcon();
            cmd = new SqlCommand("spdepositamt");
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Connection = con;

            cmd.Parameters.AddWithValue("@Account_Number", accno);
            cmd.Parameters.AddWithValue("@amount", amount);
            cmd.ExecuteNonQuery();

            SBTransaction t = new SBTransaction();

            t.TransactionId = rnd.Next(100000, 199999);
            t.TransactionDate = DateTime.Now;
            t.AccountNumber = accno;
            t.Amount = amount;
            t.TransactionType = "Deposit";

            cmd = new SqlCommand("sptransaction", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Transaction_ID", t.TransactionId);
            cmd.Parameters.AddWithValue("@Transaction_Date", t.TransactionDate);
            cmd.Parameters.AddWithValue("@Account_Number", t.AccountNumber);
            cmd.Parameters.AddWithValue("@Amount", t.Amount);
            cmd.Parameters.AddWithValue("@Transaction_Type", t.TransactionType);
            cmd.ExecuteNonQuery();

            amt = checkbalance(accno);
            Console.WriteLine("Rs. " + amount + " deposited in Account Number " + accno);
            Console.WriteLine("New Balance: " + amt);
            
        }

        public decimal checkbalance(long accno)
        {
            con = getcon();
            cmd = new SqlCommand("spnewbalance", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Account_Number", accno);
            cmd.ExecuteNonQuery();
            amt = Convert.ToDecimal(cmd.ExecuteScalar());
            return amt;
        }

        public void WithdrawAmount(int accno, decimal amount)
        {
            con = getcon();
            cmd = new SqlCommand("spwithdrawamt", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Account_Number", accno);
            cmd.Parameters.AddWithValue("@amount", amount);
            cmd.ExecuteNonQuery();

            SBTransaction t = new SBTransaction();

            t.TransactionId = rnd.Next(100000, 199999);
            t.TransactionDate = DateTime.Now;
            t.AccountNumber = accno;
            t.Amount = amount;
            t.TransactionType = "Withdrawal";

            cmd = new SqlCommand("sptransaction", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Transaction_ID", t.TransactionId);
            cmd.Parameters.AddWithValue("@Transaction_Date", t.TransactionDate);
            cmd.Parameters.AddWithValue("@Account_Number", t.AccountNumber);
            cmd.Parameters.AddWithValue("@Amount", t.Amount);
            cmd.Parameters.AddWithValue("@Transaction_Type", t.TransactionType);
            cmd.ExecuteNonQuery();

            amt = checkbalance(accno);
            Console.WriteLine("Rs." + amount + " withdrawn from Account Number " + accno);
            Console.WriteLine("New Balance: " + amt);

            
        }

        public List<SBTransaction> GetAllTransactions(int accno)
        {
            con = getcon();
            cmd = new SqlCommand("sptransactiondetails", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Account_Number", accno);
            cmd.ExecuteNonQuery();
           
            SqlDataReader dr = cmd.ExecuteReader();
            while(dr.Read())
            {
                SBTransaction t = new SBTransaction();
                t.TransactionId = Convert.ToInt32(dr["Transaction_ID"]);
                t.TransactionDate = Convert.ToDateTime(dr["Transaction_Date"]);
                t.AccountNumber = accno;
                t.Amount = Convert.ToDecimal(dr["Amount"]);
                t.TransactionType = (string)dr["Transaction_Type"];
                transactions.Add(t);

            }
            return transactions;         

        }

    }
}
