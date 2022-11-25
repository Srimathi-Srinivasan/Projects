using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstEg
{
    internal class Doctor
    {
        [Key]
        public int DocID { get; set; }
        public string DocName { get; set; }
        public string Specialization { get; set; }
        public float YrsofExp { get; set; }

        
    }
}
