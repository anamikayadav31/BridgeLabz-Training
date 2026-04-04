using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

class DetectDuplicates
{
    static void Main()
    {
        HashSet<string> ids = new HashSet<string>();

        var lines = File.ReadAllLines("employees.csv").Skip(1);

        foreach (var line in lines)
        {
            var id = line.Split(',')[0];

            // Check duplicate ID
            if (!ids.Add(id))
                Console.WriteLine("Duplicate Record: " + line);
        }
    }
}
