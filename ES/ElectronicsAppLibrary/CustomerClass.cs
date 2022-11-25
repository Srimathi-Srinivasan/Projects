using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ElectronicsAppLibrary.Models;


namespace ElectronicsAppLibrary
{
    public class CustomerClass
    {
        private static Customer c = new Customer();

        public static void AddCustomer(string cname, string password)
        {
            using (var db = new ElectronicsShoppingContext())
            {
                
                c.CustomerName = cname;
                c.Password = password;
                db.Customers.Add(c);
                db.SaveChanges();
            }
        }

        public static void DeleteCustomer(int cid)
        {
            using (var db = new ElectronicsShoppingContext())
            {
                c = db.Customers.Find(cid);
                db.Customers.Remove(c);
                db.SaveChanges();
            }
        }

        public static void UpdateCustomerPassword(int cid, string password)
        {
            using (var db = new ElectronicsShoppingContext())
            {
                c = db.Customers.Find(cid);
                c.Password = password;
                db.Customers.Update(c);
                db.SaveChanges();
            }
        }


        public static void DisplayCustomers()
        {
            using (var db = new ElectronicsShoppingContext())
            {
                foreach (var item in db.Customers)
                {
                    Console.WriteLine("Customer ID: " + item.CustomerId + "\nCustomer Name: " + item.CustomerName + "\nCustomer Password: " + item.Password);
                    Console.WriteLine();
                }
            }
        }
    }
}
