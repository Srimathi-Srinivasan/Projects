using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankLibrary;

namespace BankProject
{
    internal class BankClient
    {
        //class AccountNumberInvalidException : ApplicationException
        //{
        //    public AccountNumberInvalidException(string message) : base(message)
        //    {

        //    }
        //}
        public static void Main()
        {
            Console.WriteLine("Welcome!!!");
            Console.WriteLine("Enter your choice: " +
                                "\n1: To create New Account"+
                                "\n2: Get Account Details"+
                                "\n3: Get All Account Details"+
                                "\n4: Deposit Amount");
            int choice = Convert.ToInt32(Console.ReadLine());
            //IBankRepository repository = new BankRepository();
            BankRepository bankRepository = new BankRepository();
            bankRepository.ExistingAccounts();
            

            
            switch(choice)
            {
                case 1:
                    bankRepository.NewAccount(new SBAccount());
                    break;
                case 2:
                    try
                    {
                        //bankRepository.NewAccount(new SBAccount());
                        Console.WriteLine("Enter Account Number: ");
                        long accno = Convert.ToInt64(Console.ReadLine());                      
                        
                        SBAccount a = bankRepository.GetAccountDetails(accno);
                        if(a != null)
                        {
                            Console.WriteLine("Account number: " + a.AccountNumber +
                                            "\nCustomer Name: " + a.CustomerName +
                                            "\nCustomer Address: " + a.CustomerAddress +
                                            "\nCurrent Balance: " + a.CurrentBalance);
                        }                        

                    }
                    catch(FormatException)
                    {
                        Console.WriteLine("Account Number should contain only numbers!");
                    }
                    catch(Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }               
                               

                    break;

                case 3:
                    {
                        List<SBAccount> accounts = bankRepository.GetAllAccounts();
                        foreach(SBAccount account in accounts)
                        {
                            Console.WriteLine("Account Number: "+ account.AccountNumber+"---"+"Customer Name: "+ account.CustomerName + "---"+"Customer Address: "+account.CustomerAddress+"---"+"Current Balance: "+account.CurrentBalance);
                        }
                    }
                    break;

                case 4:
                    {
                        try
                        {
                            Console.WriteLine("Enter Account Number: ");
                            int accno = Convert.ToInt32(Console.ReadLine());

                            
                            Console.WriteLine("Enter the amount to be deposited: ");
                            decimal amount = Convert.ToDecimal(Console.ReadLine());
                            if(amount > 0)
                            {
                                bankRepository.DepositAmount(accno, amount);
                            }
                            else
                            {
                                Console.WriteLine("Invalid Amount");
                            }
                            
                            #region
                            //List<SBAccount> accounts = bankRepository.GetAllAccounts();
                            //foreach (SBAccount account in accounts)
                            //{
                            //    Console.WriteLine("Account Number: " + account.AccountNumber + "---" + "Customer Name: " + account.CustomerName + "---" + "Customer Address: " + account.CustomerAddress + "---" + "Current Balance: " + account.CurrentBalance);
                            //}
                            #endregion
                        }
                        catch(FormatException)
                        {
                            Console.WriteLine("Account Number and amount deposited should contain only numbers!");
                        }
                        
                        
                        
                        
                    }
                    break;
                

            }
        }
       

    }
}
