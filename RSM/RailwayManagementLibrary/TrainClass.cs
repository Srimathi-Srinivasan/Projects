using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RailwayManagementLibrary
{
    public class TrainClass
    {
        private static Train t = new Train();

        public static void AddTrain(string tname,string from,string to,int totalseats)
        {
            using(var db = new RailwayManagementContext())
            {
                t.TrainName = tname;
                t.From = from;
                t.To = to;
                t.TotalSeats = totalseats;
                db.Trains.Add(t);
                db.SaveChanges();
            }
        }

        public static void DeleteTrain(int tid)
        {
            using(var db = new RailwayManagementContext())
            {
                t = db.Trains.Find(tid);
                db.Trains.Remove(t);
                db.SaveChanges();
            }
        }

        public static void UpdateTrainSeats(int tid,int seats)
        {
            using(var db = new RailwayManagementContext())
            {
                t = db.Trains.Find(tid);
                t.TotalSeats = seats;
                db.Trains.Update(t);
                db.SaveChanges();
            }
        }

        public static void DisplayTrains()
        {
            using(var db = new RailwayManagementContext())
            {
                foreach(var item in db.Trains)
                {
                    Console.WriteLine("Train Id: "+item.TrainId+"\nTrain Name: "+item.TrainName+"\nFrom: "+item.From+"\nTo: "+item.To+"\nTotal Seats: "+item.TotalSeats);
                    Console.WriteLine();
                }
            }
        }
    }
}
