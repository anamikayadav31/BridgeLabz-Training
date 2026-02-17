using System;
using System.Collections.Concurrent;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace NotifyHub;

public class NotificationProcessor
{
    // Priority queue to store notifications
    private readonly PriorityQueue<Notification, int> _queue =
        new PriorityQueue<Notification, int>();

    // Lock for thread safety
    private readonly object _lock = new object();

    // Add notification to queue
    public void Enqueue(Notification notification)
    {
        Validate(notification); // check data

        lock (_lock)
        {
            _queue.Enqueue(notification, (int)notification.Priority);
        }
    }

    // Process all notifications
    public async Task ProcessAsync()
    {
        while (_queue.Count > 0)
        {
            Notification notification;

            lock (_lock)
            {
                notification = _queue.Dequeue();
            }

            // Run handler in background
            _ = Task.Run(() => HandleNotificationAsync(notification));
        }
    }

    // Handle sending notification
    private async Task HandleNotificationAsync(Notification notification)
    {
        try
        {
            INotificationSender sender = GetSender(notification.Type);

            await sender.SendAsync(notification);

            notification.Status = NotificationStatus.Sent;
        }
        catch (Exception ex)
        {
            notification.Status = NotificationStatus.Failed;
            Console.WriteLine($"Failed: {ex.Message}");
        }
    }

    // Choose sender by type
    private INotificationSender GetSender(string type)
    {
        return type switch
        {
            "Email" => new EmailSender(),
            "SMS" => new SmsSender(),
            "App" => new AppAlertSender(),
            _ => throw new Exception("Invalid type")
        };
    }

    // Validate notification fields
    private void Validate(Notification notification)
    {
        var context = new ValidationContext(notification);
        Validator.ValidateObject(notification, context, true);
    }
}
