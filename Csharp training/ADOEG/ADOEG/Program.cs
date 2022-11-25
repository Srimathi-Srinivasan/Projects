using System;
using System.Data.SqlClient;
using System.Data;

namespace ADOEG
{
    internal class Program
    {
        public static SqlConnection con;
        public static SqlCommand cmd;
        private static void SelectData()
        {
            con = getcon();
            //cmd = new SqlCommand("select * from employee");
            cmd = new SqlCommand("spselectemp");
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Connection = con;
            SqlDataReader dr = cmd.ExecuteReader();//ExecuteReader gives data from table so it should be accessed using an instance

            while (dr.Read()) //till there are number of rows
            {
                for (int i = 0; i < dr.FieldCount; i++) //number of columns
                {
                    Console.Write(dr[i] + " ");
                }
                Console.WriteLine();
            }
        }

        private static SqlConnection getcon()
        {
            con = new SqlConnection("Data Source=.;Initial Catalog = eurofins;Integrated Security=true");
            con.Open(); //establish connection between 2 exe
            return con;
        }

        private static void InsertData()
        {
            con = getcon();
            Console.WriteLine("Enter eid,ename,gender,location,department,salary,deptid: ");
            int eid = Convert.ToInt32(Console.ReadLine());
            string ename = Console.ReadLine();
            string gender = Console.ReadLine();
            string location = Console.ReadLine();
            string dept = Console.ReadLine();
            decimal salary = Convert.ToDecimal(Console.ReadLine());
            DateTime joiningdate = DateTime.Now;
            int deptid = Convert.ToInt32(Console.ReadLine());
            cmd = new SqlCommand("insert into employee values(@eid,@ename,@gender,@location,@dept,@salary,@joiningdate,@deptid)");
            cmd.Connection = con;
            cmd.Parameters.AddWithValue("@eid", eid);
            cmd.Parameters.AddWithValue("@ename", ename);
            cmd.Parameters.AddWithValue("@gender", gender);
            cmd.Parameters.AddWithValue("@location", location);
            cmd.Parameters.AddWithValue("@dept", dept);
            cmd.Parameters.AddWithValue("@salary", salary);
            cmd.Parameters.AddWithValue("@joiningdate", joiningdate);
            cmd.Parameters.AddWithValue("@deptid", deptid);

            int i = cmd.ExecuteNonQuery();
            Console.WriteLine(i + " number of row(s) affected ");
        }

        private static void DisconSelectData()
        {
            con = getcon();
            //cmd = new SqlCommand("select * from employee", con);
            cmd = new SqlCommand("select * from employee;select * from course", con);
            //cmd.Connection = con;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            //DataTable dt = ds.Tables[0];
            DataTable dt1 = ds.Tables[0];
            DataTable dt2 = ds.Tables[1];

            foreach(DataRow dr in dt1.Rows)
            {
                foreach(var item in dr.ItemArray)
                {
                    Console.Write(item+" ");
                }
                Console.WriteLine();
            }

            Console.WriteLine("--------------------------------------------------------------");

            foreach(DataRow dr in dt2.Rows)
            {
                foreach(var item in dr.ItemArray)
                {
                    Console.Write(item+" ");
                }
                Console.WriteLine();
            }
        }
        public static void main()
        {
            //InsertData();
            //SelectData();
            DisconSelectData();
        }
    }
}