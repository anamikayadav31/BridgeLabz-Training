using System;

// VendorService class inherits from CityServices
public class VendorService : CityServices
{
    // Constructor to initialize service
    public VendorService(int serviceId, string serviceTitle)
        : base(serviceTitle, serviceId) // Call base class constructor
    {
    }

    // Override cancellation method
    public override void CancelBooking(int bookingIdValue)
    {
        Console.WriteLine(
            $"Vendor cancelled booking #{bookingIdValue}"); // Show cancellation info
    }

    // Override tracking method
    public override void TrackStatus(int bookingIdValue)
    {
        Console.WriteLine(
            $"Tracking vendor service booking #{bookingIdValue}: In Progress"); // Show status
    }
}
