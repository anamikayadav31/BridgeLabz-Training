using System;
using Microsoft.Data.SqlClient;

namespace HealthCareApp;

public class BillingUtility : IBillingService
{
    public void GenerateBill()
    {
        using SqlConnection con = DBConnection.GetConnection();

        Console.Write("Visit ID: ");
        int vid = int.Parse(Console.ReadLine());

        SqlCommand check = new SqlCommand(
            "SELECT COUNT(*) FROM visit WHERE visit_id=@id", con);
        check.Parameters.AddWithValue("@id", vid);

        if ((int)check.ExecuteScalar() == 0)
        {
            Console.WriteLine(" Visit not found!");
            return;
        }

        Console.Write("Amount: ");
        double amt = double.Parse(Console.ReadLine());

        SqlCommand cmd = new SqlCommand(
            "INSERT INTO bills(visit_id,total_amount,payment_status) VALUES(@v,@a,'UNPAID')", con);

        cmd.Parameters.AddWithValue("@v", vid);
        cmd.Parameters.AddWithValue("@a", amt);
        cmd.ExecuteNonQuery();

        Console.WriteLine(" Bill Generated!");
    }

    public void RecordPayment()
    {
        using SqlConnection con = DBConnection.GetConnection();

        Console.Write("Bill ID: ");
        int id = int.Parse(Console.ReadLine());

        SqlCommand cmd = new SqlCommand(
            "UPDATE bills SET payment_status='PAID' WHERE bill_id=@id", con);
        cmd.Parameters.AddWithValue("@id", id);

        cmd.ExecuteNonQuery();
        Console.WriteLine(" Payment Recorded!");
    }

    public void ViewOutstanding()
    {
        using SqlConnection con = DBConnection.GetConnection();

        SqlCommand cmd = new SqlCommand(
            "SELECT * FROM bills WHERE payment_status='UNPAID'", con);

        SqlDataReader dr = cmd.ExecuteReader();

        Console.WriteLine("\n--- Outstanding Bills ---");
        while (dr.Read())
            Console.WriteLine($"Bill:{dr["bill_id"]} | Visit:{dr["visit_id"]} | ₹{dr["total_amount"]}");
    }
}
