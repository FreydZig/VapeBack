using System.Data.SqlClient;

namespace DataLayer
{
    public class BaseRepository
    {
        public static SqlConnection GetConnection()
        {
            return new SqlConnection("Data Source=localhost\\SQLEXPRESS;Initial Catalog=VapeTravel;Integrated Security=True");
        }
    }
}
