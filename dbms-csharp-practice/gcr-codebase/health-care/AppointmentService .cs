using System;
using Microsoft.Data.SqlClient;

namespace HealthCareApp;

public class AppointmentService : IAppointmentService
{
    public void Book()
    {
        using SqlConnection con = DBConnection.GetConnection();

        Console.Write("Patient ID: ");
        int pid = int.Parse(Console.ReadLine());

        SqlCommand checkPatient = new SqlCommand(
            "SELECT COUNT(*) FROM patient WHERE patient_id=@id", con);
        checkPatient.Parameters.AddWithValue("@id", pid);

        if ((int)checkPatient.ExecuteScalar() == 0)
        {
            Console.WriteLine(" Patient not found!");
            return;
        }

        Console.WriteLine("\nAvailable Doctors:");
        SqlCommand listDoc = new SqlCommand(
            "SELECT doctor_id,doctor_name FROM doctor WHERE is_active=1", con);

        SqlDataReader dr = listDoc.ExecuteReader();
        while (dr.Read())
            Console.WriteLine($"{dr["doctor_id"]} - {dr["doctor_name"]}");
        dr.Close();

        Console.Write("Doctor ID: ");
        int did = int.Parse(Console.ReadLine());

        SqlCommand cmd = new SqlCommand(
            "INSERT INTO appointment(patient_id,doctor_id,status) VALUES(@p,@d,'SCHEDULED')", con);

        cmd.Parameters.AddWithValue("@p", pid);
        cmd.Parameters.AddWithValue("@d", did);
        cmd.ExecuteNonQuery();

        Console.WriteLine(" Appointment Booked!");
    }

    public void Cancel()
    {
        using SqlConnection con = DBConnection.GetConnection();

        Console.Write("Appointment ID: ");
        int id = int.Parse(Console.ReadLine());

        SqlCommand cmd = new SqlCommand(
            "UPDATE appointment SET status='CANCELLED' WHERE appointment_id=@id", con);

        cmd.Parameters.AddWithValue("@id", id);
        cmd.ExecuteNonQuery();

        Console.WriteLine(" Appointment Cancelled.");
    }

    public void ViewDaily()
    {
        using SqlConnection con = DBConnection.GetConnection();

        SqlCommand cmd = new SqlCommand("SELECT * FROM appointment", con);
        SqlDataReader dr = cmd.ExecuteReader();

        Console.WriteLine("\n--- Appointments ---");
        while (dr.Read())
            Console.WriteLine($"ID:{dr["appointment_id"]} | Patient:{dr["patient_id"]} | Doctor:{dr["doctor_id"]} | {dr["status"]}");
    }

    //  Connects appointment → visit
    public void CompleteVisit()
    {
        using SqlConnection con = DBConnection.GetConnection();

        Console.Write("Appointment ID: ");
        int id = int.Parse(Console.ReadLine());

        Console.Write("Diagnosis: ");
        string diag = Console.ReadLine();

        SqlCommand update = new SqlCommand(
            "UPDATE appointment SET status='COMPLETED' WHERE appointment_id=@id", con);
        update.Parameters.AddWithValue("@id", id);
        update.ExecuteNonQuery();

        SqlCommand visit = new SqlCommand(
            "INSERT INTO visit(appointment_id,visit_date,diagnosis) VALUES(@a,GETDATE(),@d)", con);

        visit.Parameters.AddWithValue("@a", id);
        visit.Parameters.AddWithValue("@d", diag);
        visit.ExecuteNonQuery();

        Console.WriteLine(" Visit Completed!");
    }
}
