using System;
using Microsoft.Data.SqlClient;

namespace HealthCareApp;

public class PatientService : IPatientService
{
    public void RegisterPatient()
    {
        using SqlConnection con = DBConnection.GetConnection();

        // Check doctors exist
        SqlCommand docCheck = new SqlCommand(
            "SELECT COUNT(*) FROM doctor WHERE is_active=1", con);

        int docCount = (int)docCheck.ExecuteScalar();

        if (docCount == 0)
        {
            Console.WriteLine(" No doctors available. Add doctor first!");
            return;
        }

        Console.Write("Name: ");
        string name = Console.ReadLine() ?? "";

        Console.Write("DOB (yyyy-mm-dd): ");
        if (!DateTime.TryParse(Console.ReadLine(), out DateTime dob))
        {
            Console.WriteLine("Invalid DOB!");
            return;
        }

        Console.Write("Phone: ");
        string phone = Console.ReadLine() ?? "";

        Console.Write("Email: ");
        string email = Console.ReadLine() ?? "";

        Console.Write("Address: ");
        string address = Console.ReadLine() ?? "";

        Console.Write("Blood Group: ");
        string blood = Console.ReadLine() ?? "";

        // Check duplicate phone/email
        SqlCommand dupCheck = new SqlCommand(
            "SELECT COUNT(*) FROM patient WHERE phone=@p OR email=@e", con);
        dupCheck.Parameters.AddWithValue("@p", phone);
        dupCheck.Parameters.AddWithValue("@e", email);

        if ((int)dupCheck.ExecuteScalar() > 0)
        {
            Console.WriteLine(" Phone or Email already exists!");
            return;
        }

        // Show doctors
        Console.WriteLine("\nAvailable Doctors:");
        SqlCommand showDoc = new SqlCommand(
            "SELECT doctor_id, doctor_name FROM doctor WHERE is_active=1", con);

        SqlDataReader dr = showDoc.ExecuteReader();
        while (dr.Read())
            Console.WriteLine($"{dr["doctor_id"]} - {dr["doctor_name"]}");
        dr.Close();

        Console.Write("Doctor ID: ");
        if (!int.TryParse(Console.ReadLine(), out int docId))
        {
            Console.WriteLine("Invalid Doctor ID!");
            return;
        }

        // Validate doctor
        SqlCommand validDoc = new SqlCommand(
            "SELECT COUNT(*) FROM doctor WHERE doctor_id=@id", con);
        validDoc.Parameters.AddWithValue("@id", docId);

        if ((int)validDoc.ExecuteScalar() == 0)
        {
            Console.WriteLine(" Doctor not found!");
            return;
        }

        // Insert patient
        string q = @"INSERT INTO patient
        (patient_name,dob,phone,email,address,blood_group,doctor_id)
        VALUES (@name,@dob,@phone,@email,@addr,@blood,@doc)";

        SqlCommand cmd = new SqlCommand(q, con);
        cmd.Parameters.AddWithValue("@name", name);
        cmd.Parameters.AddWithValue("@dob", dob);
        cmd.Parameters.AddWithValue("@phone", phone);
        cmd.Parameters.AddWithValue("@email", email);
        cmd.Parameters.AddWithValue("@addr", address);
        cmd.Parameters.AddWithValue("@blood", blood);
        cmd.Parameters.AddWithValue("@doc", docId);

        cmd.ExecuteNonQuery();

        Console.WriteLine(" Patient Registered Successfully!");
    }

    // FULL UPDATE
    public void UpdatePatient()
    {
        using SqlConnection con = DBConnection.GetConnection();

        Console.Write("Patient ID: ");
        if (!int.TryParse(Console.ReadLine(), out int id))
        {
            Console.WriteLine("Invalid ID!");
            return;
        }

        Console.Write("New Name: ");
        string name = Console.ReadLine() ?? "";

        Console.Write("New Phone: ");
        string phone = Console.ReadLine() ?? "";

        Console.Write("New Email: ");
        string email = Console.ReadLine() ?? "";

        Console.Write("New Address: ");
        string address = Console.ReadLine() ?? "";

        string q = @"UPDATE patient 
                     SET patient_name=@n,
                         phone=@p,
                         email=@e,
                         address=@a
                     WHERE patient_id=@id";

        SqlCommand cmd = new SqlCommand(q, con);
        cmd.Parameters.AddWithValue("@n", name);
        cmd.Parameters.AddWithValue("@p", phone);
        cmd.Parameters.AddWithValue("@e", email);
        cmd.Parameters.AddWithValue("@a", address);
        cmd.Parameters.AddWithValue("@id", id);

        int rows = cmd.ExecuteNonQuery();

        if (rows == 0)
            Console.WriteLine(" Patient not found!");
        else
            Console.WriteLine(" Patient Updated!");
    }

    public void SearchPatient()
    {
        Console.Write("Enter Name: ");
        string name = Console.ReadLine() ?? "";

        using SqlConnection con = DBConnection.GetConnection();

        string q = "SELECT * FROM patient WHERE patient_name LIKE @n";
        SqlCommand cmd = new SqlCommand(q, con);
        cmd.Parameters.AddWithValue("@n", "%" + name + "%");

        SqlDataReader dr = cmd.ExecuteReader();

        Console.WriteLine("\n--- Patient List ---");
        while (dr.Read())
        {
            Console.WriteLine(
                $"ID:{dr["patient_id"]} | " +
                $"Name:{dr["patient_name"]} | " +
                $"Phone:{dr["phone"]} | " +
                $"Email:{dr["email"]} | " +
                $"Blood:{dr["blood_group"]}"
            );
        }
    }

    public void ViewVisitHistory(int patientId)
    {
        using SqlConnection con = DBConnection.GetConnection();

        string q = @"
        SELECT v.visit_date, v.diagnosis
        FROM visit v
        JOIN appointment a ON v.appointment_id=a.appointment_id
        WHERE a.patient_id=@id";

        SqlCommand cmd = new SqlCommand(q, con);
        cmd.Parameters.AddWithValue("@id", patientId);

        SqlDataReader dr = cmd.ExecuteReader();

        Console.WriteLine("\n--- Visit History ---");
        while (dr.Read())
            Console.WriteLine($"{dr["visit_date"]} - {dr["diagnosis"]}");
    }
}
