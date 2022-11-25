using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace BankLib
{
    public class BankRepository : IBankRepository
    {       

        public static SqlConnection con;
        public static SqlCommand cmd;
        decimal amt;
        Random rnd = new Random();
        SBTransaction t = new SBTransaction();
        SBAccount acc = new SBAccount();

        List<SBTransaction> sBTransactions = new List<SBTransaction>();


        public decimal DepositAmount(long accno, decimal amount)
        {
            con = getcon();
            cmd = new SqlCommand("spdepositamt");
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Connection = con;

            cmd.Parameters.AddWithValue("@Account_Number", accno);
            cmd.Parameters.AddWithValue("@amount", amount);
            cmd.ExecuteNonQuery();

            
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
            return amt;

            //throw new NotImplementedException();
        }


        public SqlDataReader GetAccountDetails(long accno)
        {                              
            SqlDataReader dr = checkaccount(accno);
            if(dr != null)
            {
                return dr;
            }
            return null;
        }


        public DataTable GetAllAccounts()
        {
            con = getcon();
            cmd = new SqlCommand("spgetallaccounts",con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            DataTable dt = ds.Tables[0];
            if(dt!=null)
            {
                return dt;
            }
            else
            {
                return null;
            }
            
            //return accounts;
            //throw new NotImplementedException();
        }

        public List<SBTransaction> GetAllTransactions(long accno)
        {
            con = getcon();
            cmd = new SqlCommand("sptransactiondetails", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Account_Number", accno);
            cmd.ExecuteNonQuery();
            #region
            //SqlDataAdapter da = new SqlDataAdapter(cmd);
            //DataSet ds = new DataSet();
            //da.Fill(ds);

            ////DataTable dt = ds.Tables[0];
            //DataTable dt = new DataTable();

            //dt.Columns.Add("TransactionId", typeof(Int32));
            //dt.Columns.Add("TransactionDate", typeof(DateTime));
            //dt.Columns.Add("Amount", typeof(Decimal));
            //dt.Columns.Add("TransactionType", typeof(String));

            //dt = ds.Tables[0];

            //for (int i=0;i<dt.Rows.Count;i++)
            //{
            //    t.TransactionId = Convert.ToInt32(dt.Rows[i]["TransactionId"]);
            //    t.TransactionDate = Convert.ToDateTime(dt.Rows[i]["TransactionDate"]);
            //    t.Amount = Convert.ToDecimal(dt.Rows[i]["Amount"]);
            //    t.TransactionType = dt.Rows[i]["TransactionType"].ToString();
            //    sBTransactions.Add(t);
            //}
            #endregion

            SqlDataReader dr = cmd.ExecuteReader();
            while(dr.Read())
            {
                SBTransaction t = new SBTransaction();
                t.TransactionId = Convert.ToInt32(dr["Transaction_ID"]);
                t.TransactionDate = Convert.ToDateTime(dr["Transaction_Date"]);
                t.AccountNumber = accno;
                t.Amount = Convert.ToDecimal(dr["Amount"]);
                t.TransactionType = (string)dr["Transaction_Type"];
                sBTransactions.Add(t);
            }
            return sBTransactions;
            

            //foreach (DataRow dr in dt.Rows)
            //{
            //    foreach (var item in dr.ItemArray)
            //    {
                    
            //        Console.Write(item + "        ");
            //    }
            //    Console.WriteLine();
            //}
            //throw new NotImplementedException();
        }

        public long NewAccount(SBAccount acc)
        {
            
            acc.AccountNumber = rnd.NextInt64(5000000000, 5999999999);
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

                cmd.Parameters.AddWithValue("@Account_Number",acc.AccountNumber);
                cmd.Parameters.AddWithValue("@Customer_Name", acc.CustomerName);
                cmd.Parameters.AddWithValue("@Customer_Address", acc.CustomerAddress);
                cmd.Parameters.AddWithValue("@Current_Balance", acc.CurrentBalance);
                cmd.Parameters.AddWithValue("@Date_Of_Creation", acc.DateofCreation);
                                
                cmd.ExecuteNonQuery();
                //Console.WriteLine(i + " number of row(s) affected ");
                return acc.AccountNumber;

            }
            else
            {                
                return 0;
            }
            
        }

        private static SqlConnection getcon()
        {
            con = new SqlConnection("Data Source=.;Initial Catalog = BankDB;Integrated Security=true");
            con.Open();
            return con;
        }


        public decimal WithdrawAmount(long accno, decimal amount)
        {
            con = getcon();
            cmd = new SqlCommand("spwithdrawamt",con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            
            cmd.Parameters.AddWithValue("@Account_Number", accno);
            cmd.Parameters.AddWithValue("@amount", amount);
            cmd.ExecuteNonQuery();

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
            
            return amt;
        }

        public SqlDataReader checkaccount(long accno)
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


    }

}
