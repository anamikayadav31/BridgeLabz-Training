using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.oops.constructor
{
    internal class VehicleReg

    {



        // Instance variables
        public string Owner;      // Name of the vehicle owner
        public string Type;       // Type of vehicle 

        // Class variable (shared by all vehicles)
        public static double Fee = 5000; // Default registration fee

        // Constructor to initialize a vehicle
        public VehicleReg(string ownerName, string vehicleType)
        {
            Owner = ownerName;
            Type = vehicleType;
        }

        // Instance method to display vehicle details
        public void ShowDetails()
        {
            Console.WriteLine("Owner: " + Owner);
            Console.WriteLine("Vehicle Type: " + Type);
            Console.WriteLine("Registration Fee: " + Fee);
          
        }

        // Static method to update registration fee for all vehicles
        public static void ChangeFee(double newFee)
        {
            Fee = newFee;
        }

        // Main method
        public static void Main(string[] args)
        {
            Console.Write("How many vehicles do you want to register? ");
            int count = Convert.ToInt32(Console.ReadLine());

            VehicleReg[] vehicles = new VehicleReg[count]; // Fixed class name

            // Input vehicle details from the user
            for (int i = 0; i < count; i++)
            {
                Console.WriteLine($"\nEnter details for vehicle {i + 1}:");

                Console.Write("Owner Name: ");
                string owner = Console.ReadLine();

                Console.Write("Vehicle Type (Car/Bike/etc.): ");
                string type = Console.ReadLine();

                vehicles[i] = new VehicleReg(owner, type); // Fixed class name
            }

            Console.WriteLine("\n--- Vehicle Details ---");
            foreach (VehicleReg v in vehicles)
            {
                v.ShowDetails();
            }

            // Optionally update registration fee
            Console.Write("Do you want to update the registration fee? (yes/no): ");
            string choice = Console.ReadLine().ToLower();

            if (choice == "yes")
            {
                Console.Write("Enter new registration fee: ");
                double newFee = Convert.ToDouble(Console.ReadLine());
                VehicleReg.ChangeFee(newFee);

                Console.WriteLine("\n--- Updated Vehicle Details ---");
                foreach (VehicleReg v in vehicles)
                {
                    v.ShowDetails();
                }
            }

            Console.WriteLine("Program finished.");
        }
    }
}