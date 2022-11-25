using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace ClinicManagementSystemLibrary
{
    public interface ICMSRepo
    {
        int Login(string username, string password);
        SqlDataReader ViewDoctors();
        void AddPatient(string FirstName, string LastName, string Sex, int Age, DateTime DOB);

        void ScheduleAppointment(int PatientID, string Specialization, int DoctorID, DateTime AppointmentDate, int slot, string AppointmentTime);

        SqlDataReader getdoctors(int SpecializationNumber);

        int[] SlotDetails(int DoctorID, DateTime AppointmentDate);

        int CheckPatient(int PatientID);

        void CancelAppointment(int AppointmentID);

        SqlDataReader CheckAppointment(int PatientID,DateTime AppointmentDate);


    }
}
