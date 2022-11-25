using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ElectronicsAppLibrary.Models;

namespace ElectronicsAppLibrary
{
    public class PaymentClass
    {
        private static Payment p = new Payment();

        public static void AddPaymentDetails(int custid,int prodid,DateTime date)
        {
            using(var db = new ElectronicsShoppingContext())
            {
                p.CustomerId = custid;
                p.ProdId = prodid;
                p.Date = date.Date;
                db.Payments.Add(p);
                db.SaveChanges();
            }            
        }

        
    }
}
