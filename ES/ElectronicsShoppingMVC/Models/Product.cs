using System;
using System.Collections.Generic;

namespace ElectronicsShoppingMVC.Models
{
    public partial class Product
    {
        public Product()
        {
            Payments = new HashSet<Payment>();
            Sellers = new HashSet<Seller>();
            ShoppingOrders = new HashSet<ShoppingOrder>();
        }

        public int ProdId { get; set; }
        public string? ProdName { get; set; }
        public double? Price { get; set; }
        public int? Count { get; set; }

        public virtual ICollection<Payment> Payments { get; set; }
        public virtual ICollection<Seller> Sellers { get; set; }
        public virtual ICollection<ShoppingOrder> ShoppingOrders { get; set; }
    }
}
