using System;
using System.Collections.Generic;

namespace SmartShoppingMVC.Models
{
    public partial class Product
    {
        public int ProdId { get; set; }
        public int? CategoryId { get; set; }
        public string? Brand { get; set; }
        public string? Model { get; set; }
        public double? Price { get; set; }
        public int? Count { get; set; }
        public string? Img1 { get; set; }
        public string? Img2 { get; set; }
        public string? Img3 { get; set; }

        public virtual Category? Category { get; set; }
    }
}
