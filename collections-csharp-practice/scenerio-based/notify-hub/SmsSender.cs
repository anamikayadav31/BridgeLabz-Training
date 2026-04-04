using System;
using System.Threading.Tasks;

namespace NotifyHub;

// Class to send SMS notifications
public class SmsSender : INotificationSender
{
    // Send SMS asynchronously
    public async Task SendAsync(Notification notification)
    {
        // Wait to simulate sending time
        await Task.Delay(300);

        // Show message in console
        Console.WriteLine($"SMS sent to {notification.Recipient}");
    }
}
