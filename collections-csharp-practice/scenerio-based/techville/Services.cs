using System;
using System.Collections.Generic;

// Base class for all city services
public class Services
{
    // STATIC CLASS VARIABLES
    protected static string cityTitle = "TechVille";   // Common city for all services
    protected static int totalServiceCount = 0;        // Count of all services created

    // COLLECTION to track all service instances
    private static List<Services> allServices = new List<Services>();

    // INSTANCE VARIABLES
    protected string serviceTitle;  // Name of this service
    protected int serviceId;        // Unique ID of this service
    protected int timesUsed;        // How many times this service has been used

    // CONSTRUCTOR 
    public Services(string serviceTitle, int serviceId)
    {
        this.serviceTitle = serviceTitle;
        this.serviceId = serviceId;
        this.timesUsed = 0;

        totalServiceCount++;         // Increment total service count
        allServices.Add(this);       // Add this service to collection
    }

    // VIRTUAL METHOD 
    public virtual void ProvideService()
    {
        timesUsed++; // Track usage
        Console.WriteLine($"Providing {serviceTitle} service in {cityTitle}");
    }

    // Display service info
    public void ShowServiceInfo()
    {
        Console.WriteLine($"Service: {serviceTitle}");
        Console.WriteLine($"Service ID: {serviceId}");
        Console.WriteLine($"Usage Count: {timesUsed}");
    }

    // Static method to show total services created
    public static void ShowTotalServices()
    {
        Console.WriteLine($"Total Services Created: {totalServiceCount}");
    }

    // Show all registered services
    public static void ShowAllServices()
    {
        Console.WriteLine("\n=== All Services ===");
        foreach (var service in allServices)
        {
            Console.WriteLine(service);
        }
    }

    // COMMON SERVICE OPERATIONS 
    public virtual void RegisterService()
    {
        Console.WriteLine($"{serviceTitle} registered.");
    }

    public virtual void CancelService()
    {
        Console.WriteLine($"{serviceTitle} cancelled.");
    }

    public virtual void CheckStatus()
    {
        Console.WriteLine($"{serviceTitle} status: Active");
    }

    // OBJECT CLASS OVERRIDES 
    public override string ToString()
    {
        return $"Service[{serviceId}] - {serviceTitle} | Times Used: {timesUsed}";
    }

    public override bool Equals(object obj)
    {
        if (obj is Services other)
        {
            return this.serviceId == other.serviceId;
        }
        return false;
    }

    public override int GetHashCode()
    {
        return serviceId.GetHashCode();
    }

    // Remove a service from collection
    public static bool RemoveService(int id)
    {
        var service = allServices.Find(s => s.serviceId == id);
        if (service != null)
        {
            allServices.Remove(service);
            Console.WriteLine($"Service ID {id} removed from collection.");
            return true;
        }
        return false;
    }

    // Get collection of all services
    public static List<Services> GetAllServices() => allServices;
}
