using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SBLibrary;
using System.Data.SqlClient;

namespace SBProject
{
    internal class SBClient
    {
        public static List<SBAccount> accounts = new List<SBAccount>();
        public static List<SBTransaction> transactions = new List<SBTransaction>();

        public static void Main()
        {
            Console.WriteLine("                  Welcome to State Bank!!!                    ");
            Console.WriteLine();
            int flag = 0;
            do
            {
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("Enter your choice: " +
                                    "\n"+
                                    "\n1: To create New Account" +
                                    "\n2: Get Account Details" +
                                    "\n3: Get All Account Details" +
                                    "\n4: Deposit Amount" +
                                    "\n5: Withdraw Amount" +
                                    "\n6: Transaction Details"+
                                    "\n7: Exit"+"\n");
                int choice = Convert.ToInt32(Console.ReadLine());

                BankRepository bankRepository = new BankRepository();
                int accno;
                decimal amt;
                


                switch (choice)
                {
                    case 1:
                        bankRepository.NewAccount(new SBAccount());
                        flag = 1;
                        break;

                    case 2:
                        {
                            int i = 0;
                            flag = 1;
                            string option;
                            do
                            {
                                try
                                {
                                    Console.WriteLine("Enter Account Number: ");
                                    accno = Convert.ToInt32(Console.ReadLine());
                                    SBAccount acc = new SBAccount();
                                    acc = bankRepository.GetAccountDetails(accno);
                                    if (acc != null)
                                    {
                                        Console.WriteLine("Account Number: " + acc.AccountNumber);
                                        Console.WriteLine("Customer Name: " + acc.CustomerName);
                                        Console.WriteLine("Customer Address: " + acc.CustomerAddress);
                                        Console.WriteLine("Current Balance: " + acc.CurrentBalance);
                                        Console.WriteLine("Date of Creation: " + acc.DateofCreation);
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Account Number not found!");
                                        if(i == 2)
                                        {
                                            break;
                                        }
                                        Console.WriteLine("Do you want to try again? (Y/N)");
                                        option = Console.ReadLine();
                                        if(option is "N" || option is "n")
                                        {
                                            break;
                                        }
                                        else if (option is "Y" || option is "y")
                                        {
                                            i++;
                                        }
                                        else
                                        {
                                            Console.WriteLine("Invalid option!");
                                            i = 3;
                                        }
                                        
                                    }
                                }
                                catch (FormatException)
                                {
                                    Console.WriteLine("Account Number should contain only numbers!");
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
                                    else if (option is "Y" || option is "y")
                                    {
                                        i++;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Invalid option!");
                                        i = 3;
                                    }
                                    
                                }

                            } while (i < 3);
                            if (i == 2 || i == 3)
                            {
                                Console.WriteLine("Unable to fetch account details. Try after sometime!");
                            }
                            break;
                        }

                    case 3:
                        accounts = bankRepository.GetAllAccounts();

                        foreach (SBAccount account in accounts)
                        {
                            Console.WriteLine(account.AccountNumber + " " + account.CustomerName + " " + account.CustomerAddress + " " + account.CurrentBalance + " " + account.DateofCreation);
                        }
                        flag = 1;
                        break;
                    case 4:
                        {
                            flag = 1;
                            int i = 0;
                            string option;
                            do
                            {
                                try
                                {
                                    Console.WriteLine("Enter Account Number: ");
                                    accno = Convert.ToInt32(Console.ReadLine());
                                    SqlDataReader dr = bankRepository.checkaccount(accno);

                                    if (dr != null)
                                    {
                                        Console.WriteLine("Enter the amount to be deposited: ");
                                        decimal amount = Convert.ToDecimal(Console.ReadLine());
                                        if (amount > 0)
                                        {
                                            bankRepository.DepositAmount(accno, amount);
                                            //Console.WriteLine("Rs. " + amount + " deposited in Account Number " + accno);
                                            //Console.WriteLine("New Balance: " + amt);
                                            break;
                                        }
                                        else
                                        {
                                            Console.WriteLine("Amount not deposited, Invalid Amount");
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
                                            else if (option is "Y" || option is "y")
                                            {
                                                i++;
                                            }
                                            else
                                            {
                                                Console.WriteLine("Invalid option!");
                                                i = 3;
                                            }
                                            
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("Account Number not found!");
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
                                        else if (option is "Y" || option is "y")
                                        {
                                            i++;
                                        }
                                        else
                                        {
                                            Console.WriteLine("Invalid option!");
                                            i = 3;
                                        }
                                        
                                    }

                                }
                                catch (FormatException)
                                {
                                    Console.WriteLine("Amount not deposited, Account Number and amount deposited should contain only numbers!");
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
                                    else if (option is "Y" || option is "y")
                                    {
                                        i++;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Invalid option!");
                                        i = 3;
                                    }
                                    
                                }
                                


                            } while (i < 3);
                            if(i==2 || i==3)
                            {
                                Console.WriteLine("Amount not Deposited. Try after sometime!");
                            }
                            break;
                        }

                    case 5:

                        {
                            flag = 1;
                            int i = 0;
                            string option;
                            do
                            {
                                try
                                {
                                    Console.WriteLine("Enter Account Number: ");
                                    accno = Convert.ToInt32(Console.ReadLine());
                                    SqlDataReader dr = bankRepository.checkaccount(accno);

                                    if (dr != null)
                                    {
                                        Console.WriteLine("Enter the amount to be withdrawn: ");
                                        decimal amount = Convert.ToDecimal(Console.ReadLine());
                                        decimal balance = bankRepository.checkbalance(accno);
                                        if (amount > balance)
                                        {
                                            Console.WriteLine("Low Balance Amount cannot be withdrawn!");
                                            break;
                                        }
                                        else if (amount > 0)
                                        {
                                            bankRepository.WithdrawAmount(accno, amount);
                                            //Console.WriteLine("Rs." + amount + " withdrawn from Account Number " + accno);
                                            //Console.WriteLine("New Balance: " + amt);
                                            break;
                                        }
                                        else
                                        {
                                            Console.WriteLine("Amount not Withdrawn, Invalid Amount");
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
                                            else if (option is "Y" || option is "y")
                                            {
                                                i++;
                                            }
                                            else
                                            {
                                                Console.WriteLine("Invalid option!");
                                                i = 3;
                                            }
                                            
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("Account Number not found!");
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
                                        else if (option is "Y" || option is "y")
                                        {
                                            i++;
                                        }
                                        else
                                        {
                                            Console.WriteLine("Invalid option!");
                                            i = 3;
                                        }
                                        
                                    }
                                }
                                catch (FormatException)
                                {
                                    Console.WriteLine("Amount not Withdrawn. Account Number and amount deposited should contain only numbers!");
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
                                    else if (option is "Y" || option is "y")
                                    {
                                        i++;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Invalid option!");
                                        i = 3;
                                    }
                                    
                                }

                            } while (i < 3);
                            if (i == 2 || i == 3)
                            {
                                Console.WriteLine("Amount not withdrawn. Try after sometime");
                            }
                            break;
                        }

                    case 6:
                        {
                            flag = 1;
                            int i = 0;
                            string option;
                            do
                            {

                                try
                                {
                                    Console.WriteLine("Enter Account Number");
                                    accno = Convert.ToInt32(Console.ReadLine());
                                    SqlDataReader dr = bankRepository.checkaccount(accno);

                                    if (dr != null)
                                    {
                                        transactions = bankRepository.GetAllTransactions(accno);

                                        if (transactions.Count != 0)
                                        {
                                            Console.WriteLine("Transaction ID    Transaction Date        Amount   Transaction Type");

                                            foreach (SBTransaction transaction in transactions)
                                            {
                                                Console.WriteLine(transaction.TransactionId + "          " + transaction.TransactionDate + "          " + transaction.Amount + "       " + transaction.TransactionType);
                                            }
                                            break;
                                        }
                                        else
                                        {
                                            Console.WriteLine("No History of Transactions");
                                            break;
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("Account Number not found!");
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
                                        else if (option is "Y" || option is "y")
                                        {
                                            i++;
                                        }
                                        else
                                        {
                                            Console.WriteLine("Invalid option!");
                                            i = 3;
                                        }
                                        

                                    }
                                }
                                catch (FormatException)
                                {
                                    Console.WriteLine("Account Number should contain only numbers!");
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
                                    else if (option is "Y" || option is "y")
                                    {
                                        i++;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Invalid option!");
                                        i = 3;
                                    }
                                    
                                }
                                

                            }while (i < 3);
                            if(i==2 || i == 3)
                            {
                                Console.WriteLine("Unable to fetch transaction details. Try after sometime.");
                            }
                            
                        break;
                        }

                    case 7:
                        Console.WriteLine("Thank You!");
                        flag = 0;
                        break;

                    default:
                        Console.WriteLine("Enter valid Choice!");
                        flag = 1;
                        break;
                }
            }while(flag == 1);
        }
    }
}
