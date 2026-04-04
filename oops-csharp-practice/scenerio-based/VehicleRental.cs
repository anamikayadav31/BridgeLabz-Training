using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.oops.sceneriobased
{


    // Interface for rentable vehicles
    interface IRentable
    {
        double CalculateRent(int days);
    }

    // Base Vehicle class
    class Vehicle
    {
        protected string VehicleName;
        protected string VehicleNumber;
        protected double BaseRatePerDay;

        public Vehicle(string name, string number, double ratePerDay)
        {
            VehicleName = name;
            VehicleNumber = number;
            BaseRatePerDay = ratePerDay;
        }

        public virtual void ShowDetails()
        {
            Console.WriteLine($"Vehicle: {VehicleName}, Number: {VehicleNumber}, Rate per Day: {BaseRatePerDay}");
        }
    }

    // Bike class
    class Bike : Vehicle, IRentable
    {
        public Bike(string name, string number, double ratePerDay)
            : base(name, number, ratePerDay) { }

        public double CalculateRent(int days)
        {
            return BaseRatePerDay * days;
        }
    }

    // Car class
    class Car : Vehicle, IRentable
    {
        public Car(string name, string number, double ratePerDay)
            : base(name, number, ratePerDay) { }

        public double CalculateRent(int days)
        {
            return BaseRatePerDay * days;
        }
    }

    // Truck class
    class Truck : Vehicle, IRentable
    {
        public Truck(string name, string number, double ratePerDay)
            : base(name, number, ratePerDay) { }

        public double CalculateRent(int days)
        {
            // Trucks have an additional surcharge of 10%
            return BaseRatePerDay * days * 1.10;
        }
    }

    // Customer class
    class Customer
    {
        public string CustomerName;
        public string CustomerId;

        public Customer(string name, string id)
        {
            CustomerName = name;
            CustomerId = id;
        }

        public void ShowCustomerInfo()
        {
            Console.WriteLine($"\nCustomer: {CustomerName}, ID: {CustomerId}");
        }
    }

    // Main class renamed to VehicleRental
    class VehicleRental
    {
        static void Main(string[] args)
        {
            // Get customer info
            Console.Write("Enter Customer Name: ");
            string custName = Console.ReadLine();

            Console.Write("Enter Customer ID: ");
            string custId = Console.ReadLine();

            Customer customer = new Customer(custName, custId);
            customer.ShowCustomerInfo();

            // Vehicle selection menu
            Console.WriteLine("\nSelect Vehicle Type to Rent:");
            Console.WriteLine("1. Bike ($50/day)");
            Console.WriteLine("2. Car ($100/day)");
            Console.WriteLine("3. Truck ($200/day)");

            Console.Write("Enter choice (1-3): ");
            int choice = int.Parse(Console.ReadLine());

            Console.Write("Enter Vehicle Name: ");
            string vehicleName = Console.ReadLine();

            Console.Write("Enter Vehicle Number: ");
            string vehicleNumber = Console.ReadLine();

            IRentable rentedVehicle = null;
            Vehicle vehicleDetails = null;

            switch (choice)
            {
                case 1:
                    rentedVehicle = new Bike(vehicleName, vehicleNumber, 50);
                    vehicleDetails = (Vehicle)rentedVehicle;
                    break;
                case 2:
                    rentedVehicle = new Car(vehicleName, vehicleNumber, 100);
                    vehicleDetails = (Vehicle)rentedVehicle;
                    break;
                case 3:
                    rentedVehicle = new Truck(vehicleName, vehicleNumber, 200);
                    vehicleDetails = (Vehicle)rentedVehicle;
                    break;
                default:
                    Console.WriteLine("Invalid choice. Exiting.");
                    return;
            }

            vehicleDetails.ShowDetails();

            // Rent days
            Console.Write("Enter number of rental days: ");
            int days = int.Parse(Console.ReadLine());

            double totalRent = rentedVehicle.CalculateRent(days);
            Console.WriteLine($"\nTotal Rent for {days} days: ${totalRent:F2}");

            Console.WriteLine("\nThank you for using Vehicle Rental App!");
            Console.ReadLine();
        }
    }

}