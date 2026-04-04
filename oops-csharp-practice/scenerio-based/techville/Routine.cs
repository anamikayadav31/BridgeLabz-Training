using System;
//Module-8
public class Routine : Services
{
    public Routine(int serviceId, string serviceTitle)
        : base(serviceTitle, serviceId)
    {
    }

    // Override standard behavior
    public override void RegisterService()
    {
        Console.WriteLine($"Routine service '{serviceTitle}' scheduled normally.");
    }

    // METHOD OVERLOADING

    // Version 1
    public void BookService(string serviceDate)
    {
        Console.WriteLine($"Service booked for date: {serviceDate}");
    }

    // Version 2 (overloaded)
    public void BookService(string serviceDate, string serviceTime)
    {
        Console.WriteLine($"Service booked for {serviceDate} at {serviceTime}");
    }
}
