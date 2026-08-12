using ContactsApp.Database;
using ContactsApp.Models;
using Microsoft.Data.SqlClient;

namespace ContactsApp.Repositories;

// This class actually talks to the database using plain ADO.NET
// (SqlConnection, SqlCommand, SqlDataReader). I kept it simple and
// did not use Entity Framework so I can understand exactly what
// SQL is running behind the scenes.
public class ContactRepository : IContactRepository
{
    private readonly DbConnection dbConnection;

    public ContactRepository(DbConnection dbConnection)
    {
        this.dbConnection = dbConnection;
    }

    // Get every contact from the Contacts table
    public List<Contact> GetAll()
    {
        List<Contact> contacts = new List<Contact>();

        using (SqlConnection connection = dbConnection.CreateConnection())
        {
            connection.Open();

            string query = "SELECT Id, Name, Email, Phone FROM Contacts";
            SqlCommand command = new SqlCommand(query, connection);

            using (SqlDataReader reader = command.ExecuteReader())
            {
                // Loop through every row that comes back and build a Contact object
                while (reader.Read())
                {
                    Contact contact = new Contact();
                    contact.Id = Convert.ToInt32(reader["Id"]);
                    contact.Name = reader["Name"].ToString()!;
                    contact.Email = reader["Email"].ToString()!;
                    contact.Phone = reader["Phone"].ToString()!;

                    contacts.Add(contact);
                }
            }
        }

        return contacts;
    }

    // Get a single contact by its Id. Returns null if not found.
    public Contact? GetById(int id)
    {
        Contact? contact = null;

        using (SqlConnection connection = dbConnection.CreateConnection())
        {
            connection.Open();

            string query = "SELECT Id, Name, Email, Phone FROM Contacts WHERE Id = @Id";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Id", id);

            using (SqlDataReader reader = command.ExecuteReader())
            {
                if (reader.Read())
                {
                    contact = new Contact();
                    contact.Id = Convert.ToInt32(reader["Id"]);
                    contact.Name = reader["Name"].ToString()!;
                    contact.Email = reader["Email"].ToString()!;
                    contact.Phone = reader["Phone"].ToString()!;
                }
            }
        }

        return contact;
    }

    // Insert a new contact into the table
    public void Add(Contact contact)
    {
        using (SqlConnection connection = dbConnection.CreateConnection())
        {
            connection.Open();

            string query = "INSERT INTO Contacts (Name, Email, Phone) VALUES (@Name, @Email, @Phone)";
            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@Name", contact.Name);
            command.Parameters.AddWithValue("@Email", contact.Email);
            command.Parameters.AddWithValue("@Phone", contact.Phone);

            command.ExecuteNonQuery();
        }
    }

    // Update an existing contact by Id
    public void Update(Contact contact)
    {
        using (SqlConnection connection = dbConnection.CreateConnection())
        {
            connection.Open();

            string query = "UPDATE Contacts SET Name = @Name, Email = @Email, Phone = @Phone WHERE Id = @Id";
            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@Id", contact.Id);
            command.Parameters.AddWithValue("@Name", contact.Name);
            command.Parameters.AddWithValue("@Email", contact.Email);
            command.Parameters.AddWithValue("@Phone", contact.Phone);

            command.ExecuteNonQuery();
        }
    }

    // Delete a contact by Id
    public void Delete(int id)
    {
        using (SqlConnection connection = dbConnection.CreateConnection())
        {
            connection.Open();

            string query = "DELETE FROM Contacts WHERE Id = @Id";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Id", id);

            command.ExecuteNonQuery();
        }
    }
}
