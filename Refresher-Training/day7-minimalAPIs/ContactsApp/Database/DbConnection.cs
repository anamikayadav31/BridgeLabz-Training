using Microsoft.Data.SqlClient;

namespace ContactsApp.Database
{
    // Creates SQL Server connections
    public class DbConnection
    {
        private readonly string connectionString;

        public DbConnection(IConfiguration configuration)
        {
            connectionString =
                configuration.GetConnectionString("DefaultConnection")!;
        }

        // Creates a new database connection
        public SqlConnection CreateConnection()
        {
            return new SqlConnection(connectionString);
        }
    }
}