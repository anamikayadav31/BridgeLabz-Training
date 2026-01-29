// See https://aka.ms/new-console-template for more information
using System;

class Program
{
    static void Main()
    {
        FlightUtil flightUtil = new FlightUtil();

        Console.WriteLine("Enter flight details");
        string input = Console.ReadLine();

        try
        {
            // Split input into flight details
            string[] details = input.Split(':');
            if (details.Length != 4)
                throw new InvalidFlightException("Invalid input format");

            string flightNumber = details[0];
            string flightName = details[1];
            int passengerCount = int.Parse(details[2]);
            double currentFuelLevel = double.Parse(details[3]);

            Flight flight = new Flight(flightNumber, flightName, passengerCount, currentFuelLevel);

            // Perform validations
            flightUtil.ValidateFlightNumber(flight.FlightNumber);
            flightUtil.ValidateFlightName(flight.FlightName);
            flightUtil.ValidatePassengerCount(flight.PassengerCount, flight.FlightName);

            // Calculate fuel required
            double fuelNeeded = flightUtil.CalculateFuelToFillTank(flight.FlightName, flight.CurrentFuelLevel);
            Console.WriteLine($"Fuel required to fill the tank: {fuelNeeded} liters");
        }
        catch (InvalidFlightException e)
        {
            Console.WriteLine(e.Message);
        }
        catch (FormatException)
        {
            Console.WriteLine("Passenger count and fuel level must be numeric");
        }
    }
}


