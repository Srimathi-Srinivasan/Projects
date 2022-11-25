using System;
using EFCoreEg.Models;

namespace EFCoreEg
{
    class Program
    {
        public static eurofinsContext db = new eurofinsContext();
        public static Employee e = new Employee();
        public static void Main()
        {
            //AddEmp();
            //DeleteEmp();
            UpdateDetails();
            DisplayDetails();
        }

        private static void AddEmp()
        {
            Console.WriteLine("Enter EID,Ename,Dept,salary,joining date,dept id: ");
            e.Eid = Convert.ToInt32(Console.ReadLine());
            e.Ename = Console.ReadLine();
            e.Dept = Console.ReadLine();
            e.Salary = Convert.ToInt32(Console.ReadLine());
            e.Joiningdate = DateTime.Parse(Console.ReadLine());
            e.Deptid = Convert.ToInt32(Console.ReadLine());
            db.Employees.Add(e);//insert into Dbset of context
            db.SaveChanges();//insert into db
        }

        private static void DeleteEmp()
        {
            Console.WriteLine("Enter Eid: ");
            int id = Convert.ToInt32(Console.ReadLine());

            //e = db.Employees.Where(x=>x.Eid == id).Select(x=>x).SingleorDefault();
            e = db.Employees.Find(id);
            db.Employees.Remove(e);
            db.SaveChanges();
            Console.WriteLine(e.Ename+"details deleted");
        }

        private static void UpdateDetails()
        {
            Console.WriteLine("Enter Eid: ");
            int Eid = Convert.ToInt32(Console.ReadLine());
            e = db.Employees.Find(Eid);
            Console.WriteLine("Enter Location: ");
            e.Location = Console.ReadLine();
            db.Employees.Update(e);
            db.SaveChanges();
        }

        private static void DisplayDetails()
        {
            foreach (var item in db.Employees)
            {
                Console.WriteLine("EID: " + item.Eid + " Employee Name: " + item.Ename + " Dept: " + item.Dept + " Gender: " + item.Gender + " Joining Date: " + item.Joiningdate + " Location: " + item.Location);
            }
        }
    }
}
