using System;

namespace EventTrackerApp;

// This attribute can be applied to methods to track user actions
[AttributeUsage(AttributeTargets.Method)]
public class AuditTrailAttribute : Attribute
{
    public string EventName { get; }    // Name of the event
    public string Description { get; }  // Description of the event

    // Constructor to set event name and description
    public AuditTrailAttribute(string eventName, string description)
    {
        EventName = eventName;
        Description = description;
    }
}
