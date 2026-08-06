using System.Data;
using Microsoft.Data.SqlClient;
using HealthClinicApp.Entities;
using HealthClinicApp.Interfaces;

namespace HealthClinicApp.Services;

// =====================================================
// DoctorService Class
// This class contains all CRUD (Create, Read, Update,
// Delete) operations for the Doctor table.
//
// It uses SQL Stored Procedures to communicate with
// the database.
// =====================================================

public class DoctorService : IDoctorService
{
    // Create an object of DatabaseConnection class
    DatabaseConnection db = new DatabaseConnection();

    // =====================================================
    // Add a new doctor into the database
    // =====================================================
    public void AddDoctor()
    {
        try
        {
            // Take input from the user
            Console.Write("Doctor Id : ");
            int doctorId = Convert.ToInt32(Console.ReadLine());

            Console.Write("Doctor Name : ");
            string doctorName = Console.ReadLine()!;

            Console.Write("Speciality : ");
            string speciality = Console.ReadLine()!;

            Console.Write("Contact No : ");
            string contactNo = Console.ReadLine()!;

            // Get database connection
            using SqlConnection connection = db.GetConnection();

            // Create command object and specify stored procedure name
            SqlCommand cmd = new SqlCommand("sp_AddDoctor", connection);

            // Tell ADO.NET that we are calling a stored procedure
            cmd.CommandType = CommandType.StoredProcedure;

            // Pass values to stored procedure parameters
            cmd.Parameters.AddWithValue("@DoctorId", doctorId);
            cmd.Parameters.AddWithValue("@DoctorName", doctorName);
            cmd.Parameters.AddWithValue("@Speciality", speciality);
            cmd.Parameters.AddWithValue("@ContactNo", contactNo);

            // Open database connection
            connection.Open();

            // Execute the stored procedure
            int rows = cmd.ExecuteNonQuery();

            // Check whether record was inserted
            if (rows > 0)
            {
                Console.WriteLine("\nDoctor Added Successfully.");
            }
            else
            {
                Console.WriteLine("\nDoctor Not Added.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error : " + ex.Message);
        }
    }

    // =====================================================
    // Display all doctors from the database
    // =====================================================
    public void ViewDoctors()
    {
        try
        {
            using SqlConnection connection = db.GetConnection();

            // Call stored procedure
            SqlCommand cmd = new SqlCommand("sp_GetAllDoctors", connection);
            cmd.CommandType = CommandType.StoredProcedure;

            connection.Open();

            // Read data returned by the stored procedure
            SqlDataReader reader = cmd.ExecuteReader();

            Console.WriteLine();

            // Loop through each record
            while (reader.Read())
            {
                Console.WriteLine("----------------------------------");
                Console.WriteLine($"Doctor Id  : {reader["doctor_id"]}");
                Console.WriteLine($"Name       : {reader["doctor_name"]}");
                Console.WriteLine($"Speciality : {reader["speciality"]}");
                Console.WriteLine($"Contact No : {reader["contact_no"]}");
            }

            // Close reader after use
            reader.Close();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error : " + ex.Message);
        }
    }

    // =====================================================
    // Search doctor by Doctor Id
    // =====================================================
    public void SearchDoctor()
    {
        try
        {
            Console.Write("Enter Doctor Id : ");
            int doctorId = Convert.ToInt32(Console.ReadLine());

            using SqlConnection connection = db.GetConnection();

            // Call stored procedure
            SqlCommand cmd = new SqlCommand("sp_GetDoctorById", connection);
            cmd.CommandType = CommandType.StoredProcedure;

            // Pass doctor id
            cmd.Parameters.AddWithValue("@DoctorId", doctorId);

            connection.Open();

            SqlDataReader reader = cmd.ExecuteReader();

            // Check if record exists
            if (reader.Read())
            {
                Console.WriteLine();
                Console.WriteLine($"Doctor Id  : {reader["doctor_id"]}");
                Console.WriteLine($"Name       : {reader["doctor_name"]}");
                Console.WriteLine($"Speciality : {reader["speciality"]}");
                Console.WriteLine($"Contact No : {reader["contact_no"]}");
            }
            else
            {
                Console.WriteLine("\nDoctor Not Found.");
            }

            reader.Close();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error : " + ex.Message);
        }
    }

    // =====================================================
    // Update existing doctor information
    // =====================================================
    public void UpdateDoctor()
    {
        try
        {
            // Take updated information from the user
            Console.Write("Enter Doctor Id : ");
            int doctorId = Convert.ToInt32(Console.ReadLine());

            Console.Write("New Doctor Name : ");
            string doctorName = Console.ReadLine()!;

            Console.Write("New Speciality : ");
            string speciality = Console.ReadLine()!;

            Console.Write("New Contact No : ");
            string contactNo = Console.ReadLine()!;

            using SqlConnection connection = db.GetConnection();

            // Call update stored procedure
            SqlCommand cmd = new SqlCommand("sp_UpdateDoctor", connection);
            cmd.CommandType = CommandType.StoredProcedure;

            // Pass parameters
            cmd.Parameters.AddWithValue("@DoctorId", doctorId);
            cmd.Parameters.AddWithValue("@DoctorName", doctorName);
            cmd.Parameters.AddWithValue("@Speciality", speciality);
            cmd.Parameters.AddWithValue("@ContactNo", contactNo);

            connection.Open();

            int rows = cmd.ExecuteNonQuery();

            // Check whether update was successful
            if (rows > 0)
            {
                Console.WriteLine("\nDoctor Updated Successfully.");
            }
            else
            {
                Console.WriteLine("\nDoctor Not Found.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error : " + ex.Message);
        }
    }

    // =====================================================
    // Delete doctor by Doctor Id
    // =====================================================
    public void DeleteDoctor()
    {
        try
        {
            Console.Write("Enter Doctor Id : ");
            int doctorId = Convert.ToInt32(Console.ReadLine());

            using SqlConnection connection = db.GetConnection();

            // Call delete stored procedure
            SqlCommand cmd = new SqlCommand("sp_DeleteDoctor", connection);
            cmd.CommandType = CommandType.StoredProcedure;

            // Pass doctor id
            cmd.Parameters.AddWithValue("@DoctorId", doctorId);

            connection.Open();

            int rows = cmd.ExecuteNonQuery();

            // Check whether deletion was successful
            if (rows > 0)
            {
                Console.WriteLine("\nDoctor Deleted Successfully.");
            }
            else
            {
                Console.WriteLine("\nDoctor Not Found.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error : " + ex.Message);
        }
    }
}