using System;
using System.IO;
using System.Linq;

class SortCSV
{
    static void Main()
    {
        var records = File.ReadAllLines("employees.csv")
                          .Skip(1)
                          .Select(l => l.Split(','))
                          .OrderByDescending(d => double.Parse(d[3]))
                          .Take(5);

        Console.WriteLine("Top 5 highest paid employees:");

        foreach (var r in records)
            Console.WriteLine($"{r[1]} - {r[3]}");
    }
}
