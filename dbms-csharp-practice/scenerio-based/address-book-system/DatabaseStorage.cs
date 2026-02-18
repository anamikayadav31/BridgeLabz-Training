using System.Collections.Generic;
using System.Data.SqlClient;

namespace AddressBookSystem
{
    // This class handles database operations
    // Implements IDataStorage interface
    internal class DatabaseStorage : IDataStorage
    {
        // Connection string to SQL Server database
        // Change server/db name if needed
        private string connectionString =
            "Server=localhost\\SQLEXPRESS;Database=AddressBookDB;Trusted_Connection=True;";

        // Save contacts to database
        public void Save(List<Contact> contacts)
        {
            // Create and open DB connection
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                // Insert each contact into DB
                foreach (var c in contacts)
                {
                    // SQL insert query with parameters
                    string query =
                        "INSERT INTO Contacts VALUES(@fn,@ln,@addr,@city,@state,@zip,@phone,@email)";

                    SqlCommand cmd = new SqlCommand(query, conn);

                    // Pass values safely using parameters (prevents SQL injection)
                    cmd.Parameters.AddWithValue("@fn", c.FirstName);
                    cmd.Parameters.AddWithValue("@ln", c.LastName);
                    cmd.Parameters.AddWithValue("@addr", c.Address);
                    cmd.Parameters.AddWithValue("@city", c.City);
                    cmd.Parameters.AddWithValue("@state", c.State);
                    cmd.Parameters.AddWithValue("@zip", c.Zip);
                    cmd.Parameters.AddWithValue("@phone", c.Phone);
                    cmd.Parameters.AddWithValue("@email", c.Email);

                    // Execute insert command
                    cmd.ExecuteNonQuery();
                }
            } // Connection auto-closes here
        }

        // Load contacts from database
        public List<Contact> Load()
        {
            // Create list to store contacts
            List<Contact> list = new List<Contact>();

            // Open DB connection
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                // Query to fetch all contacts
                string query = "SELECT * FROM Contacts";
                SqlCommand cmd = new SqlCommand(query, conn);

                // Execute and read data
                SqlDataReader reader = cmd.ExecuteReader();

                // Read each row from DB
                while (reader.Read())
                {
                    // Create Contact object from DB row
                    list.Add(new Contact(
                        reader[0].ToString(),
                        reader[1].ToString(),
                        reader[2].ToString(),
                        reader[3].ToString(),
                        reader[4].ToString(),
                        reader[5].ToString(),
                        reader[6].ToString(),
                        reader[7].ToString()
                    ));
                }
            } // Connection auto-closes here

            // Return loaded contacts
            return list;
        }
    }
}
