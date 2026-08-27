namespace FundooNotesApp.ModelLayer.Models;

// This is the tiny "envelope" we drop onto the RabbitMQ queue.
// The API only ever fills this in and publishes it - it never sends
// the actual email itself. Some separate consumer, listening on the
// same queue, is the one that turns this into a real SMTP email.
public class EmailQueueMessage
{
    public string ToEmail { get; set; } = string.Empty;
    public string Subject { get; set; } = string.Empty;
    public string Body { get; set; } = string.Empty;
}
