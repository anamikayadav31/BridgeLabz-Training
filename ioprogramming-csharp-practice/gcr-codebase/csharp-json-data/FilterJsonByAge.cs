using Newtonsoft.Json.Linq;
using System.IO;

class FilterJsonByAge
{
    static void Main()
    {
        var users = JArray.Parse(File.ReadAllText("users.json"));

        foreach (var u in users)
            if ((int)u["age"] > 25)
                System.Console.WriteLine(u["name"]);
    }
}
