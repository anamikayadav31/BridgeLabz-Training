using Newtonsoft.Json;
using System.Collections.Generic;

class ListToJsonArray
{
    static void Main()
    {
        var cars = new List<object>
        {
            new { Brand="Audi", Year=2022 },
            new { Brand="Tesla", Year=2024 }
        };

        string json = JsonConvert.SerializeObject(cars, Formatting.Indented);
        System.Console.WriteLine(json);
    }
}
