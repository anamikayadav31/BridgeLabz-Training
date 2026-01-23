using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.Collections.exceptions
{
    internal class InterestCalculation
    {
    

        // Method to calculate interest
        static double CalculateInterest(double amount, double rate, int years)
        {
            if (amount < 0 || rate < 0)
            {
                // Throw exception for invalid input
                throw new ArgumentException();
            }

            return (amount * rate * years) / 100;
        }

        static void Main()
        {
            try
            {
                // Take inputs
                Console.Write("Enter amount: ");
                double amount = double.Parse(Console.ReadLine());

                Console.Write("Enter rate: ");
                double rate = double.Parse(Console.ReadLine());

                Console.Write("Enter years: ");
                int years = int.Parse(Console.ReadLine());

                // Call method
                double interest = CalculateInterest(amount, rate, years);
                Console.WriteLine("Interest: " + interest);
            }
            catch (ArgumentException)
            {
                // Handle invalid input
                Console.WriteLine("Invalid input: Amount and rate must be positive");
            }
        }
    }
}
