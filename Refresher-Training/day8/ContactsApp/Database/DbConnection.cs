using Microsoft.Data.SqlClient;

namespace ContactsApp.Database;

// This class is used to create a new connection to the SQL Server database.
// I read the connection string from appsettings.json and use it every time
// I need to talk to the database.
public class DbConnection
{
    private readonly string connectionString;

    public DbConnection(IConfiguration configuration)
    {
        // "DefaultConnection" is the name I gave to my connection string
        // inside appsettings.json
        connectionString = configuration.GetConnectionString("DefaultConnection")!;
    }

    // Every time this is called, it gives back a brand new SqlConnection.
    // I open/close it separately wherever I use it.
    public SqlConnection CreateConnection()
    {
        SqlConnection connection = new SqlConnection(connectionString);
        return connection;
    }
}
