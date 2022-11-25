//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using ClinicManagementSystemLibrary;
//using System.Data.SqlClient;

//namespace ClinicManagementSystemClient
//{
//    internal class CMSClient
//    {
//        public static SqlDataReader dr;
//        public static CMSClient cms;
//        public static ICMSRepo obj = new CMSRepo();
//        public static void main()
//        {
//            cms = new CMSClient();
//            int result;
            
//            result = cms.Loginpage();
//            if(result == 1)
//            {
//                Console.WriteLine("Successfully Logged in");
//                Console.WriteLine("Enter choice");
//                Console.WriteLine("1: View Doctors\n" +
//                                    "2: Add Patient\n" +
//                                    "3: Schedule Appointment\n" +
//                                    "4: Cancel Appointment\n" +
//                                    "5: Logout");
//                int choice = Convert.ToInt32(Console.ReadLine());
//                switch (choice)
//                {
//                    case 1:
//                        dr = obj.ViewDoctors();
//                        while (dr.Read())
//                        {
//                            for (int i = 0; i < dr.FieldCount; i++)
//                            {
//                                Console.Write(dr[i] + " ");
//                            }
//                            Console.WriteLine();
//                        }
//                        break;

//                    case 2:
//                        Console.WriteLine("Enter First Name");
//                        string FirstName = Console.ReadLine();
//                        Console.WriteLine("Enter Last Name");
//                        string LastName = Console.ReadLine();
//                        Console.WriteLine("Enter Sex");
//                        string Sex = Console.ReadLine();
//                        Console.WriteLine("Enter Age");
//                        int Age = Convert.ToInt32(Console.ReadLine());
//                        Console.WriteLine("Enter Date of Birth");
//                        DateTime DOB = DateTime.Parse(Console.ReadLine());
//                        obj.AddPatient(FirstName, LastName, Sex, Age, DOB);
//                        Console.WriteLine();
//                        Console.WriteLine("Patient details added successfully.");
//                        break;

//                    case 3:
//                        Console.WriteLine("Enter Patient ID");
//                        int PatientID = Convert.ToInt32(Console.ReadLine());
//                        Console.WriteLine("Enter Specialization Required");
//                        string Specialization = Console.ReadLine();
//                        dr = obj.getdoctors(Specialization);
//                        Console.WriteLine("Doctors Available:\n");
//                        while (dr.Read())
//                        {
//                            for (int i = 0; i < dr.FieldCount; i++)
//                            {
//                                Console.Write(dr[i] + " ");
//                            }
//                            Console.WriteLine();
//                        }
//                        Console.WriteLine("Select Doctor by entering Doctor ID");
//                        int DoctorID = Convert.ToInt32(Console.ReadLine());
//                        Console.WriteLine("Enter Appointment Date");
//                        DateTime AppointmentDate = DateTime.Parse(Console.ReadLine());
//                        Console.WriteLine("Slot details:\n" + "slot 1 - 05:00 PM to 06:00 PM\n" +
//                            "slot 2 - 06:00 PM to 07:00 PM\n" +
//                            "slot 3 - 07:00 PM to 08:00 PM\n" +
//                            "slot 4 - 08:00 PM to 09:00 PM\n" +
//                            "slot 5 - 09:00 PM to 10:00 PM\n");

//                        int[] Remainingslots = obj.SlotDetails(DoctorID, AppointmentDate);
//                        for (int i = 0; i < Remainingslots.Length; i++)
//                        {
//                            if (Remainingslots[i] != 0)
//                                Console.WriteLine(Remainingslots[i]);
//                        }
//                        Console.WriteLine("Enter Slot");
//                        int slot = Convert.ToInt32(Console.ReadLine());
//                        string AppointmentTime = null;
//                        switch (slot)
//                        {
//                            case 1:
//                                AppointmentTime = "05:00";
//                                break;
//                            case 2:
//                                AppointmentTime = "06:00";
//                                break;
//                            case 3:
//                                AppointmentTime = "07:00";
//                                break;
//                            case 4:
//                                AppointmentTime = "08:00";
//                                break;
//                            case 5:
//                                AppointmentTime = "09:00";
//                                break;

//                        }
//                        obj.ScheduleAppointment(PatientID, Specialization, DoctorID, AppointmentDate, slot, AppointmentTime);
//                        break;
//                    case 5:
//                        Console.WriteLine("Logged out Successfully!");
//                        break;
//                    default:
//                        Console.WriteLine("Please choose valid choice from the Menu");
//                        break;
//                }
//            }
//            else
//            {
//                Console.WriteLine("Invalid username or password!");
//                Console.WriteLine("Login not successful");
//                cms.LoginPage();
//            }
//        }
//    }
            
        
//        public void LoginPage()
//        {
            

//            Console.WriteLine("...........................Welcome to AB Clinic........................");

//            Console.WriteLine("Enter user name: ");
//            string username = Console.ReadLine();
//            Console.WriteLine("Enter Password: ");
//            string password = Console.ReadLine();
//            int flag;
//            flag = obj.Login(username, password);
//            if (flag == 1)
//            {
//                Console.WriteLine("Successfully Logged in");
//                Console.WriteLine("Enter choice");
//                Console.WriteLine("1: View Doctors\n" +
//                                    "2: Add Patient\n"+
//                                    "3: Schedule Appointment\n"+
//                                    "4: Cancel Appointment\n"+
//                                    "5: Logout");
//                int choice = Convert.ToInt32(Console.ReadLine());
//                switch(choice)
//                {
//                    case 1:
//                        dr = obj.ViewDoctors();
//                        while (dr.Read()) 
//                        {
//                            for (int i = 0; i < dr.FieldCount; i++) 
//                            {
//                                Console.Write(dr[i] + " ");
//                            }
//                            Console.WriteLine();
//                        }
//                        break;

//                    case 2:
//                        Console.WriteLine("Enter First Name");
//                        string FirstName = Console.ReadLine();
//                        Console.WriteLine("Enter Last Name");
//                        string LastName = Console.ReadLine();
//                        Console.WriteLine("Enter Sex");
//                        string Sex = Console.ReadLine();
//                        Console.WriteLine("Enter Age");
//                        int Age = Convert.ToInt32(Console.ReadLine());
//                        Console.WriteLine("Enter Date of Birth");
//                        DateTime DOB = DateTime.Parse(Console.ReadLine());
//                        obj.AddPatient(FirstName, LastName, Sex, Age, DOB);
//                        Console.WriteLine();
//                        Console.WriteLine("Patient details added successfully.");
//                        break;

//                    case 3:
//                        Console.WriteLine("Enter Patient ID");
//                        int PatientID = Convert.ToInt32(Console.ReadLine());
//                        Console.WriteLine("Enter Specialization Required");
//                        string Specialization = Console.ReadLine();
//                        dr = obj.getdoctors(Specialization);
//                        Console.WriteLine("Doctors Available:\n");
//                        while (dr.Read())
//                        {
//                            for(int i=0;i<dr.FieldCount;i++)
//                            {
//                                Console.Write(dr[i]+" ");
//                            }
//                            Console.WriteLine();
//                        }
//                        Console.WriteLine("Select Doctor by entering Doctor ID");
//                        int DoctorID = Convert.ToInt32(Console.ReadLine());
//                        Console.WriteLine("Enter Appointment Date");
//                        DateTime AppointmentDate = DateTime.Parse(Console.ReadLine());
//                        Console.WriteLine("Slot details:\n"+"slot 1 - 05:00 PM to 06:00 PM\n"+
//                            "slot 2 - 06:00 PM to 07:00 PM\n" +
//                            "slot 3 - 07:00 PM to 08:00 PM\n" +
//                            "slot 4 - 08:00 PM to 09:00 PM\n" +
//                            "slot 5 - 09:00 PM to 10:00 PM\n" );

//                        int[] Remainingslots = obj.SlotDetails(DoctorID, AppointmentDate);
//                        for(int i = 0;i< Remainingslots.Length;i++)
//                        {
//                            if (Remainingslots[i] != 0) 
//                                Console.WriteLine(Remainingslots[i]);
//                        }
//                        Console.WriteLine("Enter Slot");
//                        int slot = Convert.ToInt32(Console.ReadLine());
//                        string AppointmentTime = null;
//                        switch(slot)
//                        {
//                            case 1:
//                                AppointmentTime = "05:00";
//                                break;
//                            case 2:
//                                AppointmentTime = "06:00";
//                                break;
//                            case 3:
//                                AppointmentTime = "07:00";
//                                break;
//                            case 4:
//                                AppointmentTime = "08:00";
//                                break;
//                            case 5:
//                                AppointmentTime = "09:00";
//                                break;
                            
//                        }
//                        obj.ScheduleAppointment(PatientID, Specialization,DoctorID,AppointmentDate,slot,AppointmentTime);
//                        break;
//                    case 5:
//                        Console.WriteLine("Logged out Successfully!");
//                        break;
//                    default:
//                        Console.WriteLine("Please choose valid choice from the Menu");
//                        break;
//                }
//            }
//            else
//            {
//                Console.WriteLine("Invalid username or password!");
//                Console.WriteLine("Login not successful");
//                fun();
//            }
//        }

//    }
//}
