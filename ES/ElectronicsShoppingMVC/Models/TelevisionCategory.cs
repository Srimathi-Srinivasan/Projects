using System;
using System.Collections.Generic;

namespace ElectronicsShoppingMVC.Models
{
    public partial class TelevisionCategory
    {
        public TelevisionCategory()
        {
            Televisions = new HashSet<Television>();
        }

        public int CategoryId { get; set; }
        public string? CategoryName { get; set; }

        public virtual ICollection<Television> Televisions { get; set; }
    }
}
