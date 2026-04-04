using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

class Student
{
    public int Id;
    public string Name;
    public int Marks;
}

class CSVToObject
{
    static void Main()
    {
        List<Student> students = new List<Student>();

        var lines = File.ReadAllLines("students.csv").Skip(1);

        foreach (var line in lines)
        {
            var d = line.Split(',');

            students.Add(new Student
            {
                Id = int.Parse(d[0]),
                Name = d[1],
                Marks = int.Parse(d[2])
            });
        }

        // Print students
        foreach (var s in students)
            Console.WriteLine($"{s.Id} {s.Name} {s.Marks}");
    }
}
