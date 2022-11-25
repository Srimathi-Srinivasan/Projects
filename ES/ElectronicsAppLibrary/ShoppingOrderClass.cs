using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ElectronicsAppLibrary.Models;

namespace ElectronicsAppLibrary
{
    public class ShoppingOrderClass
    {
        private static ShoppingOrder s = new ShoppingOrder();

        public static void AddOrder(int custid,int prodid,DateTime date)
        {
            using(var db = new ElectronicsShoppingContext())
            {
                s.CustomerId = custid;
                s.ProdId = prodid;
                s.Date = date.Date;
                db.ShoppingOrders.Add(s);
                db.SaveChanges();
            }
        }

        public static void DeleteOrder(int orderid)
        {
            using(var db = new ElectronicsShoppingContext())
            {
                s = db.ShoppingOrders.Find(orderid);
                db.ShoppingOrders.Remove(s);
                db.SaveChanges();
            }
        }

        public static void DisplayOrderDetails(int custid)
        {
            using(var db = new ElectronicsShoppingContext())
            {
                foreach(var item in db.ShoppingOrders)
                {
                    if(item.CustomerId == custid)
                    {
                        Console.WriteLine("Customer ID: "+item.CustomerId+"\nOrder ID: "+item.OrderId+"\nProduct ID: "+item.ProdId+"\nOrder Date: "+item.Date);
                        Console.WriteLine();
                    }
                }
            }
        }
     
    }
}
