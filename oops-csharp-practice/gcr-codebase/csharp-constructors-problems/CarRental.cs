using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.oops.constructor
{
    internal class CarRental
    {


        public string CustomerName;
        public string CarModel;
        public int RentalDays;

        private double CostPerDay = 1200; // fixed cost per day

        // Constructor
        public CarRental(string customerName, string carModel, int rentalDays)
        {
            CustomerName = customerName;
            CarModel = carModel;
            RentalDays = rentalDays;
        }

        // Method to calculate total rental cost
        public double CalculateTotalCost()
        {
            return RentalDays * CostPerDay;
        }

        public static void Main(string[] args)
        {
            // Taking user input
            Console.Write("Enter Customer Name: ");
            string name = Console.ReadLine();

            Console.Write("Enter Car Model: ");
            string car = Console.ReadLine();

            Console.Write("Enter Number of Rental Days: ");
            int days = Convert.ToInt32(Console.ReadLine());

            // Create CarRental object
            CarRental rental = new CarRental(name, car, days);

            // Display rental details
            Console.WriteLine("\n--- Rental Details ---");
            Console.WriteLine("Customer: " + rental.CustomerName);
            Console.WriteLine("Car: " + rental.CarModel);
            Console.WriteLine("Days: " + rental.RentalDays);
            Console.WriteLine("Total Cost: " + rental.CalculateTotalCost());
        }
    }
}