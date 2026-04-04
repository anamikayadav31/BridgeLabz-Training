using Newtonsoft.Json.Linq;
using System.IO;
using System;

class ReadJsonFields
{
    static void Main()
    {
        string json = File.ReadAllText("users.json");
        JArray users = JArray.Parse(json);

        foreach (var u in users)
        {
            Console.WriteLine(u["name"]);
            Console.WriteLine(u["email"]);
        }
    }
}
