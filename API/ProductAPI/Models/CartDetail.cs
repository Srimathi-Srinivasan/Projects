using System;
using System.Collections.Generic;

namespace ProductAPI.Models
{
    public partial class CartDetail
    {
        public int CartId { get; set; }
        public int? ProdId { get; set; }
        public int? CustId { get; set; }

        public virtual Customer? Cust { get; set; }
        public virtual Product? Prod { get; set; }
    }
}
