using System;
using System.Collections.Generic;

namespace ProductAPI.Models
{
    public partial class AudioDescription
    {
        public int? ProdId { get; set; }
        public string? Brand { get; set; }
        public string? Model { get; set; }
        public string? Color { get; set; }
        public string? ConnectorType { get; set; }
        public string? SpecialFeature { get; set; }

        public virtual Product? Prod { get; set; }
    }
}
