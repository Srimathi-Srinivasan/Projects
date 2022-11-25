using System;
using System.Collections.Generic;

namespace ElectronicsShoppingMVC.Models
{
    public partial class Television
    {
        public int Id { get; set; }
        public int? CategoryId { get; set; }
        public string? Brand { get; set; }
        public string? Model { get; set; }
        public double? Price { get; set; }
        public int? Count { get; set; }
        public string? Url { get; set; }

        public virtual TelevisionCategory? Category { get; set; }
    }
}
