using System;
using System.Collections.Generic; // Added for Queue collection

// EmergencyService inherits from Services
public class EmergencyService : Services
{
    // Collection to store pending emergency dispatch locations in order
    private Queue<string> dispatchQueue = new Queue<string>();

    // Constructor passes title and ID to base class
    public EmergencyService(int serviceId, string serviceTitle)
        : base(serviceTitle, serviceId)
    {
    }

    // Adds a new location to the emergency response queue
    public void AddEmergencyCall(string location)
    {
        dispatchQueue.Enqueue(location);
        Console.WriteLine($"Emergency call queued for: {location}");
    }

    // Override: emergency services start immediately
    public override void RegisterService()
    {
        Console.WriteLine(
            $"Emergency service '{serviceTitle}' activated immediately!");
    }

    // Override: cannot cancel emergency services
    public override void CancelService()
    {
        Console.WriteLine(
            "Emergency services cannot be cancelled once dispatched.");
    }
}