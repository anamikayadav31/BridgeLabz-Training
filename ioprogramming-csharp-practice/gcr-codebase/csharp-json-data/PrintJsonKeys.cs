using Newtonsoft.Json.Linq;
using System.IO;

class PrintJsonKeys
{
    static void Main()
    {
        JObject obj = JObject.Parse(File.ReadAllText("data.json"));

        foreach (var p in obj.Properties())
            System.Console.WriteLine($"{p.Name} : {p.Value}");
    }
}
