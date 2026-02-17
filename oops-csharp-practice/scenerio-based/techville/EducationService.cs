using System;

// EducationService inherits from Services
public class EducationService : Services
{
    // Stores institute name
    private string instituteTitle;

    // Constructor to set service ID and institute name
    public EducationService(int serviceId, string instituteTitleInput)
        : base("Education", serviceId) // Call base constructor
    {
        instituteTitle = instituteTitleInput;
    }

    // Override to provide education service details
    public override void ProvideService()
    {
        Console.WriteLine(
            $"Education service offered by {instituteTitle} in {cityTitle}");
    }
}
