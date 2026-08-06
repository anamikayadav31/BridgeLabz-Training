using Microsoft.Data.SqlClient;
using HealthClinicApp.Entities;
using HealthClinicApp.Interfaces;

namespace HealthClinicApp.Services;

// =====================================================
// PatientService Class
// This class contains all CRUD (Create, Read, Update,
// Delete) operations for the Patient table.
//
// It uses ADO.NET with parameterized SQL queries to
// communicate with the database.
// =====================================================

public class PatientService : IPatientService
{
    // Create object of DatabaseConnection class
    DatabaseConnection db = new DatabaseConnection();

    // =====================================================
    // Add a new patient
    // =====================================================
    public void AddPatient()
    {
        try
        {
            // Take input from the user
            Console.Write("Patient Name : ");
            string patientName = Console.ReadLine()!;

            Console.Write("Age : ");
            int age = Convert.ToInt32(Console.ReadLine());

            Console.Write("Gender : ");
            string gender = Console.ReadLine()!;

            Console.Write("Contact No : ");
            string contactNo = Console.ReadLine()!;

            Console.Write("Address : ");
            string address = Console.ReadLine()!;

            // Get database connection
            using SqlConnection connection = db.GetConnection();

            // SQL query to insert patient details
            string query = @"
                INSERT INTO Patient
                (
                    patient_name,
                    patient_age,
                    patient_gender,
                    patient_contact_no,
                    patient_address
                )
                VALUES
                (
                    @PatientName,
                    @PatientAge,
                    @PatientGender,
                    @PatientContactNo,
                    @PatientAddress
                )";

            // Create SqlCommand object
            SqlCommand cmd = new SqlCommand(query, connection);

            // Pass values to query parameters
            cmd.Parameters.AddWithValue("@PatientName", patientName);
            cmd.Parameters.AddWithValue("@PatientAge", age);
            cmd.Parameters.AddWithValue("@PatientGender", gender);
            cmd.Parameters.AddWithValue("@PatientContactNo", contactNo);
            cmd.Parameters.AddWithValue("@PatientAddress", address);

            // Open database connection
            connection.Open();

            // Execute INSERT query
            int rows = cmd.ExecuteNonQuery();

            // Check whether patient was added
            if (rows > 0)
            {
                Console.WriteLine("\nPatient Added Successfully.");
            }
            else
            {
                Console.WriteLine("\nPatient Not Added.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error : " + ex.Message);
        }
    }

    // =====================================================
    // Display all patients
    // =====================================================
    public void ViewPatients()
    {
        try
        {
            using SqlConnection connection = db.GetConnection();

            // SQL query to get all patient records
            string query = "SELECT * FROM Patient";

            SqlCommand cmd = new SqlCommand(query, connection);

            connection.Open();

            // Read records returned by the query
            SqlDataReader reader = cmd.ExecuteReader();

            Console.WriteLine();

            // Display each patient
            while (reader.Read())
            {
                Console.WriteLine("-------------------------------------");
                Console.WriteLine($"Patient Id   : {reader["patient_id"]}");
                Console.WriteLine($"Name         : {reader["patient_name"]}");
                Console.WriteLine($"Age          : {reader["patient_age"]}");
                Console.WriteLine($"Gender       : {reader["patient_gender"]}");
                Console.WriteLine($"Contact No   : {reader["patient_contact_no"]}");
                Console.WriteLine($"Address      : {reader["patient_address"]}");
            }

            // Close the reader
            reader.Close();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error : " + ex.Message);
        }
    }

    // =====================================================
    // Search patient by Patient Id
    // =====================================================
    public void SearchPatient()
    {
        try
        {
            Console.Write("Enter Patient Id : ");
            int patientId = Convert.ToInt32(Console.ReadLine());

            using SqlConnection connection = db.GetConnection();

            // SQL query to search patient
            string query = "SELECT * FROM Patient WHERE patient_id = @PatientId";

            SqlCommand cmd = new SqlCommand(query, connection);

            // Pass patient id
            cmd.Parameters.AddWithValue("@PatientId", patientId);

            connection.Open();

            SqlDataReader reader = cmd.ExecuteReader();

            // Check whether patient exists
            if (reader.Read())
            {
                Console.WriteLine();
                Console.WriteLine($"Patient Id   : {reader["patient_id"]}");
                Console.WriteLine($"Name         : {reader["patient_name"]}");
                Console.WriteLine($"Age          : {reader["patient_age"]}");
                Console.WriteLine($"Gender       : {reader["patient_gender"]}");
                Console.WriteLine($"Contact No   : {reader["patient_contact_no"]}");
                Console.WriteLine($"Address      : {reader["patient_address"]}");
            }
            else
            {
                Console.WriteLine("\nPatient Not Found.");
            }

            // Close the reader
            reader.Close();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error : " + ex.Message);
        }
    }

    // =====================================================
    // Update patient contact number and address
    // =====================================================
    public void UpdatePatient()
    {
        try
        {
            // Take input from the user
            Console.Write("Enter Patient Id : ");
            int patientId = Convert.ToInt32(Console.ReadLine());

            Console.Write("New Contact No : ");
            string contactNo = Console.ReadLine()!;

            Console.Write("New Address : ");
            string address = Console.ReadLine()!;

            using SqlConnection connection = db.GetConnection();

            // SQL query to update patient details
            string query = @"
                UPDATE Patient
                SET
                    patient_contact_no = @ContactNo,
                    patient_address = @Address
                WHERE patient_id = @PatientId";

            SqlCommand cmd = new SqlCommand(query, connection);

            // Pass parameter values
            cmd.Parameters.AddWithValue("@ContactNo", contactNo);
            cmd.Parameters.AddWithValue("@Address", address);
            cmd.Parameters.AddWithValue("@PatientId", patientId);

            connection.Open();

            // Execute UPDATE query
            int rows = cmd.ExecuteNonQuery();

            // Check whether update was successful
            if (rows > 0)
            {
                Console.WriteLine("\nPatient Updated Successfully.");
            }
            else
            {
                Console.WriteLine("\nPatient Not Found.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error : " + ex.Message);
        }
    }

    // =====================================================
    // Delete patient by Patient Id
    // =====================================================
    public void DeletePatient()
    {
        try
        {
            Console.Write("Enter Patient Id : ");
            int patientId = Convert.ToInt32(Console.ReadLine());

            using SqlConnection connection = db.GetConnection();

            // SQL query to delete patient
            string query = "DELETE FROM Patient WHERE patient_id = @PatientId";

            SqlCommand cmd = new SqlCommand(query, connection);

            // Pass patient id
            cmd.Parameters.AddWithValue("@PatientId", patientId);

            connection.Open();

            // Execute DELETE query
            int rows = cmd.ExecuteNonQuery();

            // Check whether deletion was successful
            if (rows > 0)
            {
                Console.WriteLine("\nPatient Deleted Successfully.");
            }
            else
            {
                Console.WriteLine("\nPatient Not Found.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error : " + ex.Message);
        }
    }
}