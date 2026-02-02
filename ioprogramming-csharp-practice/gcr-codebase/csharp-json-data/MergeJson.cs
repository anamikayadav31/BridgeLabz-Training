using Newtonsoft.Json.Linq;

class MergeJson
{
    static void Main()
    {
        JObject obj1 = JObject.Parse("{ 'name':'Anamika' }");
        JObject obj2 = JObject.Parse("{ 'age':21 }");

        obj1.Merge(obj2);
        System.Console.WriteLine(obj1);
    }
}
