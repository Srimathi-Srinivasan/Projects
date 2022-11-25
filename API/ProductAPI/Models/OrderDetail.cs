using System;
using System.Collections.Generic;

namespace ProductAPI.Models
{
    public partial class OrderDetail
    {
        public int OrderId { get; set; }
        public int? ProdId { get; set; }
        public int? CustomerId { get; set; }
        public double? Price { get; set; }
        public DateTime? DeliveryDate { get; set; }
        public string? Address { get; set; }

        public virtual Customer? Customer { get; set; }
        public virtual Product? Prod { get; set; }
    }
}
