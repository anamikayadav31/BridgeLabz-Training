// See https://aka.ms/new-console-template for more information


using System;



namespace  HealthCheckPro
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Health Check API Demo\n");

            // Call methods
            ApiMethods.PublicEndpoint();
            ApiMethods.SecureEndpoint("Admin");
            ApiMethods.SecureEndpoint("User");

            Console.ReadLine();
        }
    }

    public static class ApiMethods
    {
        // Public API method
        [PublicAPI("This endpoint is open to everyone.")]
        public static void PublicEndpoint()
        {
            Console.WriteLine("Accessing Public Endpoint: Everyone can see this.");
        }

        // Requires authentication
        [RequiresAuth("Admin")]
        public static void SecureEndpoint(string userRole)
        {
            // Get the RequiresAuth attribute of this method
            var method = typeof(ApiMethods).GetMethod(nameof(SecureEndpoint));

            if (method != null)
            {
                var authAttr = Attribute.GetCustomAttribute(method, typeof(RequiresAuthAttribute)) as RequiresAuthAttribute;
                if (authAttr != null && authAttr.Role == userRole)
                {
                    Console.WriteLine($"Access granted to {userRole} for Secure Endpoint.");
                }
                else
                {
                    Console.WriteLine($"Access denied for {userRole} to Secure Endpoint.");
                }
            }
            else
            {
                Console.WriteLine("Method not found!");
            }
        }
    }
}