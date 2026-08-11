using ContactsApp.Database;
using ContactsApp.Models;
using Microsoft.Data.SqlClient;

namespace ContactsApp.Repositories
{
    public class ContactRepository : IContactRepository
    {
        private readonly DbConnection dbConnection;

        public ContactRepository(DbConnection dbConnection)
        {
            this.dbConnection = dbConnection;
        }

        // Get all contacts
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

        // Get contact by ID
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

        // Add contact
        public void Add(Contact contact)
        {
            using (SqlConnection connection = dbConnection.CreateConnection())
            {
                connection.Open();

                string query = "INSERT INTO Contacts (Name, Email, Phone) " +
                               "VALUES (@Name, @Email, @Phone)";

                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@Name", contact.Name);
                command.Parameters.AddWithValue("@Email", contact.Email);
                command.Parameters.AddWithValue("@Phone", contact.Phone);

                command.ExecuteNonQuery();
            }
        }

        // Update contact
        public void Update(Contact contact)
        {
            using (SqlConnection connection = dbConnection.CreateConnection())
            {
                connection.Open();

                string query = "UPDATE Contacts SET Name = @Name, " +
                               "Email = @Email, Phone = @Phone WHERE Id = @Id";

                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@Id", contact.Id);
                command.Parameters.AddWithValue("@Name", contact.Name);
                command.Parameters.AddWithValue("@Email", contact.Email);
                command.Parameters.AddWithValue("@Phone", contact.Phone);

                command.ExecuteNonQuery();
            }
        }

        // Delete contact
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
}