using System;
using System.IO;
using System.Linq;

class UpdateSalary
{
    static void Main()
    {
        var lines = File.ReadAllLines("employees.csv");

        using StreamWriter sw = new StreamWriter("updated_employees.csv");

        // Write header
        sw.WriteLine(lines[0]);

        foreach (var line in lines.Skip(1))
        {
            var data = line.Split(',');
            double salary = double.Parse(data[3]);

            // Increase IT salary
            if (data[2] == "IT")
                salary *= 1.10;

            sw.WriteLine($"{data[0]},{data[1]},{data[2]},{salary}");
        }

        Console.WriteLine("Updated CSV created.");
    }
}
