using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using Newtonsoft.Json;

class JsonCsv
{
    static void Main()
    {
        // JSON → CSV
        var json = File.ReadAllText("students.json");
        var students = JsonConvert.DeserializeObject<List<Student>>(json);

        using StreamWriter sw = new StreamWriter("students.csv");
        sw.WriteLine("Id,Name,Marks");

        foreach (var s in students)
            sw.WriteLine($"{s.Id},{s.Name},{s.Marks}");

        // CSV → JSON
        var list = File.ReadAllLines("students.csv").Skip(1)
                   .Select(l => l.Split(','))
                   .Select(d => new Student { Id = int.Parse(d[0]), Name = d[1], Marks = int.Parse(d[2]) })
                   .ToList();

        File.WriteAllText("students_new.json", JsonConvert.SerializeObject(list, Formatting.Indented));
    }
}
