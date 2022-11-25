using System;
using System.Collections.Generic;

namespace EFCoreEg.Models
{
    public partial class Student
    {
        public int Regno { get; set; }
        public string? Sname { get; set; }
        public int? Age { get; set; }
        public string? City { get; set; }
        public int? Courseid { get; set; }

        public virtual Course? Course { get; set; }
    }
}
