using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankLib;
using System.Data.SqlClient;
using System.Data;

namespace BankProj
{
    internal class BankClient
    {
        public static List<SBTransaction> transactions = new List<SBTransaction>();
        public static void Main()
        {
            Console.WriteLine("Welcome!!!");
            Console.WriteLine("Enter your choice: " +
                                "\n1: To create New Account" +
                                "\n2: Get Account Details" +
                                "\n3: Get All Account Details" +
                                "\n4: Deposit Amount"+
                                "\n5: Withdraw Amount"+
                                "\n6: Transaction Details");
            int choice = Convert.ToInt32(Console.ReadLine());
            
            BankRepository bankRepository = new BankRepository();
            long accno;
            decimal amt;



            switch (choice)
            {
                case 1:
                    accno = bankRepository.NewAccount(new SBAccount());
                    if(accno != 0 )
                    {
                        Console.WriteLine("New Account created!!!");
                        Console.WriteLine("Account Number: " + accno);
                    }
                    else
                    {
                        Console.WriteLine("Account not created!");
                        Console.WriteLine("Customer Name should contain only Alphabets!");
                    }
                    break;



                case 2:
                    try
                    {                        
                        Console.WriteLine("Enter Account Number: ");
                        accno = Convert.ToInt64(Console.ReadLine());

                        SqlDataReader dr = bankRepository.GetAccountDetails(accno);
                        if (dr != null)
                        {                                                       
                            for (int i = 0; i < dr.FieldCount; i++) 
                            {
                               Console.WriteLine(dr.GetName(i) + " :"  + dr[i]);
                            }                            

                        }
                        else
                        {
                            Console.WriteLine("Account Number not found!");
                        }

                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Account Number should contain only numbers!");
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                    break;
                
                case 3:
                    {
                        DataTable dt = bankRepository.GetAllAccounts();
                        if(dt != null)
                        {
                            Console.WriteLine("Account Number ---- Customer Name ---- Customer Address ---- Current Balance ---- Date of Creation");
                            Console.WriteLine();
                            foreach (DataRow dr in dt.Rows)
                            {
                                foreach (var item in dr.ItemArray)
                                {
                                    Console.Write(item + "   --------   ");
                                }
                                Console.WriteLine();
                            }
                        }
                        else
                        {
                            Console.WriteLine("No Accounts found!");
                        }
                    }
                    break;


                case 4:
                    {
                        try
                        {
                            Console.WriteLine("Enter Account Number: ");
                            accno = Convert.ToInt64(Console.ReadLine());
                            SqlDataReader dr = bankRepository.checkaccount(accno);
                            
                            if(dr != null)
                            {
                                Console.WriteLine("Enter the amount to be deposited: ");
                                decimal amount = Convert.ToDecimal(Console.ReadLine());
                                if (amount > 0)
                                {
                                    amt = bankRepository.DepositAmount(accno, amount);
                                    Console.WriteLine("Rs. " + amount + " deposited in Account Number " + accno);
                                    Console.WriteLine("New Balance: " + amt);
                                }
                                else
                                {
                                    Console.WriteLine("Amount not deposited, Invalid Amount");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Account Number not found!");
                            }                        
                           
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Amount not deposited, Account Number and amount deposited should contain only numbers!");
                        }




                    }
                    break;

                case 5:
                    {
                        try
                        {
                            Console.WriteLine("Enter Account Number: ");
                            accno = Convert.ToInt64(Console.ReadLine());
                            SqlDataReader dr = bankRepository.checkaccount(accno);

                            if (dr != null)
                            {
                                Console.WriteLine("Enter the amount to be withdrawn: ");
                                decimal amount = Convert.ToDecimal(Console.ReadLine());
                                decimal balance = bankRepository.checkbalance(accno);
                                if(amount > balance)
                                {
                                    Console.WriteLine("Low Balance Amount cannot be withdrawn!");
                                }
                                else if (amount > 0 )
                                {
                                    amt = bankRepository.WithdrawAmount(accno, amount);
                                    Console.WriteLine("Rs." + amount + " withdrawn from Account Number " + accno);
                                    Console.WriteLine("New Balance: " + amt);
                                }
                                else
                                {
                                    Console.WriteLine("Amount not Withdrawn, Invalid Amount");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Account Number not found!");
                            }                            
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Amount not deposited, Account Number and amount deposited should contain only numbers!");
                        }




                    }
                    break;

                case 6:
                    {
                        Console.WriteLine("Enter Account Number");
                        accno = Convert.ToInt64(Console.ReadLine());
                        Console.WriteLine("Transaction ID    Transaction Date        Amount   Transaction Type");
                        //bankRepository.GetAllTransactions(accno);
                        transactions = bankRepository.GetAllTransactions(accno);
                        foreach(SBTransaction transaction in transactions)
                        {
                            Console.WriteLine(transaction.TransactionId+"          "+transaction.TransactionDate+"          "+transaction.Amount+"       "+transaction.TransactionType);
                        }
                        
                        
                    }
                    break;

                default:
                    Console.WriteLine("Enter valid Choice!");
                    break;


            }
        }


    }
}
