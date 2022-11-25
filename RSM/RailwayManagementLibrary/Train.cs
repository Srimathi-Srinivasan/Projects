using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace RailwayManagementLibrary
{
    public class Train
    {
        [Key]
        public int TrainId { get; set; }
        public string TrainName { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public int TotalSeats { get; set; }
    }
}
