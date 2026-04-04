using System;

// HealthCare class inherits from HealthService
public class HealthCare : HealthService
{
    private string premiumFeature; // Extra feature for premium service

    // Constructor
    public HealthCare(int id, string hospital, string feature)
        : base(id, hospital) // Call parent class constructor
    {
        this.premiumFeature = feature; // Store premium feature
    }

    // Override parent method
    public override void ProvideService()
    {
        base.ProvideService(); // Call parent method
        Console.WriteLine("Premium Feature: " + premiumFeature); // Show premium feature
    }
}
