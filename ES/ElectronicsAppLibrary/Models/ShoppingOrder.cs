using System;
using System.Collections.Generic;

namespace ElectronicsAppLibrary.Models
{
    public partial class ShoppingOrder
    {
        public int OrderId { get; set; }
        public int? CustomerId { get; set; }
        public int? ProdId { get; set; }
        public DateTime? Date { get; set; }

        public virtual Customer? Customer { get; set; }
        public virtual Product? Prod { get; set; }
    }
}
