using System;

public abstract class CityServices : Services,
    IBook, ICancel, ITrack
{
    // Encapsulation (data hiding)
    private int totalBookingCount = 0;

    public CityServices(string serviceTitle, int serviceId)
        : base(serviceTitle, serviceId)
    {
    }

    // Partial implementation
    public virtual void BookService(string customerName)
    {
        totalBookingCount++;

        Console.WriteLine(
            $"{customerName} booked {serviceTitle}. Booking ID: {totalBookingCount}");
    }

    // Abstract → must be implemented by child
    public abstract void CancelBooking(int bookingIdValue);

    public abstract void TrackStatus(int bookingIdValue);
}
