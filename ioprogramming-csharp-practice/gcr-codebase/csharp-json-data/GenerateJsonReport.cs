using Newtonsoft.Json;
using System;

class GenerateJsonReport
{
    static void Main()
    {
        var report = new
        {
            GeneratedOn = DateTime.Now,
            TotalUsers = 50
        };

        System.IO.File.WriteAllText("report.json",
            JsonConvert.SerializeObject(report, Formatting.Indented));
    }
}
