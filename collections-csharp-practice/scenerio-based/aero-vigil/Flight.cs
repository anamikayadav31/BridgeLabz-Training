// Model class to store flight details
public class Flight
{
    public string FlightNumber { get; }
    public string FlightName { get; }
    public int PassengerCount { get; }
    public double CurrentFuelLevel { get; }

    public Flight(string flightNumber, string flightName, int passengerCount, double currentFuelLevel)
    {
        FlightNumber = flightNumber;
        FlightName = flightName;
        PassengerCount = passengerCount;
        CurrentFuelLevel = currentFuelLevel;
    }
}
