namespace NotifyHub;

using System.ComponentModel.DataAnnotations;

// Notification model class
public class Notification
{
    // Unique ID for notification
    [Required]
    public string NotificationId { get; set; } = string.Empty;

    // Receiver info (email/phone)
    [Required]
    public string Recipient { get; set; } = string.Empty;

    // Notification message text
    [Required]
    public string Message { get; set; } = string.Empty;

    // Priority level (1–3)
    [Range(1, 3)]
    public NotificationPriority Priority { get; set; }

    // Time when created
    public DateTime CreatedTime { get; set; } = DateTime.UtcNow;

    // Current status
    public NotificationStatus Status { get; set; } = NotificationStatus.Pending;

    // Type (Email/SMS/App)
    [Required]
    public string Type { get; set; } = string.Empty;
}
