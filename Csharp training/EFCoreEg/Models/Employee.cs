using System;
using System.Collections.Generic;

namespace EFCoreEg.Models
{
    public partial class Employee
    {
        public int Eid { get; set; }
        public string? Ename { get; set; }
        public string? Gender { get; set; }
        public string? Location { get; set; }
        public string? Dept { get; set; }
        public decimal? Salary { get; set; }
        public DateTime? Joiningdate { get; set; }
        public int? Deptid { get; set; }
    }
}
