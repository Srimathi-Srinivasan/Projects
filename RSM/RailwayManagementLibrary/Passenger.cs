using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace RailwayManagementLibrary
{
    public class Passenger
    {
        [Key]
        public int PassengerId { get; set; }
        public string PassengerName { get; set; }
        public int Age { get; set; }
        public string Address { get; set; }
    }
}
