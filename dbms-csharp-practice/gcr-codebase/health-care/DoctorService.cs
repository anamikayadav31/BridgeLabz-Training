using System;
using Microsoft.Data.SqlClient;

namespace HealthCareApp;

public class DoctorService : IDoctorService
{
    public void AddDoctor()
    {
        using SqlConnection con = DBConnection.GetConnection();

        Console.Write("Doctor Name: ");
        string name = Console.ReadLine() ?? "";

        Console.Write("Contact: ");
        string contact = Console.ReadLine() ?? "";

        Console.Write("Fee: ");
        decimal fee = decimal.Parse(Console.ReadLine() ?? "0");

        Console.Write("Specialist ID: ");
        int specId = int.Parse(Console.ReadLine() ?? "0");

        string q = @"INSERT INTO doctor
                     (doctor_name,contact,consultation_fee,specialist_id)
                     VALUES (@n,@c,@f,@s)";

        SqlCommand cmd = new SqlCommand(q, con);
        cmd.Parameters.AddWithValue("@n", name);
        cmd.Parameters.AddWithValue("@c", contact);
        cmd.Parameters.AddWithValue("@f", fee);
        cmd.Parameters.AddWithValue("@s", specId);

        cmd.ExecuteNonQuery();

        Console.WriteLine(" Doctor Added!");
    }

    public void ViewBySpecialty()
    {
        using SqlConnection con = DBConnection.GetConnection();

        string q = @"SELECT doctor_id,doctor_name,consultation_fee
                     FROM doctor WHERE is_active=1";

        SqlCommand cmd = new SqlCommand(q, con);
        SqlDataReader dr = cmd.ExecuteReader();

        Console.WriteLine("\n--- Doctors List ---");

        while (dr.Read())
        {
            Console.WriteLine(
                $"ID:{dr["doctor_id"]} | " +
                $"{dr["doctor_name"]} | " +
                $"₹{dr["consultation_fee"]}"
            );
        }
    }

    public void DeactivateDoctor()
    {
        Console.Write("Doctor ID: ");
        int id = int.Parse(Console.ReadLine() ?? "0");

        using SqlConnection con = DBConnection.GetConnection();

        SqlCommand cmd = new SqlCommand(
            "UPDATE doctor SET is_active=0 WHERE doctor_id=@id", con);

        cmd.Parameters.AddWithValue("@id", id);
        cmd.ExecuteNonQuery();

        Console.WriteLine(" Doctor Deactivated!");
    }
}
