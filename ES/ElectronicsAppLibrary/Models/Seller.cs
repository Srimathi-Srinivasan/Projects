using System;
using System.Collections.Generic;

namespace ElectronicsAppLibrary.Models
{
    public partial class Seller
    {
        public int SellerId { get; set; }
        public string? SellerName { get; set; }
        public int? ProdId { get; set; }
        public string? ContactAddress { get; set; }

        public virtual Product? Prod { get; set; }
    }
}
