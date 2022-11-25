using System;
using System.Collections.Generic;

namespace MVCEFExample.Models
{
    public partial class Product
    {
        public int Pid { get; set; }
        public string? Pname { get; set; }
        public decimal? Price { get; set; }
        public int? Suppid { get; set; }

        public virtual Supplier? Supp { get; set; }
    }
}
