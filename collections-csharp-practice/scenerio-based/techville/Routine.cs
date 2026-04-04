
using System;
using System.Collections.Generic;

// Module-8
public class Routine : Services
{
    // Collection to store booked services
    private List<(string Date, string Time)> scheduledServices = new List<(string, string)>();

    public Routine(int serviceId, string serviceTitle)
        : base(serviceTitle, serviceId)
    {
    }

    // Override standard behavior
    public override void RegisterService()
    {
        Console.WriteLine($"Routine service '{serviceTitle}' scheduled normally.");
    }

    //  METHOD OVERLOADING WITH COLLECTIONS 

    // Version 1: Only date
    public void BookService(string serviceDate)
    {
        scheduledServices.Add((serviceDate, "Not Specified"));
        Console.WriteLine($"Service booked for date: {serviceDate}");
    }

    // Version 2: Date + time
    public void BookService(string serviceDate, string serviceTime)
    {
        scheduledServices.Add((serviceDate, serviceTime));
        Console.WriteLine($"Service booked for {serviceDate} at {serviceTime}");
    }

    // Display all scheduled services
    public void ShowAllScheduledServices()
    {
        Console.WriteLine($"\nAll Scheduled Services for '{serviceTitle}':");
        if (scheduledServices.Count == 0)
        {
            Console.WriteLine("No services scheduled yet.");
            return;
        }

        int count = 1;
        foreach (var service in scheduledServices)
        {
            Console.WriteLine($"{count}. Date: {service.Date}, Time: {service.Time}");
            count++;
        }
    }

    // Cancel a scheduled service by index
    public bool CancelService(int index)
    {
        if (index > 0 && index <= scheduledServices.Count)
        {
            var removed = scheduledServices[index - 1];
            scheduledServices.RemoveAt(index - 1);
            Console.WriteLine($"Cancelled service on {removed.Date} at {removed.Time}");
            return true;
        }
        Console.WriteLine("Invalid index. Cancellation failed.");
        return false;
    }

    // Get total number of scheduled services
    public int GetTotalScheduled() => scheduledServices.Count;
}
