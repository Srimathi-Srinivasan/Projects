using System;
using System.Collections.Generic;

namespace SmartShoppingMVC.Models
{
    public partial class Customer
    {
        public int CustomerId { get; set; }
        public string? CustomerName { get; set; }
        public string? Email { get; set; }
        public long? MobileNumber { get; set; }
        public string? Password { get; set; }
    }
}
