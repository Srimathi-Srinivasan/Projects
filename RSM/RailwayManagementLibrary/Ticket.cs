using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace RailwayManagementLibrary
{
    public class Ticket
    {
        [Key]
        public int TicketId { get; set; }
        public float Price { get; set; }
        
        public int PassengerId { get; set; }
        public int TrainId { get; set; }
        public DateTime BookingDate { get; set; }

        public Passenger passenger { get; set; }
        public Train train { get; set; }
    }
}
