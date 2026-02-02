using Newtonsoft.Json;
using System;

class CreateStudentJson
{
    static void Main()
    {
        var student = new
        {
            name = "Anamika",
            age = 21,
            subjects = new[] { "Maths", "AI", "ML" }
        };

        string json = JsonConvert.SerializeObject(student, Formatting.Indented);
        Console.WriteLine(json);
    }
}
