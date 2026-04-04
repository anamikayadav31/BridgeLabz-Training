using System;

// HealthService class inherits from Services
public class HealthService : Services
{
    private string hospitalTitle; // Store hospital name

    // Constructor
    public HealthService(int serviceId, string hospitalTitleInput)
        : base("Healthcare", serviceId) // Call parent constructor
    {
        hospitalTitle = hospitalTitleInput; // Set hospital name
    }

    // Override parent method
    public override void ProvideService()
    {
        // Display healthcare service details
        Console.WriteLine(
            $"Healthcare service provided by {hospitalTitle} in {cityTitle}");
    }
}
