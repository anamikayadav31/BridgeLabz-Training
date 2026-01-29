// Utility class for flight validations and fuel calculation
public class FlightUtil
{
    // Validate flight number in "FL-XXXX" format
    public bool ValidateFlightNumber(string flightNumber)
    {
        if (System.Text.RegularExpressions.Regex.IsMatch(flightNumber, @"^FL-\d{4}$"))
        {
            int number = int.Parse(flightNumber.Substring(3));
            if (number >= 1000 && number <= 9999)
                return true;
        } 
        throw new InvalidFlightException($"The flight number {flightNumber} is invalid");
    }

    // Validate flight name (case-sensitive)
    public bool ValidateFlightName(string flightName)
    {
        if (flightName == "SpiceJet" || flightName == "Vistara" ||
            flightName == "IndiGo" || flightName == "Air Arabia")
            return true;

        throw new InvalidFlightException($"The flight name {flightName} is invalid");
    }

    // Validate passenger count for specific flight
    public bool ValidatePassengerCount(int passengerCount, string flightName)
    {
        int maxCapacity = flightName switch
        {
            "SpiceJet" => 396,
            "Vistara" => 615,
            "IndiGo" => 230,
            "Air Arabia" => 130,
            _ => 0
        };

        if (passengerCount > 0 && passengerCount <= maxCapacity)
            return true;

        throw new InvalidFlightException($"The passenger count {passengerCount} is invalid for {flightName}");
    }

    // Calculate fuel required to fill the tank
    public double CalculateFuelToFillTank(string flightName, double currentFuelLevel)
    {
        double maxFuel = flightName switch
        {
            "SpiceJet" => 200000,
            "Vistara" => 300000,
            "IndiGo" => 250000,
            "Air Arabia" => 150000,
            _ => 0
        };

        if (currentFuelLevel < 0 || currentFuelLevel > maxFuel)
            throw new InvalidFlightException($"Invalid fuel level for {flightName}");

        return maxFuel - currentFuelLevel;
    }
}
