using System;
using System.IO;
using System.Linq;

class SearchEmployee
{
    static void Main()
    {
        Console.Write("Enter employee name: ");
        string name = Console.ReadLine();

        var lines = File.ReadAllLines("employees.csv").Skip(1);

        foreach (var line in lines)
        {
            var data = line.Split(',');

            // Match name
            if (data[1].Equals(name, StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine("Department: " + data[2]);
                Console.WriteLine("Salary: " + data[3]);
            }
        }
    }
}
