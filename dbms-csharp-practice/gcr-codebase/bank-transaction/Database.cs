using Microsoft.Data.SqlClient;

public class DatabaseHelper
{
    private readonly string _connectionString;

    // Constructor: store the connection string
    public DatabaseHelper(string connectionString)
    {
        _connectionString = connectionString;
    }

    // Create and return a new SQL connection
    public SqlConnection GetConnection()
    {
        return new SqlConnection(_connectionString);
    }
}
