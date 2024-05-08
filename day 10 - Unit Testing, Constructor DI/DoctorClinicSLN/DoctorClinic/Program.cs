using System.Data.SqlClient;

namespace DoctorClinic
{
    internal class Program
    {


        static void Main(string[] args)
        {

            SqlConnection conn = new(@"Data Source=C0RBBX3\SQLSERVERG3;Initial Catalog=NorthWind;Integrated Security=True");
        }
    }
}
