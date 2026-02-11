using Microsoft.Data.SqlClient;

namespace HealthCareApp;

public class DBConnection
{
    private static string connectionString =
        "Server=localhost\\SQLEXPRESS;Database=HealthClinicDB;Trusted_Connection=True;TrustServerCertificate=True";

    public static SqlConnection GetConnection()
    {
        SqlConnection con = new SqlConnection(connectionString);
        con.Open();
        return con;
    }
}


