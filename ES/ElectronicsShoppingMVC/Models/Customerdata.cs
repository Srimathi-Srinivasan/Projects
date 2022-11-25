using System.ComponentModel.DataAnnotations;

namespace ElectronicsShoppingMVC.Models
{
    public class Customerdata
    {
        
        [Key]
        public int CustomerId { get; set; }

        
        public string CustomerName { get; set; }

        
        public string Email { get; set; }

        
        public long MobileNumber { get; set; }

        
        public string Password { get; set; }

        
        

        
    }
}
