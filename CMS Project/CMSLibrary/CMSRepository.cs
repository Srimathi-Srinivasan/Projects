using System.Data.SqlClient;

namespace CMSLibrary
{
    public class CMSRepository : ICMSRepository
    {
        public static SqlConnection con;
        public static SqlCommand cmd;
        public int Login(string username, string password)
        {
            //throw new NotImplementedException();
        }

        private static SqlConnection getcon()
        {
            con = new SqlConnection("Data Source=.;Initial Catalog = ClinicManagementSystem;Integrated Security=true");
            con.Open();
            return con;
        }
    }
}