using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;

class ValidateEmailSchema
{
    static void Main()
    {
        string schemaJson = @"{
          'type':'object',
          'properties':{
            'email':{'type':'string','format':'email'}
          }
        }";

        JSchema schema = JSchema.Parse(schemaJson);
        JObject user = JObject.Parse("{ 'email':'test@mail.com' }");

        System.Console.WriteLine(user.IsValid(schema));
    }
}
