using Microsoft.Data.SqlClient;

namespace HealthClinicApp.Services;

// =====================================================
// DatabaseConnection Class
// This class is used to connect the C# application
// with the SQL Server database.
// =====================================================

public class DatabaseConnection
{
    // Connection string stores the database details.
    // Server = SQL Server instance name.
    // Database = Name of the database.
    // Trusted_Connection=True = Uses Windows Authentication.
    // TrustServerCertificate=True = Trusts the SQL Server certificate.

    private readonly string connectionString =
        "Server=localhost\\SQLEXPRESS;Database=HealthCare;Trusted_Connection=True;TrustServerCertificate=True;";

    // =====================================================
    // This method creates and returns a SqlConnection
    // object using the connection string.
    // Every service class calls this method whenever
    // it needs to connect to the database.
    // =====================================================
    public SqlConnection GetConnection()
    {
        // Create a new SQL Server connection
        SqlConnection connection = new SqlConnection(connectionString);

        // Return the connection object
        return connection;
    }
}