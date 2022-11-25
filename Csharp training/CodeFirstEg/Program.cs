using System;
using CodeFirstEg.Migrations;
using Microsoft.EntityFrameworkCore;

namespace CodeFirstEg
{
    internal class Program
    {
        //public static HospitalContext db = new HospitalContext();
        public static Doctor d = new Doctor();
        public static Patient p = new Patient();
        
        public static void Main()
        {
            //AddDoctor();
            //DeleteDoctor();
            //UpdateDoctor();
            //DisplayDoctors();

            //AddPatient();
            //DeletePatient();
            UpdatePatient();
            Displaypatients();
        }

        private static void AddDoctor()
        {
            using (var db = new HospitalContext())
            {
                Console.WriteLine("Enter Doctor Name,Specialization,Years of Experience: ");
                d.DocName = Console.ReadLine();
                d.Specialization = Console.ReadLine();
                d.YrsofExp = Convert.ToInt32(Console.ReadLine());
                db.Doctors.Add(d);
                db.SaveChanges();
            }
        }

        private static void DeleteDoctor()
        {
            using (var db = new HospitalContext())
            {
                Console.WriteLine("Enter Doctor ID: ");
                int id = Convert.ToInt32(Console.ReadLine());
                d = db.Doctors.Find(id);
                db.Doctors.Remove(d);
                db.SaveChanges();
                Console.WriteLine(d.DocName + " details deleted");
            }
        }

        private static void UpdateDoctor()
        {
            using (var db = new HospitalContext())
            {
                Console.WriteLine("Enter Doctor ID: ");
                int id = Convert.ToInt32(Console.ReadLine());
                d = db.Doctors.Find(id);
                Console.WriteLine("Enter Years of Experience: ");
                d.YrsofExp = Convert.ToInt32(Console.ReadLine());
                db.Doctors.Update(d);
                db.SaveChanges();
            }
        }

        private static void DisplayDoctors()
        {
            using (var db = new HospitalContext())
            {
                foreach (var item in db.Doctors)
                {
                    Console.WriteLine("Doctor ID: " + item.DocID + "\nDoctor Name: " + item.DocName + "\nSpecialization: " + item.Specialization + "\nYears of Experience: " + item.YrsofExp);
                    Console.WriteLine();
                }
            }
        }

        private static void AddPatient()
        {
            using (var db = new HospitalContext())
            {
                Console.WriteLine("Enter Patient Name, Doctor ID: ");
                p.PatientName = Console.ReadLine();
                int did = Convert.ToInt32(Console.ReadLine());
                d = db.Doctors.Find(did);
                p.doctor = d;
                db.Patients.Add(p);
                db.SaveChanges();
            }
        }

        private static void DeletePatient()
        {
            using (var db = new HospitalContext())
            {
                Console.WriteLine("Enter Patient ID: ");
                int pid = Convert.ToInt32(Console.ReadLine());
                p = db.Patients.Find(pid);
                db.Patients.Remove(p);
                db.SaveChanges();
                Console.WriteLine(p.PatientName + " details deleted");
            }
        }

        private static void UpdatePatient()
        {
            using (var db = new HospitalContext())
            {
                Console.WriteLine("Enter Patient ID: ");
                int pid = Convert.ToInt32(Console.ReadLine());
                p = db.Patients.Find(pid);
                db.Patients.Include(x => x.doctor);
                Console.WriteLine("Enter Doctor ID: ");
                                
                db.Patients.Update(p);
                db.SaveChanges();
            }
        }

        private static void Displaypatients()
        {
            using (var db = new HospitalContext())
            {
                var result = db.Patients.Include(x => x.doctor);
                foreach (var item in result)
                {
                    
                    Console.WriteLine("Patient ID: " + item.PatientID + "\nPatient Name: " + item.PatientName + "\nDoctor ID: " + item.doctor.DocID + "\nDoctor Name: " + item.doctor.DocName);
                }
            }
            
        }


    }
}
