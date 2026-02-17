using System;

// Static class to handle service operations
public static class ServiceProcess
{
    // Polymorphism example: process booking using IBook interface
    public static void ProcessBooking(IBook bookableService)
    {
        bookableService.BookService("Lavanya"); // Call booking method
    }

    // Process cancellation using ICancel interface
    public static void ProcessCancellation(ICancel cancellableService)
    {
        cancellableService.CancelBooking(1); // Cancel booking with ID 1
    }

    // Process tracking using ITrack interface
    public static void ProcessTracking(ITrack trackableService)
    {
        trackableService.TrackStatus(1); // Track booking with ID 1
    }
}
