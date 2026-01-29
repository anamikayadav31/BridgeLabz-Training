using System;

// Custom exception for invalid flight details
public class InvalidFlightException : Exception
{
    public InvalidFlightException(string message) : base(message) { }
}
