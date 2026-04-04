using System;
using System.IO;
using System.Linq;

class MergeCSV
{
    static void Main()
    {
        var file1 = File.ReadAllLines("students1.csv").Skip(1)
                    .ToDictionary(l => l.Split(',')[0]);

        var file2 = File.ReadAllLines("students2.csv").Skip(1);

        using StreamWriter sw = new StreamWriter("merged.csv");
        sw.WriteLine("ID,Name,Age,Marks,Grade");

        foreach (var line in file2)
        {
            var data = line.Split(',');

            // Merge by ID
            if (file1.ContainsKey(data[0]))
                sw.WriteLine(file1[data[0]] + "," + data[1] + "," + data[2]);
        }

        Console.WriteLine("CSV files merged.");
    }
}
