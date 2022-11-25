using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ElectronicsAppLibrary.Models;

namespace ElectronicsAppLibrary
{
    public class ProductClass
    {
        private static Product p = new Product();

        public static void AddProduct(string pname, float price, int count)
        {
            using (var db = new ElectronicsShoppingContext())
            {
                
                p.ProdName = pname;
                p.Price = price;
                p.Count = count;
                db.Products.Add(p);
                db.SaveChanges();
            }
        }

        public static void DeleteProduct(int pid)
        {
            using (var db = new ElectronicsShoppingContext())
            {
                p = db.Products.Find(pid);
                db.Products.Remove(p);
                db.SaveChanges();
            }
        }

        public static void UpdateProductPrice(int pid, float price)
        {
            using (var db = new ElectronicsShoppingContext())
            {
                p = db.Products.Find(pid);
                p.Price = price;
                db.Products.Update(p);
                db.SaveChanges();
            }
        }

        public static void UpdateProductCount(int pid, int count)
        {
            using (var db = new ElectronicsShoppingContext())
            {
                p = db.Products.Find(pid);
                p.Count = count;
                db.Products.Update(p);
                db.SaveChanges();
            }
        }

        public static void DisplayProducts()
        {
            using (var db = new ElectronicsShoppingContext())
            {
                foreach (var item in db.Products)
                {
                    Console.WriteLine("Product ID: " + item.ProdId + "\nProduct Name: " + item.ProdName + "\nPrice: " + item.Price + "\nCount: " + item.Count);
                    Console.WriteLine();
                }
            }
        }
    }
}
