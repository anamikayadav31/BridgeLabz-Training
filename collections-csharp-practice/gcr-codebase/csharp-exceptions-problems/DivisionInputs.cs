using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.Collections.exceptions
{
    internal class DivisionInputs
    {
   

        static void Main()
        {
            try
            {
                // Take first number
                Console.Write("Enter first number: ");
                int num1 = int.Parse(Console.ReadLine());

                // Take second number
                Console.Write("Enter second number: ");
                int num2 = int.Parse(Console.ReadLine());

                // Perform division
                int result = num1 / num2;

                // Print result
                Console.WriteLine("Result: " + result);
            }
            catch (DivideByZeroException)
            {
                // Handle division by zero
                Console.WriteLine("Cannot divide by zero");
            }
            catch (FormatException)
            {
                // Handle non-numeric input
                Console.WriteLine("Please enter valid numbers only");
            }
        }
    }
}
