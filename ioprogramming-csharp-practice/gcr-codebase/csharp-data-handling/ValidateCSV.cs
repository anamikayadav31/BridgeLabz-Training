using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

class ValidateCSV
{
    static void Main()
    {
        Regex emailRegex = new Regex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$");
        Regex phoneRegex = new Regex(@"^\d{10}$");

        var lines = File.ReadAllLines("users.csv").Skip(1);

        foreach (var line in lines)
        {
            var data = line.Split(',');

            // Validate email & phone
            if (!emailRegex.IsMatch(data[2]) || !phoneRegex.IsMatch(data[3]))
                Console.WriteLine("Invalid Row: " + line);
        }
    }
}
