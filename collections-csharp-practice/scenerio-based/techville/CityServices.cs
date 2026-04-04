using System;
using System.Collections.Generic;

public abstract class CityServices : Services, IBook, ICancel, ITrack
{
    // Encapsulation (data hiding)
    private int totalBookingCount = 0;

    // Collection to store bookings: Key = Booking ID, Value = Customer Name
    private Dictionary<int, string> bookings = new Dictionary<int, string>();

    public CityServices(string serviceTitle, int serviceId)
        : base(serviceTitle, serviceId)
    {
    }

    // Partial implementation of booking
    public virtual void BookService(string customerName)
    {
        totalBookingCount++;
        bookings.Add(totalBookingCount, customerName);

        Console.WriteLine(
            $"{customerName} booked {serviceTitle}. Booking ID: {totalBookingCount}");
    }

    // Abstract → must be implemented by child
    public abstract void CancelBooking(int bookingIdValue);

    public abstract void TrackStatus(int bookingIdValue);

    // Optional: Helper method to get all bookings
    public void ShowAllBookings()
    {
        Console.WriteLine($"\nAll bookings for {serviceTitle}:");
        foreach (var booking in bookings)
        {
            Console.WriteLine($"Booking ID: {booking.Key}, Customer: {booking.Value}");
        }
    }

    // Optional: Protected getter for derived classes
    protected Dictionary<int, string> GetBookings()
    {
        return bookings;
    }
}
