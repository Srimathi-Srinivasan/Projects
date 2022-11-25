using System;
using System.Collections.Generic;

namespace ElectronicsAppLibrary.Models
{
    public partial class Customer
    {
        public Customer()
        {
            Payments = new HashSet<Payment>();
            ShoppingOrders = new HashSet<ShoppingOrder>();
        }

        public int CustomerId { get; set; }
        public string? CustomerName { get; set; }
        public string? CustomerAddress { get; set; }

        public virtual ICollection<Payment> Payments { get; set; }
        public virtual ICollection<ShoppingOrder> ShoppingOrders { get; set; }
    }
}
