namespace EventTrackerApp;

public class EventLog
{
    public required string Event { get; set; }        // Name of the event (from AuditTrail)
    public required string Description { get; set; }  // Description of the event
    public required string MethodName { get; set; }   // Name of the method executed
    public required string ClassName { get; set; }    // Name of the class containing the method
    public DateTime TimeStamp { get; set; }          // Time when the event occurred
}
