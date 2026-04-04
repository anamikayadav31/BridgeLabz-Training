using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.Collections.exceptions
{
  

   


// Custom exception class
class InvalidAgeException : Exception
    {
        public InvalidAgeException(string message) : base(message)
        {
        }
    }

    internal class HandlingCustom
    {
        // Method to validate age
        static void ValidateAge(int age)
        {
            if (age < 18)
            {
                // Throw custom exception
                throw new InvalidAgeException("Age must be 18 or above");
            }
        }

        static void Main()
        {
            try
            {
                // Take age input
                Console.Write("Enter your age: ");
                int age = int.Parse(Console.ReadLine());

                // Validate age
                ValidateAge(age);

                // If no exception
                Console.WriteLine("Access granted!");
            }
            catch (InvalidAgeException)
            {
                // Handle custom exception
                Console.WriteLine("Age must be 18 or above");
            }
            catch (FormatException)
            {
                // Handle invalid input
                Console.WriteLine("Please enter a valid number");
            }
        }
    }
}
