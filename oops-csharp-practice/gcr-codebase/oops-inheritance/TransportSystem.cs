using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.oops.inheritance
{
    internal class TransportSystem
    {

        // Common vehicle variables
        public int vehicleMaxSpeed;
        public string vehicleFuelType;

        // Constructor to initialize common values
        public TransportSystem(int vehicleMaxSpeed, string vehicleFuelType)
        {
            this.vehicleMaxSpeed = vehicleMaxSpeed;
            this.vehicleFuelType = vehicleFuelType;
        }

        // Method to display common vehicle details
        public virtual void DisplayInfo()
        {
            Console.WriteLine("Max Speed : " + vehicleMaxSpeed);
            Console.WriteLine("Fuel Type : " + vehicleFuelType);
        }
    }

    // Car class
    class Car : TransportSystem
    {
        // Car-specific variable
        public int carSeatCount;

        public Car(int vehicleMaxSpeed, string vehicleFuelType, int carSeatCount)
            : base(vehicleMaxSpeed, vehicleFuelType)
        {
            this.carSeatCount = carSeatCount;
        }

        // Override method
        public override void DisplayInfo()
        {
            Console.WriteLine("\nVehicle Type: Car");
            base.DisplayInfo();
            Console.WriteLine("Seat Capacity : " + carSeatCount);
        }
    }

    // Truck class
    class Truck : TransportSystem
    {
        // Truck-specific variable
        public int truckPayloadCapacity;

        public Truck(int vehicleMaxSpeed, string vehicleFuelType, int truckPayloadCapacity)
            : base(vehicleMaxSpeed, vehicleFuelType)
        {
            this.truckPayloadCapacity = truckPayloadCapacity;
        }

        public override void DisplayInfo()
        {
            Console.WriteLine("\nVehicle Type: Truck");
            base.DisplayInfo();
            Console.WriteLine("Payload Capacity : " + truckPayloadCapacity + " kg");
        }
    }

    // Motorcycle class
    class Motorcycle : TransportSystem
    {
        // Motorcycle-specific variable
        public bool motorcycleHasSidecar;

        public Motorcycle(int vehicleMaxSpeed, string vehicleFuelType, bool motorcycleHasSidecar)
            : base(vehicleMaxSpeed, vehicleFuelType)
        {
            this.motorcycleHasSidecar = motorcycleHasSidecar;
        }

        public override void DisplayInfo()
        {
            Console.WriteLine("\nVehicle Type: Motorcycle");
            base.DisplayInfo();
            Console.WriteLine("Has Sidecar : " + motorcycleHasSidecar);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Array of vehicles (polymorphism)
            TransportSystem[] vehicleList = new TransportSystem[3];

            // Input for Car
            Console.WriteLine("Enter Car Details (Max Speed, Fuel Type, Seat Count):");
            vehicleList[0] = new Car(
                int.Parse(Console.ReadLine()),   // max speed
                Console.ReadLine(),              // fuel type
                int.Parse(Console.ReadLine())    // seat count
            );

            // Input for Truck
            Console.WriteLine("\nEnter Truck Details (Max Speed, Fuel Type, Payload):");
            vehicleList[1] = new Truck(
                int.Parse(Console.ReadLine()),   // max speed
                Console.ReadLine(),              // fuel type
                int.Parse(Console.ReadLine())    // payload capacity
            );

            // Input for Motorcycle
            Console.WriteLine("\nEnter Motorcycle Details (Max Speed, Fuel Type, Sidecar true/false):");
            vehicleList[2] = new Motorcycle(
                int.Parse(Console.ReadLine()),   // max speed
                Console.ReadLine(),              // fuel type
                bool.Parse(Console.ReadLine())   // has sidecar
            );

            // Display all vehicle information
            Console.WriteLine("\nVehicle Information:");
            for (int i = 0; i < vehicleList.Length; i++)
            {
                vehicleList[i].DisplayInfo();
            }
        }
    }
}