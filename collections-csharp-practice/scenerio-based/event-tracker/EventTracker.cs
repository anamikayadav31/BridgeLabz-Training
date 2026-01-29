using System;
using System.Reflection;
using System.Text.Json;

namespace EventTrackerApp;

public class EventTracker
{
    // This method finds all methods with [AuditTrail] and executes them
    public static void TrackEvents(object obj)
    {
        Type type = obj.GetType(); // Get the type of the object

        // Loop through all methods of the class
        foreach (MethodInfo method in type.GetMethods())
        {
            // Check if method has the AuditTrail attribute
            var attr = method.GetCustomAttribute<AuditTrailAttribute>();

            if (attr != null)
            {
                method.Invoke(obj, null); // Execute the method

                // Create a log entry for the action
                EventLog log = new EventLog
                {
                    Event = attr.EventName,
                    Description = attr.Description,
                    MethodName = method.Name,
                    ClassName = type.Name,
                    TimeStamp = DateTime.Now
                };

                // Convert log entry to formatted JSON
                string jsonLog = JsonSerializer.Serialize(log, new JsonSerializerOptions
                {
                    WriteIndented = true
                });

                // Display the audit log
                Console.WriteLine("\nAudit Log:");
                Console.WriteLine(jsonLog);
            }
        }
    }
}
