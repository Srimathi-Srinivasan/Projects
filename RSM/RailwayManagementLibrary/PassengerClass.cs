using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RailwayManagementLibrary
{
    public class PassengerClass
    {
        private static Passenger p = new Passenger();

        private static void AddPassenger(string pname,int age,string address)
        {
            using(var db = new RailwayManagementContext())
            {
                p.PassengerName = pname;
                p.Age = age;
                p.Address = address;
                db.Passengers.Add(p);
                db.SaveChanges();
            }
        }

        private static void DeletePassenger(int pid)
        {
            using(var db = new RailwayManagementContext())
            {
                p = db.Passengers.Find(pid);
                db.Passengers.Remove(p);
                db.SaveChanges();
            }
        }

        private static void UpdatePassengerAddress(int pid,string address)
        {
            using(var db = new RailwayManagementContext())
            {
                p = db.Passengers.Find(pid);
                p.Address = address;
                db.Passengers.Update(p);
                db.SaveChanges();
            }
        }

        private static void DisplayPassengers()
        {
            using(var db = new RailwayManagementContext())
            {
                foreach(var item in db.Passengers)
                {
                    Console.WriteLine("Passenger ID: "+item.PassengerId+"\nPassenger Name: "+item.PassengerName+"\nAge: "+item.Age+"\nAddress: "+item.Address);
                    Console.WriteLine();
                }
            }
        }
    }
}
