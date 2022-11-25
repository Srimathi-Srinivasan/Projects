using System;
using System.Collections.Generic;

namespace ProductAPI.Models
{
    public partial class Tvdescription
    {
        public int? ProdId { get; set; }
        public string? Brand { get; set; }
        public string? ScreenSize { get; set; }
        public string? DisplayTechnology { get; set; }
        public string? Hardware { get; set; }
        public string? Services { get; set; }
        public string? SpecialFeature { get; set; }
        public string? Model { get; set; }

        public virtual Product? Prod { get; set; }
    }
}
