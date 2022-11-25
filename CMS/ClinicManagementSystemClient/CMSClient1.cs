using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClinicManagementSystemLibrary;
using System.Data.SqlClient;

namespace ClinicManagementSystemClient
{
    
    internal class CMSClient1
    {
        public static SqlDataReader dr;
        public static CMSClient1 cms;
        public static ICMSRepo obj;

        public int LoginPage()
        {
            Console.WriteLine("...................Login Page....................");
            Console.WriteLine("\n\n");

            
                Console.WriteLine("Enter user name: ");
                string username = Console.ReadLine();
                if(username.All(char.IsLetterOrDigit))
                {
                    Console.WriteLine("Enter Password: ");
                    string password = Console.ReadLine();

                    obj = new CMSRepo();
                    int flag;
                    flag = obj.Login(username, password);
                    if (flag == 1)
                    {
                        return 1;
                    }
                    return 0;
                }
                else
                {
                    Console.WriteLine("Username Should not contain any Special Character");
                    return 0;
                }            
                      
                        

        }

        public void HomePage()
        {
            Console.WriteLine("\n\n");

            Console.WriteLine("...................Home Page....................");
            Console.WriteLine("\n\n");
            Console.WriteLine("Enter choice\n");
            Console.WriteLine("1: View Doctors\n" +
                                "2: Add Patient\n" +
                                "3: Schedule Appointment\n" +
                                "4: Cancel Appointment\n" +
                                "5: Logout\n"+
                                "6: Exit Application");
            int choice = Convert.ToInt32(Console.ReadLine());
            int PatientID,res;
            DateTime AppointmentDate;
            
            switch (choice)
            {
                
                case 1:
                    dr = obj.ViewDoctors();
                    
                    while (dr.Read())
                    {
                        Console.WriteLine("Doctor ID: " + dr["DoctorID"].ToString());
                        Console.WriteLine("First Name: " + dr["FirstName"].ToString());
                        Console.WriteLine("Last Name: " + dr["LastName"].ToString());
                        Console.WriteLine("Sex: " + dr["Sex"].ToString());
                        Console.WriteLine("Specialization: " + dr["Specialization"].ToString());
                        Console.WriteLine("Working Hours: " + dr["_From"].ToString() + " - " + dr["_To"].ToString());
                        Console.WriteLine("Total Working Hours: " + dr["TotalHrs"].ToString());

                        Console.WriteLine("\n");
                    }
                    cms.HomePage();
                    break;

                case 2:                                     
                                            
                       
                        Console.WriteLine("Enter First Name");
                        string FirstName = Console.ReadLine();

                        Console.WriteLine("Enter Last Name");
                        string LastName = Console.ReadLine();
                        if(FirstName.All(Char.IsLetter))
                        {
                            Console.WriteLine("Enter Sex (M/F/Others)");
                            string Sex = Console.ReadLine();
                            
                            if(Sex.All(Char.IsLetter))
                            {
                                
                                if(Sex.Contains('M')==true || Sex.Contains('F')==true || Sex.Contains("Others")== true||Sex.Contains('m') == true || Sex.Contains('f') == true || Sex.Contains("others") == true)
                                {
                                    try
                                    {
                                        Console.WriteLine("Enter Age (Age should be between 0 to 120)");
                                        int Age = Convert.ToInt32(Console.ReadLine());
                                        if(Age >= 0 && Age <= 120)
                                        {
                                            try
                                            {
                                                Console.WriteLine("Enter Date of Birth (DD/MM/YYYY) or (YYYY/MM/DD)");
                                                DateTime DOB = DateTime.Parse(Console.ReadLine());
                                                obj.AddPatient(FirstName, LastName, Sex, Age, DOB);
                                                Console.WriteLine();
                                                Console.WriteLine("Patient details added successfully.");
                                            }
                                            catch(FormatException)
                                            {
                                                Console.WriteLine("Invalid Date Format for DOB");
                                            cms.HomePage();
                                            }

                                        }
                                        else
                                        {
                                            Console.WriteLine("Invalid Age");
                                        cms.HomePage();
                                        }
                                        
                                    }
                                    catch(FormatException)
                                    {
                                        Console.WriteLine("Age Should Contain only Numbers");
                                    cms.HomePage();
                                    }
                                    

                                }
                                else
                                {
                                    Console.WriteLine("Enter valid Choice");
                                cms.HomePage();
                                }
                                
                            }
                            
                        }
                            
                        
                        else
                        {
                            Console.WriteLine("Patient Name should contain only Alphabets");
                        cms.HomePage();

                        }

                    cms.HomePage();
                    
                    
                    break;

                case 3:
                    {
                        try
                        {
                            Console.WriteLine("Enter Patient ID");
                            PatientID = Convert.ToInt32(Console.ReadLine());
                            res = obj.CheckPatient(PatientID);
                            string Specialization = "";
                            if (res == 1)
                            {
                                Console.WriteLine("Enter Specialization Required");
                                Console.WriteLine("1: General\n2: Internal Medicine\n3: Pediatrics\n4: Orthopedics\n5: Opthamology");
                                int SpecializationNumber = Convert.ToInt32(Console.ReadLine());
                                if (SpecializationNumber >= 1 && SpecializationNumber <= 5)
                                {
                                    dr = obj.getdoctors(SpecializationNumber);


                                    if (dr.HasRows)
                                    {
                                        Console.WriteLine("Doctors Available:\n");
                                        while (dr.Read())
                                        {

                                            Console.WriteLine("Doctor ID: " + dr["DoctorID"].ToString());
                                            Console.WriteLine("First Name: " + dr["FirstName"].ToString());
                                            Console.WriteLine("Last Name: " + dr["LastName"].ToString());
                                            Console.WriteLine("Sex: " + dr["Sex"].ToString());
                                            Console.WriteLine("Specialization: " + dr["Specialization"].ToString());
                                            Console.WriteLine("Working Hours: " + dr["_From"].ToString() + " - " + dr["_To"].ToString());
                                            Console.WriteLine("Total Working Hours: " + dr["TotalHrs"].ToString());

                                            Console.WriteLine("\n");
                                            Specialization = dr["Specialization"].ToString();
                                        }
                                        Console.WriteLine("Select Doctor by entering Doctor ID");
                                        int DoctorID = Convert.ToInt32(Console.ReadLine());
                                        try
                                        {
                                            Console.WriteLine("Enter Appointment Date (DD/MM/YYYY) or (YYYY/MM/DD)");
                                            AppointmentDate = DateTime.Parse(Console.ReadLine());
                                            Console.WriteLine("Slot details:\n" + "slot 1 - 05:00 PM to 06:00 PM\n" +
                                                "slot 2 - 06:00 PM to 07:00 PM\n" +
                                                "slot 3 - 07:00 PM to 08:00 PM\n" +
                                                "slot 4 - 08:00 PM to 09:00 PM\n" +
                                                "slot 5 - 09:00 PM to 10:00 PM\n");

                                            int[] Remainingslots = obj.SlotDetails(DoctorID, AppointmentDate);
                                            for (int i = 0; i < Remainingslots.Length; i++)
                                            {
                                                if (Remainingslots[i] != 0)
                                                    Console.WriteLine(Remainingslots[i]);
                                            }
                                            Console.WriteLine("Enter Slot");
                                            int slot = Convert.ToInt32(Console.ReadLine());
                                            string AppointmentTime = null;
                                            switch (slot)
                                            {
                                                case 1:
                                                    AppointmentTime = "05:00";
                                                    break;
                                                case 2:
                                                    AppointmentTime = "06:00";
                                                    break;
                                                case 3:
                                                    AppointmentTime = "07:00";
                                                    break;
                                                case 4:
                                                    AppointmentTime = "08:00";
                                                    break;
                                                case 5:
                                                    AppointmentTime = "09:00";
                                                    break;

                                            }
                                            obj.ScheduleAppointment(PatientID, Specialization, DoctorID, AppointmentDate, slot, AppointmentTime);

                                        }
                                        catch (FormatException)
                                        {
                                            Console.WriteLine("Invalid Date Format");
                                            cms.HomePage();
                                        }


                                    }
                                    else
                                    {
                                        Console.WriteLine("No Doctors Available for Specified Specialization");
                                        cms.HomePage();
                                    }

                                }
                                else
                                {
                                    Console.WriteLine("Invalid Specialization Number");
                                    cms.HomePage();
                                }

                            }
                            else
                            {
                                Console.WriteLine("Patient ID not Found");
                                cms.HomePage();
                            }

                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Patient ID should contain only Numbers");
                            cms.HomePage();
                        }

                        break;
                    }

                case 4:
                    Console.WriteLine("Enter Patient ID");
                    PatientID = Convert.ToInt32(Console.ReadLine());
                    res = obj.CheckPatient(PatientID);
                    if(res == 1)
                    {
                        Console.WriteLine("Enter Appointment Date");
                        AppointmentDate = Convert.ToDateTime(Console.ReadLine());
                        dr = obj.CheckAppointment(PatientID,AppointmentDate);
                        Console.WriteLine("\n\n");
                        Console.WriteLine("Patients Appointment");
                        if(dr.HasRows)
                        {
                            while(dr.Read())
                            {
                                Console.WriteLine("Appointment ID: " + dr["AppointmentID"].ToString());
                                Console.WriteLine("Patient ID: " + dr["PatientID"].ToString());
                                Console.WriteLine("Specialization Required: " + dr["SpecializationRequired"].ToString());
                                Console.WriteLine("Doctor: " + dr["Doctor"].ToString());
                                Console.WriteLine("Visit Date: " + dr["VisitDate"].ToString());
                                Console.WriteLine("Appointment Time: " + dr["AppointmentTime"].ToString());
                                Console.WriteLine("Slot: " + dr["SlotNumber"].ToString());
                                Console.WriteLine("\n");
                            }
                        }
                        else
                        {
                            Console.WriteLine("No Appointment found for patient on "+ AppointmentDate);
                            cms.HomePage();
                        }
                        Console.WriteLine("Enter Appointment ID");
                        int AppointmentID = Convert.ToInt32(Console.ReadLine());
                        obj.CancelAppointment(AppointmentID);
                        Console.WriteLine("Appointment Cancelled Successfully");
                        cms.HomePage();

                    }
                    else
                    {
                        Console.WriteLine("Patient ID not found");
                        cms.HomePage();
                    }

                    break;

                case 5:
                    Console.WriteLine("Logged out Successfully!");
                    cms.LoginPage();
                    break;
                case 6:
                    Console.WriteLine("Thank You!");
                    break;
            }
        }

        public static void Main()
        {
            Console.WriteLine("...................Welcome to AB Clinic....................");
            Console.WriteLine("\n\n\n");

            cms = new CMSClient1();
            int flag,i=0;
            flag = cms.LoginPage();
            while(flag!=1)
            {
                Console.WriteLine("Login not Successful");
                Console.WriteLine("Invalid Username or Password");
                Console.WriteLine("\n");
                i++;
                if (i == 3)
                {
                    Console.WriteLine("Try after sometime");
                    break;
                }
                flag = cms.LoginPage();
                
            }
            if(flag == 1)
            {
                Console.WriteLine("Successfully Logged in");
                cms.HomePage();
                
            }


        }
    }
}
