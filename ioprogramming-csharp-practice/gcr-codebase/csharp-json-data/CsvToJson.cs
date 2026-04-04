using Newtonsoft.Json;
using System.IO;
using System.Linq;

class CsvToJson
{
    static void Main()
    {
        var lines = File.ReadAllLines("users.csv").Skip(1);
        var list = lines.Select(l =>
        {
            var p = l.Split(',');
            return new { Name = p[0], Age = p[1] };
        });

        File.WriteAllText("users.json",
            JsonConvert.SerializeObject(list, Formatting.Indented));
    }
}
