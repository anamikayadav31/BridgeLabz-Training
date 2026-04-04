using System;
using System.Threading.Tasks;

namespace NotifyHub;

// Class to send app alerts
public class AppAlertSender : INotificationSender
{
    // Send app alert asynchronously
    public async Task SendAsync(Notification notification)
    {
        // Simulate sending delay
        await Task.Delay(200);

        // Show confirmation message
        Console.WriteLine($"App alert sent to {notification.Recipient}");
    }
}
