using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RailwayManagementLibrary
{
    public class TicketClass
    {
        private static Ticket t = new Ticket();

        public static void AddTicketDetails(float price, int pid, int tid, DateTime bookingdate)
        {
            using (var db = new RailwayManagementContext())
            {
                t.Price = price;
                t.PassengerId = pid;
                t.TrainId = tid;
                t.BookingDate = bookingdate.Date;
                db.Tickets.Add(t);
                db.SaveChanges();
            }
        }

        public static void DeleteTicketDetails(int tid)
        {
            using(var db = new RailwayManagementContext())
            {
                t = db.Tickets.Find(tid);
                db.Tickets.Remove(t);
                db.SaveChanges();
            }
        }

        public static void DisplayTicketDetails()
        {
            using(var db = new RailwayManagementContext())
            {
                foreach(var item in db.Tickets)
                {
                    Console.WriteLine("Ticket Id: "+item.TicketId+"\nPrice: "+item.Price+"\nPassenger Id: "+item.PassengerId+"\nTrain Id: "+item.TrainId+"\nBooking Date: "+t.BookingDate);
                    Console.WriteLine();
                }
            }
        }
    }
}
