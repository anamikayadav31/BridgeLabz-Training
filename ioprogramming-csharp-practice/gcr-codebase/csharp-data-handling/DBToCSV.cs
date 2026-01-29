using System;
using System.IO;
using System.Data.SqlClient;

class DBToCSV
{
    static void Main()
    {
        SqlConnection con = new SqlConnection("your_connection_string");
        SqlCommand cmd = new SqlCommand("SELECT * FROM Employees", con);

        con.Open();

        using StreamWriter sw = new StreamWriter("db_employees.csv");
        sw.WriteLine("ID,Name,Department,Salary");

        SqlDataReader dr = cmd.ExecuteReader();

        while (dr.Read())
            sw.WriteLine($"{dr[0]},{dr[1]},{dr[2]},{dr[3]}");

        con.Close();
        Console.WriteLine("CSV generated from database.");
    }
}
