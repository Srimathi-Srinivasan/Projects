using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ElectronicsAppLibrary.Models;

namespace ElectronicsAppLibrary
{
    public class SellerClass
    {
        private static Seller s = new Seller();

        public static void AddSeller(string sname, int prodid, string address)
        {
            using (var db = new ElectronicsShoppingContext())
            {
                
                s.SellerName = sname;
                s.ProdId = prodid;
                s.ContactAddress = address;
                db.Sellers.Add(s);
                db.SaveChanges();
            }
        }

        public static void DeleteSeller(int sid)
        {
            using (var db = new ElectronicsShoppingContext())
            {
                s = db.Sellers.Find(sid);
                db.Sellers.Remove(s);
                db.SaveChanges();
            }
        }

        public static void UpdateSellerAddress(int sid, string address)
        {
            using (var db = new ElectronicsShoppingContext())
            {
                s = db.Sellers.Find(sid);
                s.ContactAddress = address;
                db.Sellers.Update(s);
                db.SaveChanges();
            }
        }

        public static void DisplaySellers()
        {
            using (var db = new ElectronicsShoppingContext())
            {
                foreach (var item in db.Sellers)
                {
                    Console.WriteLine("Seller ID: " + item.SellerId + "\nSeller Name: " + item.SellerName + "\nProduct ID: " + item.ProdId + "\nSeller Address: " + item.ContactAddress);
                    Console.WriteLine();
                }
            }
        }
    }
}
