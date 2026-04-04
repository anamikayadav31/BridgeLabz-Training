using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace BridgeLabzTraining.Collections.reflections
{


    class Configuration
    {
        private static string API_KEY = "OLD_KEY";
    }

    internal class AccessModifyStaticFields
    {


        public static void Main(string[] args)
        {
            // Get type information
            Type type = typeof(Configuration);

            // Access private static field
            FieldInfo field = type.GetField("API_KEY", BindingFlags.NonPublic | BindingFlags.Static);

            // Modify value 
            field.SetValue(null, "NEW_SECRET_KEY");

            // Retrieve updated value
            string value = (string)field.GetValue(null);

            Console.WriteLine("Updated API Key: " + value);
        }
    }

}