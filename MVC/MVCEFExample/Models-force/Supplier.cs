using System;
using System.Collections.Generic;

namespace MVCEFExample.Models-force
{
    public partial class Supplier
    {
        public Supplier()
        {
            Products = new HashSet<Product>();
        }

        public int Sid { get; set; }
        public string? Sname { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
