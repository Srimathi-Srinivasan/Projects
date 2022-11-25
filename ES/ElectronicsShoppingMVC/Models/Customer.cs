using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ElectronicsShoppingMVC.Models
{
    public partial class Customer
    {
        public Customer()
        {
            Payments = new HashSet<Payment>();
            ShoppingOrders = new HashSet<ShoppingOrder>();
        }
        [Key]
        public int CustomerId { get; set; }

        [Required(ErrorMessage = "*")]
        public string? CustomerName { get; set; }

        [Required(ErrorMessage = "*")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Please enter valid email address")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "*")]
        public long? MobileNumber { get; set; }

        [Required(ErrorMessage = "*")]
        [DataType(DataType.Password)]
        public string? Password { get; set; }

        [NotMapped]
        [Compare("Password", ErrorMessage = "Passwords donot match")]
        public string ConfirmPassword { get; set; }

        public virtual ICollection<Payment> Payments { get; set; }
        public virtual ICollection<ShoppingOrder> ShoppingOrders { get; set; }
    }
}
