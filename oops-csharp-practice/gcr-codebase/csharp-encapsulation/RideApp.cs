using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.oops.encapsulationAndPolymorphism
{


    // Interface for GPS functionality
    interface IGPSDevice
    {
        string GetLocation();
        void SetLocation(string newLocation);
    }

    // Abstract base class for vehicles
    abstract class Transport
    {
        // Encapsulated fields
        private int id;
        private string driver;
        private double pricePerKm;

        // Properties
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Driver
        {
            get { return driver; }
            set { driver = value; }
        }

        public double PricePerKm
        {
            get { return pricePerKm; }
            set { pricePerKm = value; }
        }

        // Abstract method to calculate fare
        public abstract double CalculateFare(double distance);

        // Concrete method to display vehicle details
        public void ShowDetails()
        {
            Console.WriteLine("Vehicle ID   : " + Id);
            Console.WriteLine("Driver Name  : " + Driver);
            Console.WriteLine("Rate per Km  : " + PricePerKm);
        }
    }

    // Car class
    class CarTransport : Transport, IGPSDevice
    {
        private string location;

        public override double CalculateFare(double distance)
        {
            return distance * PricePerKm;
        }

        public string GetLocation()
        {
            return location;
        }

        public void SetLocation(string newLocation)
        {
            location = newLocation;
        }
    }

    // Bike class
    class BikeTransport : Transport, IGPSDevice
    {
        private string location;

        public override double CalculateFare(double distance)
        {
            return (distance * PricePerKm) - 20; // bike discount
        }

        public string GetLocation()
        {
            return location;
        }

        public void SetLocation(string newLocation)
        {
            location = newLocation;
        }
    }

    // Auto class
    class AutoTransport : Transport, IGPSDevice
    {
        private string location;

        public override double CalculateFare(double distance)
        {
            return (distance * PricePerKm) + 30; // auto extra charge
        }

        public string GetLocation()
        {
            return location;
        }

        public void SetLocation(string newLocation)
        {
            location = newLocation;
        }
    }

    // Main program class
    internal class RideApp
    {
        public static void Main(string[] args)
        {
            Console.Write("Enter number of vehicles to register: ");
            int totalVehicles = int.Parse(Console.ReadLine());

            // Array of Transport reference for polymorphism
            Transport[] fleet = new Transport[totalVehicles];

            for (int i = 0; i < totalVehicles; i++)
            {
                Console.WriteLine("\nSelect vehicle type (1-Car, 2-Bike, 3-Auto): ");
                int type = int.Parse(Console.ReadLine());

                Transport transport;

                if (type == 1)
                    transport = new CarTransport();
                else if (type == 2)
                    transport = new BikeTransport();
                else
                    transport = new AutoTransport();

                Console.Write("Enter vehicle ID: ");
                transport.Id = int.Parse(Console.ReadLine());

                Console.Write("Enter driver name: ");
                transport.Driver = Console.ReadLine();

                Console.Write("Enter rate per km: ");
                transport.PricePerKm = double.Parse(Console.ReadLine());

                Console.Write("Enter current location: ");
                string currentLocation = Console.ReadLine();

                if (transport is IGPSDevice gps)
                {
                    gps.SetLocation(currentLocation);
                }

                fleet[i] = transport;
            }

            Console.Write("\nEnter travel distance in km: ");
            double distance = double.Parse(Console.ReadLine());

            Console.WriteLine("\n--- Ride Details and Fare ---\n");

            foreach (var vehicle in fleet)
            {
                vehicle.ShowDetails();
                Console.WriteLine("Fare Amount  : " + vehicle.CalculateFare(distance));

                if (vehicle is IGPSDevice gps)
                {
                    Console.WriteLine("Current Location : " + gps.GetLocation());
                }

                Console.WriteLine();
            }
        }
    }
}
