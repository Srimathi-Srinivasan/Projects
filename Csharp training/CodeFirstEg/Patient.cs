﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstEg
{
    internal class Patient
    {
        [Key]
        public int PatientID { get; set; }
        public string PatientName { get; set; }
        public Doctor doctor { get; set; }

    }
}
