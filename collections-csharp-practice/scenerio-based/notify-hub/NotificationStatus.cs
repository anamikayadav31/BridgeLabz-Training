namespace NotifyHub;

// Status of a notification
public enum NotificationStatus
{
    Pending, // Not sent yet
    Sent,    // Successfully sent
    Failed   // Sending failed
}
