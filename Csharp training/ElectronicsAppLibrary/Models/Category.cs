using System;
using System.Collections.Generic;

namespace ElectronicsAppLibrary.Models
{
    public partial class Category
    {
        public int CategoryId { get; set; }
        public string? CategoryName { get; set; }
        public int? Count { get; set; }
    }
}
