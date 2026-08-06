using Microsoft.Data.SqlClient;
using HealthClinicApp.Entities;
using HealthClinicApp.Interfaces;

namespace HealthClinicApp.Services;

// =====================================================
// AppointmentService Class
// This class contains all CRUD (Create, Read, Update,
// Delete) operations for the Appointment table.
//
// It uses ADO.NET with SQL queries to communicate
// with the database.
// =====================================================

public class AppointmentService : IAppointmentService
{
    // Create object of DatabaseConnection class
    DatabaseConnection db = new DatabaseConnection();

    // =====================================================
    // Add a new appointment
    // =====================================================
    public void AddAppointment()
    {
        try
        {
            // Take input from the user
            Console.Write("Doctor Id : ");
            int doctorId = Convert.ToInt32(Console.ReadLine());

            Console.Write("Patient Id : ");
            int patientId = Convert.ToInt32(Console.ReadLine());

            Console.Write("Appointment Date (yyyy-mm-dd) : ");
            DateTime appointmentDate = Convert.ToDateTime(Console.ReadLine());

            // Get database connection
            using SqlConnection connection = db.GetConnection();

            // SQL query to insert appointment details
            string query = @"INSERT INTO Appointment
                            (doctor_id, patient_id, appointment_date)
                            VALUES
                            (@DoctorId, @PatientId, @AppointmentDate)";

            // Create SqlCommand object
            SqlCommand cmd = new SqlCommand(query, connection);

            // Pass values to SQL query parameters
            cmd.Parameters.AddWithValue("@DoctorId", doctorId);
            cmd.Parameters.AddWithValue("@PatientId", patientId);
            cmd.Parameters.AddWithValue("@AppointmentDate", appointmentDate);

            // Open the connection
            connection.Open();

            // Execute INSERT query
            int rows = cmd.ExecuteNonQuery();

            // Check whether appointment was added
            if (rows > 0)
            {
                Console.WriteLine("\nAppointment Added Successfully.");
            }
            else
            {
                Console.WriteLine("\nAppointment Not Added.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error : " + ex.Message);
        }
    }

    // =====================================================
    // Display all appointments
    // Shows doctor and patient names using INNER JOIN
    // =====================================================
    public void ViewAppointments()
    {
        try
        {
            using SqlConnection connection = db.GetConnection();

            // SQL query with INNER JOIN
            string query = @"
                SELECT
                    A.appointment_id,
                    A.appointment_date,
                    D.doctor_name,
                    P.patient_name
                FROM Appointment A
                INNER JOIN Doctor D
                    ON A.doctor_id = D.doctor_id
                INNER JOIN Patient P
                    ON A.patient_id = P.patient_id";

            SqlCommand cmd = new SqlCommand(query, connection);

            connection.Open();

            // Read data returned by the query
            SqlDataReader reader = cmd.ExecuteReader();

            Console.WriteLine();

            // Display each appointment
            while (reader.Read())
            {
                Console.WriteLine("----------------------------------------");
                Console.WriteLine($"Appointment Id : {reader["appointment_id"]}");
                Console.WriteLine($"Date           : {Convert.ToDateTime(reader["appointment_date"]).ToShortDateString()}");
                Console.WriteLine($"Doctor         : {reader["doctor_name"]}");
                Console.WriteLine($"Patient        : {reader["patient_name"]}");
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
    // Search appointment by Appointment Id
    // =====================================================
    public void SearchAppointment()
    {
        try
        {
            Console.Write("Enter Appointment Id : ");
            int appointmentId = Convert.ToInt32(Console.ReadLine());

            using SqlConnection connection = db.GetConnection();

            // SQL query to search appointment
            string query = "SELECT * FROM Appointment WHERE appointment_id = @AppointmentId";

            SqlCommand cmd = new SqlCommand(query, connection);

            // Pass appointment id
            cmd.Parameters.AddWithValue("@AppointmentId", appointmentId);

            connection.Open();

            SqlDataReader reader = cmd.ExecuteReader();

            // Check whether appointment exists
            if (reader.Read())
            {
                Console.WriteLine();
                Console.WriteLine($"Appointment Id : {reader["appointment_id"]}");
                Console.WriteLine($"Doctor Id      : {reader["doctor_id"]}");
                Console.WriteLine($"Patient Id     : {reader["patient_id"]}");
                Console.WriteLine($"Date           : {Convert.ToDateTime(reader["appointment_date"]).ToShortDateString()}");
            }
            else
            {
                Console.WriteLine("\nAppointment Not Found.");
            }

            reader.Close();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error : " + ex.Message);
        }
    }

    // =====================================================
    // Update appointment date
    // =====================================================
    public void UpdateAppointment()
    {
        try
        {
            // Take input from the user
            Console.Write("Enter Appointment Id : ");
            int appointmentId = Convert.ToInt32(Console.ReadLine());

            Console.Write("New Appointment Date (yyyy-mm-dd) : ");
            DateTime appointmentDate = Convert.ToDateTime(Console.ReadLine());

            using SqlConnection connection = db.GetConnection();

            // SQL query to update appointment date
            string query = @"UPDATE Appointment
                             SET appointment_date = @AppointmentDate
                             WHERE appointment_id = @AppointmentId";

            SqlCommand cmd = new SqlCommand(query, connection);

            // Pass parameter values
            cmd.Parameters.AddWithValue("@AppointmentDate", appointmentDate);
            cmd.Parameters.AddWithValue("@AppointmentId", appointmentId);

            connection.Open();

            // Execute UPDATE query
            int rows = cmd.ExecuteNonQuery();

            // Check whether update was successful
            if (rows > 0)
            {
                Console.WriteLine("\nAppointment Updated Successfully.");
            }
            else
            {
                Console.WriteLine("\nAppointment Not Found.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error : " + ex.Message);
        }
    }

    // =====================================================
    // Delete appointment by Appointment Id
    // =====================================================
    public void DeleteAppointment()
    {
        try
        {
            Console.Write("Enter Appointment Id : ");
            int appointmentId = Convert.ToInt32(Console.ReadLine());

            using SqlConnection connection = db.GetConnection();

            // SQL query to delete appointment
            string query = "DELETE FROM Appointment WHERE appointment_id = @AppointmentId";

            SqlCommand cmd = new SqlCommand(query, connection);

            // Pass appointment id
            cmd.Parameters.AddWithValue("@AppointmentId", appointmentId);

            connection.Open();

            // Execute DELETE query
            int rows = cmd.ExecuteNonQuery();

            // Check whether deletion was successful
            if (rows > 0)
            {
                Console.WriteLine("\nAppointment Deleted Successfully.");
            }
            else
            {
                Console.WriteLine("\nAppointment Not Found.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error : " + ex.Message);
        }
    }
}