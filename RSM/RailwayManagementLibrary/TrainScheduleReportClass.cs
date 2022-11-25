using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RailwayManagementLibrary
{
    public class TrainScheduleReportClass
    {
        private static TrainScheduleReport t = new TrainScheduleReport();

        public static void AddSchedule(int tid,DateTime departuretime,DateTime arrivaltime,string from,string to)
        {
            using(var db = new RailwayManagementContext())
            {
                t.TrainId = tid;
                t.DepartureTime = departuretime;
                t.ArrivalTime = arrivaltime;
                t.From = from;
                t.To = to;
                db.Reports.Add(t);
                db.SaveChanges();
            }
        }

        public static void DeleteSchedule(int id)
        {
            using(var db = new RailwayManagementContext())
            {
                t = db.Reports.Find(id);
                t.Id = id;
                db.Reports.Remove(t);
                db.SaveChanges();
            }
        }

        public static void UpdateDepartureTime(int id,DateTime departuretime)
        {
            using(var db = new RailwayManagementContext())
            {
                t = db.Reports.Find(id);
                t.DepartureTime = departuretime;
                db.Reports.Update(t);
                db.SaveChanges();
            }
        }

        public static void UpdateArrivalTime(int id, DateTime arrivaltime)
        {
            using (var db = new RailwayManagementContext())
            {
                t = db.Reports.Find(id);
                t.DepartureTime = arrivaltime;
                db.Reports.Update(t);
                db.SaveChanges();
            }
        }

        public static void DisplaySchedule()
        {
            using(var db = new RailwayManagementContext())
            {
                foreach(var item in db.Reports)
                {
                    Console.WriteLine("Id: "+item.Id+"\nTrain Id: "+item.TrainId+"\nDeparture Time: "+item.DepartureTime+"\nArrival Time: "+item.ArrivalTime+"\nFrom: "+item.From+"\nTo: "+item.To);
                    Console.WriteLine();
                }
            }
        }
    }
}
