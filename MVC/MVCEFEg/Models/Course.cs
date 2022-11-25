using System;
using System.Collections.Generic;

namespace MVCEFEg.Models
{
    public partial class Course
    {
        public Course()
        {
            Students = new HashSet<Student>();
        }

        public int Cid { get; set; }
        public string? Cname { get; set; }

        public virtual ICollection<Student> Students { get; set; }
    }
}
