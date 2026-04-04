using System.Threading.Tasks;

namespace NotifyHub;

// Interface for sending notifications
public interface INotificationSender
{
    // Method to send a notification asynchronously
    Task SendAsync(Notification notification);
}
