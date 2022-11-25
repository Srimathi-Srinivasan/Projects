using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace RailwayManagementLibrary
{
    public class TrainScheduleReport
    {
        [Key]
        public int Id { get; set; }
        public int TrainId { get; set; }
        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }
        public string From { get; set; }
        public string To { get; set; }

        public Train train { get; set; }
    }
}
