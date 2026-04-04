using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.oops.encapsulationAndPolymorphism
{


    // Interface for insurance functionality
    interface IInsurance
    {
        double GetInsuranceAmount();
        string GetPolicyInfo();
    }

    // Abstract base class for all rental vehicles
    abstract class RentalVehicle
    {
        // Encapsulated fields
        private string regNumber;
        private string model;
        private double dailyRate;

        // Properties for encapsulation
        public string RegNumber
        {
            get { return regNumber; }
            set { regNumber = value; }
        }

        public string Model
        {
            get { return model; }
            set { model = value; }
        }

        public double DailyRate
        {
            get { return dailyRate; }
            set { dailyRate = value; }
        }

        // Abstract method to calculate rental cost
        public abstract double CalculateRental(int days);

        // Concrete method to display vehicle details
        public void ShowDetails()
        {
            Console.WriteLine("Registration Number : " + RegNumber);
            Console.WriteLine("Vehicle Model       : " + Model);
        }
    }

    // Car class
    class CarVehicle : RentalVehicle, IInsurance
    {
        private string policyNumber;

        public void SetPolicy(string policy)
        {
            policyNumber = policy;
        }

        public override double CalculateRental(int days)
        {
            return DailyRate * days;
        }

        public double GetInsuranceAmount()
        {
            return 500;
        }

        public string GetPolicyInfo()
        {
            return "Car insurance policy: " + policyNumber;
        }
    }

    // Bike class
    class BikeVehicle : RentalVehicle, IInsurance
    {
        private string policyNumber;

        public void SetPolicy(string policy)
        {
            policyNumber = policy;
        }

        public override double CalculateRental(int days)
        {
            return (DailyRate * days) - 100; // discount for bike
        }

        public double GetInsuranceAmount()
        {
            return 200;
        }

        public string GetPolicyInfo()
        {
            return "Bike insurance policy: " + policyNumber;
        }
    }

    // Truck class
    class TruckVehicle : RentalVehicle, IInsurance
    {
        private string policyNumber;

        public void SetPolicy(string policy)
        {
            policyNumber = policy;
        }

        public override double CalculateRental(int days)
        {
            return (DailyRate * days) + 1000; // extra charge for truck
        }

        public double GetInsuranceAmount()
        {
            return 1200;
        }

        public string GetPolicyInfo()
        {
            return "Truck insurance policy: " + policyNumber;
        }
    }

    // Main program class
    internal class VehicleRentalApp
    {
        public static void Main(string[] args)
        {
            Console.Write("How many vehicles do you want to add? ");
            int totalVehicles = int.Parse(Console.ReadLine());

            // Array of RentalVehicle references (polymorphism)
            RentalVehicle[] fleet = new RentalVehicle[totalVehicles];

            for (int i = 0; i < totalVehicles; i++)
            {
                Console.WriteLine("\nSelect vehicle type (1-Car, 2-Bike, 3-Truck): ");
                int type = int.Parse(Console.ReadLine());

                RentalVehicle vehicle;

                if (type == 1)
                    vehicle = new CarVehicle();
                else if (type == 2)
                    vehicle = new BikeVehicle();
                else
                    vehicle = new TruckVehicle();

                Console.Write("Enter registration number: ");
                vehicle.RegNumber = Console.ReadLine();

                Console.Write("Enter vehicle model: ");
                vehicle.Model = Console.ReadLine();

                Console.Write("Enter rental rate per day: ");
                vehicle.DailyRate = double.Parse(Console.ReadLine());

                Console.Write("Enter insurance policy number: ");
                string policy = Console.ReadLine();

                // Set policy number based on vehicle type
                if (vehicle is CarVehicle car)
                    car.SetPolicy(policy);
                else if (vehicle is BikeVehicle bike)
                    bike.SetPolicy(policy);
                else if (vehicle is TruckVehicle truck)
                    truck.SetPolicy(policy);

                fleet[i] = vehicle;
            }

            Console.Write("\nEnter number of rental days: ");
            int days = int.Parse(Console.ReadLine());

            Console.WriteLine("\n--- Vehicle Rental Details ---\n");

            foreach (var vehicle in fleet)
            {
                vehicle.ShowDetails();
                Console.WriteLine("Rental Cost      : " + vehicle.CalculateRental(days));

                if (vehicle is IInsurance ins)
                {
                    Console.WriteLine("Insurance Amount : " + ins.GetInsuranceAmount());
                    Console.WriteLine(ins.GetPolicyInfo());
                }

                Console.WriteLine();
            }
        }
    }
}