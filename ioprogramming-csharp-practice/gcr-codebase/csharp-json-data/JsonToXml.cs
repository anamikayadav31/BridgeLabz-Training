using Newtonsoft.Json;
using System.IO;

class JsonToXml
{
    static void Main()
    {
        string json = File.ReadAllText("students.json");
        var xml = JsonConvert.DeserializeXNode(json, "Root");
        xml.Save("students.xml");
    }
}
