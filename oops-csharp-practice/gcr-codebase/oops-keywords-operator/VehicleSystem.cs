using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.oops.oopsKeywordsOperator
{
    internal class VehicleSystem
    {

        // Static variable: registration fee shared by all vehicles
        public static double RegistrationFee;

        // Read-only registration number: cannot be changed after creation
        public readonly string RegistrationNumber;

        // Vehicle details
        public string OwnerName;
        public string VehicleType;

        // Constructor to initialize vehicle details
        public VehicleSystem(string registrationNumber, string ownerName, string vehicleType)
        {
            this.RegistrationNumber = registrationNumber; // 'this' refers to current object
            this.OwnerName = ownerName;
            this.VehicleType = vehicleType;
        }

        // Static method to update registration fee
        public static void SetRegistrationFee(double fee)
        {
            RegistrationFee = fee;
        }

        // Method to display vehicle details
        public void ShowVehicleDetails()
        {
            Console.WriteLine("\nVehicle Details:");
            Console.WriteLine("Owner Name        : " + OwnerName);
            Console.WriteLine("Vehicle Type      : " + VehicleType);
            Console.WriteLine("Registration No   : " + RegistrationNumber);
            Console.WriteLine("Registration Fee  : " + RegistrationFee);
        }
    }

    class Program
    {
        public static void Main(string[] args)
        {
            // Ask user for registration fee
            Console.Write("Enter Registration Fee: ");
            double fee = double.Parse(Console.ReadLine());

            // Update static registration fee
            VehicleSystem.SetRegistrationFee(fee);

            Console.WriteLine();

            // Ask user for vehicle details
            Console.Write("Enter Registration Number: ");
            string regNumber = Console.ReadLine();

            Console.Write("Enter Owner Name: ");
            string owner = Console.ReadLine();

            Console.Write("Enter Vehicle Type: ");
            string type = Console.ReadLine();

            // Create a vehicle object
            VehicleSystem vehicle = new VehicleSystem(regNumber, owner, type);

            Console.WriteLine();

            // Check object type using 'is' keyword
            if (vehicle is VehicleSystem)
            {
                Console.WriteLine("Valid Vehicle Object");
                vehicle.ShowVehicleDetails();
            }
            else
            {
                Console.WriteLine("Invalid Object");
            }

            Console.ReadLine();
        }
    }
}