using System;
using System.IO;
using System.Linq;

class FilterCSV
{
    static void Main()
    {
        // Read CSV excluding header
        var lines = File.ReadAllLines("students.csv").Skip(1);

        Console.WriteLine("Students scoring more than 80:");

        foreach (var line in lines)
        {
            var data = line.Split(',');

            // Check marks
            if (int.Parse(data[2]) > 80)
                Console.WriteLine(line);
        }
    }
}
