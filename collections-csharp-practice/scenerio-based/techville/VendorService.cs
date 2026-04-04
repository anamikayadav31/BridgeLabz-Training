using System;
using System.Collections.Generic;

// VendorService inherits from CityServices
public class VendorService : CityServices
{
    public VendorService(int serviceId, string serviceTitle)
        : base(serviceTitle, serviceId) // Call base constructor
    {
    }

    // Override cancellation using the base bookings dictionary
    public override void CancelBooking(int bookingIdValue)
    {
        var bookings = GetBookings();
        if (bookings.ContainsKey(bookingIdValue))
        {
            Console.WriteLine(
                $"Vendor cancelled booking #{bookingIdValue} for {bookings[bookingIdValue]}");
            bookings.Remove(bookingIdValue);
        }
        else
        {
            Console.WriteLine($"Booking ID {bookingIdValue} not found for VendorService.");
        }
    }

    // Override tracking using the base bookings dictionary
    public override void TrackStatus(int bookingIdValue)
    {
        var bookings = GetBookings();
        if (bookings.ContainsKey(bookingIdValue))
        {
            Console.WriteLine(
                $"Tracking VendorService booking #{bookingIdValue} for {bookings[bookingIdValue]}: In Progress");
        }
        else
        {
            Console.WriteLine($"Booking ID {bookingIdValue} not found for VendorService.");
        }
    }

    // Optional: show all vendor bookings
    public void ShowAllBookings()
    {
        var bookings = GetBookings();
        if (bookings.Count == 0)
        {
            Console.WriteLine("No VendorService bookings yet.");
            return;
        }

        Console.WriteLine($"\nAll VendorService bookings for {serviceTitle}:");
        foreach (var kvp in bookings)
        {
            Console.WriteLine($"Booking ID: {kvp.Key}, Customer: {kvp.Value}");
        }
    }
}
