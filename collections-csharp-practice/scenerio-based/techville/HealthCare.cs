using System;
using System.Collections.Generic; // Added for List

// HealthCare class inherits from HealthService
public class HealthCare : HealthService
{
    // Collection to manage various premium healthcare features
    private List<string> premiumFeatures = new List<string>();

    public HealthCare(int id, string hospital, string feature)
        : base(id, hospital) // Call parent class constructor
    {
        this.premiumFeatures.Add(feature); // Add initial feature to collection
    }

    public override void ProvideService()
    {
        base.ProvideService(); // Call parent method
        // Display all features stored in the List collection
        Console.WriteLine("Active Premium Features: " + string.Join(" | ", premiumFeatures));
    }
}