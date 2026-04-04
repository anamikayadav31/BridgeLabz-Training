using System;
using System.Threading.Tasks;

namespace NotifyHub;

class Program
{
    // Entry point of program (async Main)
    static async Task Main()
    {
        // Create notification processor
        var processor = new NotificationProcessor();

        // Add high-priority email notification
        processor.Enqueue(new Notification
        {
            NotificationId = "N1",
            Recipient = "test@gmail.com",
            Message = "High Priority Email",
            Priority = NotificationPriority.High,
            Type = "Email"
        });

        // Add medium-priority SMS notification
        processor.Enqueue(new Notification
        {
            NotificationId = "N2",
            Recipient = "9999999999",
            Message = "SMS Notification",
            Priority = NotificationPriority.Medium,
            Type = "SMS"
        });

        // Process all notifications
        await processor.ProcessAsync();

        // Keep console open
        Console.ReadLine();
    }
}
