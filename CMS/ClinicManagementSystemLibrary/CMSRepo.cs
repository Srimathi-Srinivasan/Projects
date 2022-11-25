using System.Data.SqlClient;

namespace ClinicManagementSystemLibrary
{
    public class CMSRepo : ICMSRepo
    {
        private static SqlConnection con;
        private static SqlCommand cmd;
        private static SqlDataReader dr;
        
        public int Login(string username, string password)
        {
            con = getcon();
            cmd = new SqlCommand("spuserdetails");
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Connection = con;
            cmd.Parameters.AddWithValue("@username", username);
            cmd.Parameters.AddWithValue("@Password", password);
            dr = cmd.ExecuteReader();

            if(dr.HasRows)
            {
                while(dr.Read())
                {
                    if (String.Equals(username, dr["username"].ToString()) && String.Equals(password, dr["Password"].ToString()))
                    {
                        return 1;
                    }
                    else
                    {
                        return 0;
                    }
                }          
                  
                
            }
            return 0;
            
        }

        public SqlDataReader ViewDoctors()
        {
            con = getcon();
            cmd = new SqlCommand("spviewdoctors");
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Connection = con;
            dr = cmd.ExecuteReader();
            
            return dr;
        }

        public void AddPatient(string FirstName,string LastName,string Sex,int Age,DateTime DOB)
        {
            con = getcon();
            cmd = new SqlCommand("spaddpatients",con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FirstName", FirstName);
            cmd.Parameters.AddWithValue("@LastName", LastName);
            cmd.Parameters.AddWithValue("@Sex", Sex);
            cmd.Parameters.AddWithValue("@Age", Age);
            cmd.Parameters.AddWithValue("@DOB", DOB.Date);
            cmd.ExecuteNonQuery();            
        }

        public void ScheduleAppointment(int PatientID,string Specialization,int DoctorID,DateTime AppointmentDate,int slot,string AppointmentTime)
        {
            #region
            //con = getcon();
            //cmd = new SqlCommand("spgetdoctors", con);
            //cmd.CommandType = System.Data.CommandType.StoredProcedure;
            //cmd.Parameters.AddWithValue("@Specialization", Specialization);
            //SqlDataReader dr = cmd.ExecuteReader();
            //return dr;
            //while(dr.Read())
            //{
            //    for(int i=0;i<dr.FieldCount;i++)
            //    {
            //        Console.Write(dr[i]+" ");
            //    }
            //    Console.WriteLine();
            //}
            #endregion
            con = getcon();
            
            
            cmd = new SqlCommand("spschappointment", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@PatientID", PatientID);
            cmd.Parameters.AddWithValue("@Specialization", Specialization);
            cmd.Parameters.AddWithValue("VisitDate", AppointmentDate);
            cmd.Parameters.AddWithValue("@AppointmentTime", AppointmentTime);
            cmd.Parameters.AddWithValue("@DoctorID", DoctorID);
            cmd.Parameters.AddWithValue("@SlotNumber", slot);
            dr = cmd.ExecuteReader();
            
            #region
            //cmd = new SqlCommand("sptotalhrs", con);
            //cmd.CommandType = System.Data.CommandType.StoredProcedure;
            //cmd.Parameters.AddWithValue("@DoctorID", DoctorID);
            //SqlDataReader dr = cmd.ExecuteReader();
            //int n,value;
            //while (dr.Read())
            //{
            
            //    n = Convert.ToInt32(dr["TotalHrs"]);
            //    //value = Convert.ToInt32(TimeOnly.FromDateTime(Convert.ToDateTime(dr["_From"])));
            //    //value = Convert.ToInt32(Convert.ToDateTime(dr["_From"]).Time);
            //    //DateTime a = Convert.dr["_From"];
            //    //var v = TimeOnly.FromDateTime(Convert.ToDateTime(dr["_From"]));
            //    Console.WriteLine(n);
                    
            //    Console.WriteLine(a);
            //}
            //int[] arr;

            //for(int i =0;i<n;i++)
            //{
            //    arr[i] = 
            //}
            #endregion

        }

        public void CancelAppointment(int AppointmentID)
        {
            con = getcon();
            cmd = new SqlCommand("spcancelappointment", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@AppointmentID", AppointmentID);
            cmd.ExecuteNonQuery();

        }


        public SqlDataReader getdoctors(int SpecializationNumber)
        {
            string Specialization = "";
            con = getcon();
            switch(SpecializationNumber)
            {
                case 1:
                    Specialization = "General";
                    break;
                case 2:
                    Specialization = "Internal Medicine";
                    break;
                case 3:
                    Specialization = "Pediatrics";
                    break;
                case 4:
                    Specialization = "Orthopedics";
                    break;
                case 5:
                    Specialization = "Opthamology";
                    break;
                    
            }
            cmd = new SqlCommand("spgetdoctors", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Specialization", Specialization);
            dr = cmd.ExecuteReader();
            if(dr!=null)
            {                
                return dr;
            }
            return null;
        }

        public int[] SlotDetails(int DoctorID,DateTime AppointmentDate)
        {
            con = getcon();
            Console.WriteLine("Available Slots: ");
            int[] slots = { 1, 2, 3, 4, 5 };
            int[] filledslots = new int[5];
            cmd = new SqlCommand("spgetslots", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@DoctorID", DoctorID);
            cmd.Parameters.AddWithValue("@VisitDate", AppointmentDate);
            dr = cmd.ExecuteReader();
            int i = 0;
            while (dr.Read())
            {

                filledslots[i] = Convert.ToInt32(dr["SlotNumber"]);
                i++;

            }
            int[] Remainingslots = new int[5];
            int c = 0;
            for (int j = 0; j < 5; j++)
            {
                int flag = 0;
                for (int k = 0; k < 5; k++)
                {
                    if (slots[j] == filledslots[k])
                    {
                        flag = 1;

                        break;
                    }

                }
                if (flag == 0)
                {
                    Remainingslots[c] = slots[j];
                    c++;
                }
            }
            return Remainingslots;
            
        }

        public int CheckPatient(int PatientID)
        {
            con = getcon();
            cmd = new SqlCommand("spchkpatient", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@PatientID", PatientID);
            dr = cmd.ExecuteReader();
            if(dr.HasRows)
            {
                return 1;
            }
            return 0;
        }

        private static SqlConnection getcon()
        {
            con = new SqlConnection("Data Source=.;Initial Catalog = ClinicManagementSystem;Integrated Security=true");
            con.Open();
            return con;
        }

        public SqlDataReader CheckAppointment(int PatientID,DateTime AppointmentDate)
        {
            con = getcon();
            cmd = new SqlCommand("spchkappointment", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@PatientID", PatientID);
            cmd.Parameters.AddWithValue("@AppointmentDate", AppointmentDate);
            dr = cmd.ExecuteReader();
            if(dr.HasRows)
            {
                return dr;
            }
            return null;
        }
    }
}