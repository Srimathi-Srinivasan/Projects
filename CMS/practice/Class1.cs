using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
namespace practice
{
    internal class Class1
    {
        public static SqlConnection con;
        public static SqlCommand cmd;

        private static SqlConnection getcon()
        {
            con = new SqlConnection("Data Source=.;Initial Catalog = ClinicManagementSystem;Integrated Security=true");
            con.Open();
            return con;
        }

        public static void Main()
        {
            #region
            //con = getcon();
            //cmd = new SqlCommand("sptotalhrs", con);
            //cmd.CommandType = System.Data.CommandType.StoredProcedure;
            //cmd.Parameters.AddWithValue("@DoctorID", 1002);
            //SqlDataReader dr = cmd.ExecuteReader();
            //int n, value;
            //while (dr.Read())
            //{

            //    n = Convert.ToInt32(dr["TotalHrs"]);
            //    Console.WriteLine(n);
            //    //value = Convert.ToInt32(TimeOnly.FromDateTime(Convert.ToDateTime(dr["_From"])));
            //    //value = Convert.ToInt32(Convert.ToDateTime(dr["_From"]).Time);

            //    //TimeSpan x = TimeSpan.Parse(dr["_From"].ToString());
            //    string x = dr["_From"].ToString();
            //    Console.WriteLine(x);
            //    var a = dr["_From"].ToString();
            //    int[] arr = new int[n];
            //    int c = Convert.ToInt32(string.Concat(a[0], a[1]));
            //    arr[0] = c;
            //    for(int i = 1;i<n;i++)
            //    {
            //        arr[i] = arr[i - 1] + 1;
            //    }
            //    //for(int i =0;i<n;i++)
            //    //{
            //    //    Console.WriteLine(arr[i]);
            //    //}


            //    //var b = Convert.ToInt32(a[0] + a[1]);
            //    //var v = TimeOnly.FromDateTime(Convert.ToDateTime(dr["_From"]));
            //    //Console.WriteLine(n);

            //    //Console.WriteLine(a);
            //    //Console.WriteLine(a[0]);
            //    //Console.WriteLine(a[1]);
            //    //Console.WriteLine(b);
            //    //Console.WriteLine(c);
            //    //Console.WriteLine(arr[0]);
            //}
            #endregion
            con = getcon();
            Console.WriteLine("Available Slots: ");
            int[] arr = { 1, 2, 3, 4, 5 };
            int[] a = {0,0,0,0,0};
            cmd = new SqlCommand("spgetslots", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@DoctorID", 1002);
            cmd.Parameters.AddWithValue("@VisitDate", "08/27/2022");
            SqlDataReader dr = cmd.ExecuteReader();
            int i = 0;
            //while(dr.Read())
            //{
            //    for(int x = 0;x<dr.FieldCount;x++)
            //    {
            //        Console.Write(dr[x]+" ");
            //    }
            //    Console.WriteLine();
            //}
            while(dr.Read())
            {
                
                a[i] = Convert.ToInt32(dr["SlotNumber"]);
                i++;
                
            }
            //Console.WriteLine(a[1]);
            //for (int j = 0; j < 5; j++)
            //{
            //    Console.WriteLine(a[j]);
            //}
            int[] b = new int[5];
            int c = 0;
            for (int j=0; j < 5; j++)
            {
                int flag = 0;
                for(int k = 0;k < 5; k++)
                {
                    if (arr[j] == a[k])
                    {
                        flag = 1;
                        
                        break;
                    }
                    
                }
                if(flag == 0)
                {
                    b[c] = arr[j];
                    c++;
                }
            }
            for(i=0;i<c;i++)
            {
                Console.WriteLine(b[i]);
            }
        }
    }
}
