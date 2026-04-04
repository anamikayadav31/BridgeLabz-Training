using System;

// EmergencyService inherits from Services
public class EmergencyService : Services
{
    // Constructor passes title and ID to base class
    public EmergencyService(int serviceId, string serviceTitle)
        : base(serviceTitle, serviceId)
    {
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
