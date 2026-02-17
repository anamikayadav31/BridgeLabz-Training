using System;
using System.Threading.Tasks;

namespace NotifyHub;

// Class to send emails
public class EmailSender : INotificationSender
{
    // Send email asynchronously
    public async Task SendAsync(Notification notification)
    {
        // Simulate email sending delay
        await Task.Delay(500);

        // Show confirmation
        Console.WriteLine($"Email sent to {notification.Recipient}");
    }
}
